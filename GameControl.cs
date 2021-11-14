using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋
{
    class GameControl
    {
        private Board board = new Board();

        private PieceType currentPlayer = PieceType.BLACK;
    
        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }

        public PieceClass PlacePiece(int x, int y)
        {
            PieceClass piece = board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {

                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else if (currentPlayer == PieceType.WHITE)
                    currentPlayer = PieceType.BLACK;

                return piece;
            }

            return null;
        }

        private void CheckWinner()
        {

        }
    }
}
