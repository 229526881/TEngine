using UnityEngine;
using TEngine;

namespace GameLogic
{
    public class TouchChessBoardComponent:Entity
    {
        private Chess selectChess;
        private bool isMove = false;
        public void OnMouseDownChessBoard(Vector2 pos)
        {
            //这里还有多点触控的问题，需要屏蔽一下 TODO ,效果是开始
            int chessIndex = 0;
            Chess chess = GetComponent<ChessComponent>().chessList[chessIndex];
            if(chess==null) return;

            isMove = false;
            if (selectChess == chess)
            {
                chess.OnChessClick();
            }
            else
            {
                selectChess = chess;
                chess.OnChessClick();
                isMove=  GetComponent<MoveChessBoardComponent>().OnMoveStartChess(chess);
            }
        }

        //这里 还有一个双击的行为 TODO
        public void OnMouseMoveChessBoard(Vector2 pos)
        {
            if(!isMove) return;
            GetComponent<MoveChessBoardComponent>().OnMouseHoverEvent(pos);
        }

        public void OnMouseUpChessBoard(Vector2 pos)
        {
            isMove = false;
            GetComponent<MoveChessBoardComponent>().OnMouseUpEvent();
        }
    }

    public class TouchChessBoardComponentAwakeSystem : AwakeSystem<TouchChessBoardComponent>
    {
        public override void Awake(TouchChessBoardComponent self)
        {
            //这个需要对mono类型的
            
        }
    }
}