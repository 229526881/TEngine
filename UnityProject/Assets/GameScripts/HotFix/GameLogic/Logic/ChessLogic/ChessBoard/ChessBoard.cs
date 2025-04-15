using TEngine;
using UnityEngine;

namespace GameLogic
{
    public partial class ChessBoard: Entity
    {

        private ChessBoardSaveData _saveData;
    }

    /// <summary>
    /// 处理对应的方法逻辑
    /// </summary>
    public partial class ChessBoard
    {
        /// <summary>
        /// 读取棋盘相关的存档，理论上棋盘的存档只包括自己，这里可以把仓库相关的暂时放在此处
        /// </summary>
        public void LoadSaveData()
        {
            
        }


        /// <summary>
        /// 这里需要有差异储存的问题，要保证玩家的存档不丢失，又不能过于频繁，这里可以把玩家的存档给复杂化，即做成类似数据库的方式存键值对
        /// </summary>
        public void SaveData()
        {
           //如果说把一整局的操作都得纪录下来的话，进行复盘然后对棋盘的产出进行复现是完全没问题的是吧，生产和移动合成这类高频繁操作修改的数据变化可能没被存上，但是操作被纪录下来了
           //如果下次要复现就会有活动不是相同的状态的问题，这个该怎么避免呢，而且逻辑帧的行为 是不一样的，可能棋子的状态发生变化了，这个做成帧同步有点为难思考一下，复盘过于复杂

           _saveData.isDirty = true; //思考一下如何可以做到那么及时
        }
    }

    public class ChessBoardAwakeSystem : AwakeSystem<ChessBoard>
    {
        public override void Awake(ChessBoard self)
        {
            //self.AddComponent<ChessBoardSaveData>();
            self.AddComponent<SlotComponent>();
            self.AddComponent<ChessBoardBottomBtnComponent,ChessBoard>(self);
            self.AddComponent<ChessComponent>();
            self.AddComponent<ChessBoardBottomBtnComponent>();
            self.AddComponent<ChessBoardMoveChessComponent>();
        }
    }
    
     
}