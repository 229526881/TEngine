using System.Collections.Generic;

namespace GameLogic
{
    public class ChessBoardSaveData:BaseSaveData
    {
        /// <summary>
        /// 棋盘
        /// </summary>
        public List<SlotData> Slots = new List<SlotData>();
        
        /// <summary>
        /// 仓库数据
        /// </summary>
        public List<NormalWareHouseSaveData> WareHouseDatas = new List<NormalWareHouseSaveData>();
        
        public List<BuffStateSaveData> ChessBoardStates = new List<BuffStateSaveData>();

    }
}