using System.Collections.Generic;

namespace GameLogic
{
    public class DefaultDataSaveManager:IDataSaveManegr
    {
        public DataSaveType dataSaveType { get; set; }
        public Dictionary<string, BaseSaveData> allSaveData { get; set; }

        public void SaveSpecificData(string fileName, string content)
        {
            
        }

        public void UpdateDirtyData()
        {
        }

        /// <summary>
        /// 储存当前所有的存档
        /// </summary>
        public void SaveAllData()
        {
            
        }
    }
}