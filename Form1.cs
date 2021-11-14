using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋
{
    public partial class Form1 : Form
    {
        private GameControl game = new GameControl();

        public Form1()
        {
            InitializeComponent();

            //this.Controls.Add(new Piece(10, 20)); // 將新的元件加入視窗的清單
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            PieceClass piece = game.PlacePiece(e.X, e.Y);
            if (piece != null)
            {
                this.Controls.Add(piece);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand; // 改變滑鼠的樣貌

            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
