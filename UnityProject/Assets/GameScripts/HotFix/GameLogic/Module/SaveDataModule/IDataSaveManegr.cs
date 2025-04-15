using System.Collections.Generic;

namespace GameLogic
{
    public interface IDataSaveManegr
    {
        public  DataSaveType dataSaveType { get; set; }

        public Dictionary<string, BaseSaveData> allSaveData { get; set; }

        /// <summary>
        /// 特定路径存特定的数据
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        public void SaveSpecificData(string fileName, string content);


        /// <summary>
        /// 刷新脏数据
        /// </summary>
        public void UpdateDirtyData();

        
        /// <summary>
        /// 存所有的存档
        /// </summary>
        public void SaveAllData();
    }
}