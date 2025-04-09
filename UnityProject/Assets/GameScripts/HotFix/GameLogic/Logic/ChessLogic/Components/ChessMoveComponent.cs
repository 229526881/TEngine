using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ChessMoveComponent:Entity
    {
        private ChessMonoComponent chessMono;
        private bool startMove = false;
        
        protected override void Init()
        {
            base.Init();
            chessMono = GetComponent<ChessMonoComponent>();
            startMove = false;
        }

        public void Drag(Vector2 pos)
        {
            if(chessMono==null) return;
            if (!startMove)
            {
                startMove = true;
                chessMono.StartMove();
            }

            //偏移坐标
            chessMono.UpdateDeltaPos(pos);
        }

        public void EndMove()
        {
            startMove = false;
            //
            //找到应该的有的坐标并且设定位置
            chessMono?.EndMove();
        }

        protected override void OnDispose()
        {
            startMove = false;
        }
    }
    
}