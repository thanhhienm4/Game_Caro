using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Caro
{
    [Serializable]
    class SocketData
    {
        private int command;
        private string message;

        public int Command { get => command; set => command = value; }
        public string Message { get => message; set => message = value; }

        public Point point;

        public SocketData (int command,string message,Point point)
        {
            this.command = command;
            this.point = point;
            this.message = message;
        }
        
        
    }
    public enum SocketCommand
    {
        SENDPOINT,
        NOTIFY,
        NEWGAME,
        UNDO,
        QUIT

    };

}
