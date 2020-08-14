using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Caro
{
    class History
    {
        private Point current_Point;
        private int current_Player;

        public Point Current_Point { get => current_Point; set => current_Point = value; }
        public int Current_Player { get => current_Player; set => current_Player = value; }

        public  History(Point current_Point, int current_Player)
        {
            this.current_Point = current_Point;
            this.Current_Player = current_Player;
        }
    }
}
