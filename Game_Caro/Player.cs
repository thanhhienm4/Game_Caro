using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Caro
{
    class Player
    {
        private string playerName;
        private Image playerMark;
        public Player(string playerName , Image playerMark)
        {
            this.PlayerMark = playerMark;
            this.PlayerName = playerName;
         }

        public string PlayerName { get => playerName; set => playerName = value; }
        public Image PlayerMark { get => playerMark; set => playerMark = value; }
    }
}
