using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋
{
    class Board
    {
        private static readonly int NODE_COUNT = 9;

        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
        private static readonly int OFFSET = 75;
        private static readonly int Node_Radius = 10;
        private static readonly int Node_Distance = 75;

        private PieceClass[,] Places = new PieceClass[9, 9]; // 宣告二維陣列 => 存放旗子的資料結構
        
        public PieceType GetPieceType(int nodelX, int nodelY)
        {
            if (Places[nodelX, nodelY] == null)
            {
                return PieceType.None; // 如果沒有旗子回傳空
            }
            else
            {
                return Places[nodelX, nodelY].GetPieceType(); // 如果有旗子，回傳顏色
            }
            
        }
        public bool CanBePlaced(int x, int y) // 確認位置是否可放旗子
        {
            //TODO : 找出最近的節點(Node)
            Point nodeld = FindTheClosetNode(x, y);

            //TODO : 如果有回傳False
            if (nodeld == NO_MATCH_NODE)
                return false;

            //TODO : 如果有的話，檢查是否已經有旗子存在
            return true;
        }

        public PieceClass PlaceAPiece(int x, int y, PieceType Type)
        {
            //TODO : 找出最近的節點(Node)
            Point nodeld = FindTheClosetNode(x, y);

            //TODO : 如果有回傳False
            if (nodeld == NO_MATCH_NODE)
                return null; // null = 沒有物件

            //TODO : 如果有的話，檢查是否已經有旗子存在
            if (Places[nodeld.X, nodeld.Y] == null)
            {
                return null; // 如果有旗子就不能放
            }

            //TODO: 根據 type 產生對應的棋子
            Point formPos = convertToFormPosition(nodeld);
            if (Type == PieceType.BLACK)
                Places[nodeld.X, nodeld.Y] = new BlackPiece(formPos.X, formPos.Y);
            else if (Type == PieceType.WHITE)
                Places[nodeld.X, nodeld.Y] = new WhitePiece(formPos.X, formPos.Y);

            return Places[nodeld.X, nodeld.Y];
        }

        private Point convertToFormPosition(Point nodeld)
        {
            Point formPosition = new Point();
            formPosition.X = nodeld.X * Node_Distance + OFFSET;
            formPosition.Y = nodeld.Y * Node_Distance + OFFSET;
            return formPosition;
        }

        private Point FindTheClosetNode(int x, int y)
        {
            int nodeIdX = FindTheClosetNode(x);
            if (nodeIdX == -1 || nodeIdX >= NODE_COUNT) // 注意判斷的邊界
                return NO_MATCH_NODE;

            int nodeIdY = FindTheClosetNode(y);
            if (nodeIdY == -1 || nodeIdY >= NODE_COUNT)
                return NO_MATCH_NODE;
            return new Point(nodeIdX, nodeIdY);
        }

        private int FindTheClosetNode(int pos)
        {
            if (pos < OFFSET - Node_Radius)
                return -1;

            pos -= OFFSET;

            int quotient = pos / Node_Distance;
            int remainder = pos % Node_Distance;

            if (remainder <= Node_Radius)

                return quotient;
            else if (remainder >= Node_Distance - Node_Radius)
                return quotient + 1;
            else
                return -1;
        }
    }
}
