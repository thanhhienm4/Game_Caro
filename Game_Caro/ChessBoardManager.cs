using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Game_Caro
{
    class ChessBoardManager
    {
        #region  Properties
        private Panel chessboard;
        private List<List<Button>> matrix;
        private event EventHandler <ButtonClickEven>  playerMark;
        private Stack<History> history_Play ;
        


        public event EventHandler <ButtonClickEven> PlayerMark
        {
            add
            {
                playerMark += value;
            }
            remove
            {
                playerMark -= value;
            }
        }
        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add
            {
                endedGame += value;
            }
            remove
            {
                endedGame -= value;
            }
        }

        #endregion
        #region Initialize
        public ChessBoardManager(Panel chessboard ,PictureBox ptbMark ,TextBox tbxName)
        {
            this.Chessboard = chessboard;
            this.TbxName = tbxName;
            this.ptbMark = ptbMark;
        }
        PictureBox ptbMark; TextBox tbxName;
        List<Player> ListPlayer = new List<Player>()
        {
            new Player("Player1",Image.FromFile(Application.StartupPath + "\\Resources\\x.jpg")),
            new Player("Player2",Image.FromFile(Application.StartupPath + "\\Resources\\o.jpg"))

        };
        private int currentPlayer = 0;
        
        public Panel Chessboard { get => chessboard; set => chessboard = value; }
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
        public PictureBox PtbMark { get => ptbMark; set => ptbMark = value; }
        public TextBox TbxName { get => tbxName; set => tbxName = value; }
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }
        internal Stack<History> History_Play { get => history_Play; set => history_Play = value; }

        #endregion
        #region Methods
        public void Draw_chessboard()
        {
            InitialStart();
            Chessboard.Controls.Clear();
            Matrix = new List<List<Button>>();
            history_Play = new Stack<History>();
            int x, y;
            y = Chessboard.Location.Y-Const.CHESS_HEIGHT +3;
            for (int i = 0; i < Const.CHESS_BOARD_HEIGHT; i++)
            {
                Matrix.Add(new List<Button>());
                x = Chessboard.Location.X;
                for (int j = 0; j < Const.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button
                    {
                        Width = Const.CHESS_WIDTH,
                        Height = Const.CHESS_HEIGHT,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Location = new Point(x, y),
                        Tag = i.ToString()
                    };
      
                    btn.Click += Btn_Click;
                    Chessboard.Controls.Add(btn);
                    Matrix[i].Add(btn);
                    x += Const.CHESS_WIDTH;


                }
                y += Const.CHESS_HEIGHT;
            }
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            Chessboard.Enabled = false;
            Button btn = sender as Button;
            Point point = getChessPoint(btn);
            
            history_Play.Push(new History(point, CurrentPlayer));
            if (btn.BackgroundImage != null)
                return;
            btn.BackgroundImage = ListPlayer[CurrentPlayer].PlayerMark;
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            ChangePlayer();
            playerMark(this, new ButtonClickEven(point));
            if (playerMark != null)
                if (isEndGame(btn)==true)
            {
                endGame();
            }
           
        }
        public void OtherPlayerMark(Point point)
        {
            Chessboard.Enabled = true;
            Button btn = matrix[point.X][point.Y];
            //Point point = getChessPoint(btn);

            history_Play.Push(new History(point, CurrentPlayer));
            if (btn.BackgroundImage != null)
                return;
            btn.BackgroundImage = ListPlayer[CurrentPlayer].PlayerMark;
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            ChangePlayer();
           // playerMark(this, new ButtonClickEven(point));
           if(playerMark != null)
            if (isEndGame(btn) == true)
            {
                endGame();
            }
        }
        private Point getChessPoint(Button btn)
        {
           
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);
            Point point = new Point(vertical,horizontal);
            return point;

        }
        public void endGame()
        {
            if (endedGame != null)
                endedGame(this, new EventArgs());
        }
        private bool  isEndGame(Button btn )
        {
            return (horizontal(btn) || vertical(btn) || mainDiagonal(btn) || subDiagonal(btn));
        }
        private bool horizontal(Button btn)
        {
            int before = 0;
            Point point = getChessPoint(btn);
            for(int i=point.X-1;i>=0;i--)
            {
                if (matrix[i][point.Y].BackgroundImage == btn.BackgroundImage)
                    before++;
                else
                    break;
            }

            int after = 0;
            for(int i=point.X;i<Const.CHESS_BOARD_WIDTH;i++)
            {
                if (matrix[i][point.Y].BackgroundImage == btn.BackgroundImage)
                    after ++;
                else
                    break;
            }
            return after + before >= 5 ? true : false;
        }
        private bool vertical(Button btn)
        {
            int before = 0;
            int after = 0;
            Point point = getChessPoint(btn);
            for(int i=point.Y-1;i>=0;i--)
            {
                if (matrix[point.X][i].BackgroundImage == btn.BackgroundImage)
                    before++;
                else
                    break;
            }
            for (int i = point.Y; i <Const.CHESS_BOARD_HEIGHT ; i++)
            {
                if (matrix[point.X][i].BackgroundImage == btn.BackgroundImage)
                    after++;
                else
                    break;
            }
            return after + before >= 5 ? true : false;


        }
        private bool mainDiagonal(Button btn)
        {
            int before = 0;
            int after = 0;
            Point point = new Point();
            point = getChessPoint(btn);
            point.X--; point.Y--;
            while (point.X >= 0 && point.Y >= 0)
            {
                if (matrix[point.X--][point.Y--].BackgroundImage == btn.BackgroundImage)
                    before++;
                else
                    break;
            }
            point = getChessPoint(btn);
            while (point.X < Const.CHESS_BOARD_WIDTH && point.Y < Const.CHESS_BOARD_HEIGHT)
            {
                if (matrix[point.X++][point.Y++].BackgroundImage == btn.BackgroundImage)
                    before++;
                else
                    break;
            }
            return after + before >= 5 ? true : false;
        }
        private bool subDiagonal(Button btn)
        {
            int before = 0;
            int after = 0;
            Point point = new Point();
            point = getChessPoint(btn);
            point.X++; point.Y--;
            while (point.X <Const.CHESS_BOARD_WIDTH && point.Y >=0)
            {
                if (matrix[point.X++][point.Y--].BackgroundImage == btn.BackgroundImage)
                    before++;
                else
                    break;
            }
            point = getChessPoint(btn);
            while (point.X >=0 && point.Y < Const.CHESS_BOARD_HEIGHT)
            {
                if (matrix[point.X--][point.Y++].BackgroundImage == btn.BackgroundImage)
                    before++;
                else
                    break;
            }
            return after + before >= 5 ? true : false;
        }
        private void InitialStart()
        {
            currentPlayer = 0;
            TbxName.Text = ListPlayer[currentPlayer].PlayerName;
            ptbMark.BackgroundImage = ListPlayer[currentPlayer].PlayerMark;
        }
        public void ChangePlayer()
        {
            TbxName.Text = ListPlayer[CurrentPlayer].PlayerName;
            ptbMark.BackgroundImage = ListPlayer[CurrentPlayer].PlayerMark;
        }
        #endregion

    }
    public class ButtonClickEven : EventArgs
    {
        private Point clickPoint;

        public Point ClickPoint { get => clickPoint; set => clickPoint = value; }
        public ButtonClickEven(Point point)
        {
            this.clickPoint = point;
        }
    }
}
