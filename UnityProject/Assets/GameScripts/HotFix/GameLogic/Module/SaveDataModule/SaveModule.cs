using System.IO;
using TEngine;

namespace GameLogic
{
    public enum DataSaveType
    {
        /// <summary>
        /// json。
        /// </summary>
        Json,
        /// <summary>
        /// 二进制储存。
        /// </summary>
        Byte,
    }
    
    public class SaveModule:Singleton<UIModule>
    {
        public IDataSaveManegr _dataSaveManegr;
        public string pathRoot;
        protected override void OnInit()
        {
            pathRoot = Utility.Path.GetProjectRootPath();
            _dataSaveManegr = new DefaultDataSaveManager();
        }

        protected override void OnRelease()
        {
            
        }


        public void SaveSpecificData(string fileName,string content)
        {
            _dataSaveManegr.SaveSpecificData(fileName,content);
        }
    }
}