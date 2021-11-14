using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋
{
    class BlackPiece : PieceClass
    {
        public BlackPiece(int x, int y) : base(x, y)
        {
            this.Image = Properties.Resources.white;
            //this.Image = Properties.Resources.white;
        }
    }
}
