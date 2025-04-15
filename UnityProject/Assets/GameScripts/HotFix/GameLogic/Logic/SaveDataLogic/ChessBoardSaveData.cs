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
        
        
        /// <summary>
        /// buff 对应的数据，思考是否都属于棋盘存档
        /// </summary>
        public List<BuffStateSaveData> ChessBoardStates = new List<BuffStateSaveData>();

        
        
    }
}