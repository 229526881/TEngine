using TEngine;

namespace GameLogic
{
    /// <summary>
    /// 所有棋盘的逻辑的总父节点
    /// </summary>
    public class ChessBoardRoot:Entity
    {
        
    }

    public class ChessBoardRootAwakeSystem : AwakeSystem<ChessBoardRoot>
    {
        public override void Awake(ChessBoardRoot self)
        {
            //2个核心功能组件,订单和棋盘
            self.AddComponent<ChessBoard>();
            self.AddComponent<Order>();
            
            
        }
    }
}