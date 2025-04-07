using GameConfig;
using TEngine;

namespace GameLogic
{
    public class ChessDetailTagComponent: Entity
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

        /// <summary>
        /// 获得棋子操作类型，可能会通过这个创建对应按钮逻辑
        /// </summary>
        /// <returns></returns>
        public ChessDetailTag GetChessDetailType()
        {
           // ChessDetailTag  detailTag=ChessDetailType
           Chess_TypePropertyItem typePropertyItem = null;
           ChessDetailTag chessTagType = typePropertyItem.ChessDetailTag;
            if (chessConfigItem.SaleCoin > 0)
            {
                chessTagType |= ChessDetailTag.Sale;
            }
            else
            {
                chessTagType |= ChessDetailTag.Delete;
            }

            chessTagType |= chess.DealDetailType();
            return chessTagType;
        }

        //刷新功能消费逻辑TODO
        //怎么确认每个应该返回的值呢
    }
    
    public class ChessDealTypeComponentAwakeSystem : AwakeSystem<ChessDetailTagComponent, Chess>
    {
        public override void Awake(ChessDetailTagComponent self, Chess a)
        {
           self.Init(a);
        }
    }
    
    
    public class ChessDealTypeComponentFixedUpdateSystem : FixedUpdateSystem<ChessDetailTagComponent>
    {
        public override void FixedUpdate(ChessDetailTagComponent self)
        {
            self.FixedUpdate();
        }
    }
}