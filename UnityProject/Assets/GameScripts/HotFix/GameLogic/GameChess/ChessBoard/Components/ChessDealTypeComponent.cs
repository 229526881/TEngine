using GameConfig;
using TEngine;

namespace GameLogic
{
    public class ChessDealTypeComponent: Entity
    {
        private Chess chess;
        private Chess_ConfigItem chessConfigItem;
        
        public void Init(Chess chess)
        {
            this.chess = chess;
            chessConfigItem = chess.ChessConfigItem;
        }

        public void FixedUpdate()
        {
            
        }

        //刷新功能消费逻辑TODO
    }
    
    public class ChessDealTypeComponentAwakeSystem : AwakeSystem<ChessDealTypeComponent, Chess>
    {
        public override void Awake(ChessDealTypeComponent self, Chess a)
        {
           self.Init(a);
        }
    }
    
    
    public class ChessDealTypeComponentFixedUpdateSystem : FixedUpdateSystem<ChessDealTypeComponent>
    {
        public override void FixedUpdate(ChessDealTypeComponent self)
        {
            self.FixedUpdate();
        }
    }
}