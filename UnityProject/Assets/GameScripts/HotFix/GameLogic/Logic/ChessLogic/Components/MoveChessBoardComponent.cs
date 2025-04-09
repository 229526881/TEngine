using UnityEngine;
using TEngine;

namespace GameLogic
{
    public class MoveChessBoardComponent:Entity
    {
       private   ChessMoveComponent chessMoveComponent;
        public bool OnMoveStartChess(Chess  chess)
        {
            if (chess == null || !(chess.GetComponent<ChessMoveComponent>() is { } component))
            {
                return false;
            }
            chessMoveComponent=component;
            //chessMoveComponent.StartMove();
            return true;
        }

        public void OnMouseHoverEvent(Vector2 deltaPos)
        {
            if(chessMoveComponent==null) return;
            chessMoveComponent?.Drag(deltaPos);
        }

        public void OnMouseUpEvent()
        {
            if(chessMoveComponent==null) return;
            
            //这里还需要和仓库进行判断TODO,这个得组件进行判断位置逻辑TODO
            chessMoveComponent.EndMove();
        }

    }
}