using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Caro
{
    public partial class Form1 : Form
    {
        
        ChessBoardManager chessboard;
        SocketManager socket;
        Stack<int> Time = new Stack<int>();

     

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            socket = new SocketManager();
            InitializeComponent();
            chessboard = new ChessBoardManager(pnl_chessboard,ptbMark,tbxName);
            chessboard.EndedGame += Chessboard_EndedGame;
            chessboard.PlayerMark += Chessboard_PlayerMark;
            ptbMark.BackgroundImageLayout = ImageLayout.Stretch;
            NewGame();

            pgbCoolDown.Step = Const.COOL_DOWN_STEP;
            pgbCoolDown.Maximum = Const.COOL_DOWN_TIME;
            pgbCoolDown.Minimum = 0;

            tmCoolDown.Interval = Const.COOL_DOWN_INTERVAL;
            

        }
        private void EndGame()
        {
            MessageBox.Show("Kết thúc game ahihi =)) ");
            pnl_chessboard.Enabled = false;
        }
        private void Chessboard_PlayerMark(object sender, ButtonClickEven e)
        {
            Time.Push(pgbCoolDown.Value);
            pgbCoolDown.Value = 0;
            tmCoolDown.Start();
            socket.Send(new SocketData((int)SocketCommand.SENDPOINT, "",e.ClickPoint));
            try
            {
                Listen();
            }
            catch
            {

            }
            
            
        }

        private void Chessboard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
            pnl_chessboard.Enabled = false;
        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            pgbCoolDown.PerformStep();
            if (pgbCoolDown.Value >= pgbCoolDown.Maximum)
            {
                
                tmCoolDown.Stop();
                EndGame();
            }
        }
        public void NewGame()
        {
            pnl_chessboard.Enabled = true;
            chessboard.Draw_chessboard();
            tmCoolDown.Stop();
            pgbCoolDown.Value = 0;

          
        }
        public void Quit()
        {
            //if (MessageBox.Show("Bạn thật sự muốn kết thúc game ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                Application.Exit();
        }
        public bool Undo()
        {
            if (chessboard.History_Play.Count <= 0)
                return false;
            History history = chessboard.History_Play.Pop();
            chessboard.Matrix[history.Current_Point.X][history.Current_Point.Y].BackgroundImage = null;
            chessboard.CurrentPlayer = history.Current_Player;
            pgbCoolDown.Value = Time.Pop();
            chessboard.ChangePlayer();
            return true;
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            socket.Send(new SocketData((int)SocketCommand.NEWGAME, "", new Point()));
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Undo() == true)
                MessageBox.Show("Người chơi đã Undo", "Thông báo");
            else
                MessageBox.Show("Không thể Undo", "Thông báo");
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn kết thúc game ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;

            }else
                socket.Send(new SocketData((int)SocketCommand.QUIT, "nguoi choi da thoat", new Point()));
        }
        private void btnLAN_Click(object sender, EventArgs e)
        {
            socket.IP = tbxIp.Text;

            if (!socket.ConnectServer())
            {
                socket.CreateServer();
            }
            else
            {
                chessboard.Chessboard.Enabled = false;
                Listen();
            }
                


        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            tbxIp.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(tbxIp.Text))
            {
                tbxIp.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }
        void Listen()
        {

             Thread listenThread = new Thread(() =>
                {
                    try
                    {
                        SocketData data = (SocketData)socket.Receive();
                        ProcessData(data);
                    }
                    catch
                    {

                    }
                });
                listenThread.IsBackground = true;
                listenThread.Start();
            
            
            //MessageBox.Show(data);
        }
        private void ProcessData(SocketData data)
        {
            switch(data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    tmCoolDown.Stop();
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.SENDPOINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        pgbCoolDown.Value = 0;
                        tmCoolDown.Start();
                        chessboard.OtherPlayerMark(data.point);
                    }));
                    
                    break;
                case (int)SocketCommand.NEWGAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pnl_chessboard.Enabled = false;

                    }));
                    
                    break;
                case (int)SocketCommand.UNDO:
                    break;
                case (int)SocketCommand.QUIT:
                   
                    this.Invoke((MethodInvoker)(() =>
                    {
                        tmCoolDown.Stop();
                        MessageBox.Show(data.Message);
                        Application.Exit();

                    }));

                    break;
                default:
                    break;
            }
            Listen();
        }
    }
    
}
