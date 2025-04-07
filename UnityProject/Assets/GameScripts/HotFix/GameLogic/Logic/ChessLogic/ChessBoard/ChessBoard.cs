using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ChessBoard: Entity
    {
        public ChessBoard()
        {
            AddComponent<ChessBoardBottomBtnComponent,ChessBoard>(this);
        }
    }
}