using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋
{
    class Black:Piece
    {
        public Black(int x, int y):base(x,y)
        {
            this.Image = Properties.Resources.black;
        }
    }
}
