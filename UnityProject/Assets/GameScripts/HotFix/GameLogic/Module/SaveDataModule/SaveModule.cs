using System.IO;
using TEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

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
    
    public class SaveModule:Singleton<SaveModule>,IUpdate
    {
        public IDataSaveManegr _dataSaveManegr;
        public string pathRoot;

        private float deltaSaveTimer = 0;
        
        private float currentSaveTime = 30;
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

#if ODIN_INSPECTOR
        [Button("SaveAllData")]
#endif
        public void SaveAllData()
        {
            deltaSaveTimer = 0;
            //对存档进行一次储存
            _dataSaveManegr.SaveAllData();
            
            //同时需要取消原来进行储存的逻辑
        }


        public void OnUpdate()
        {
            //如果达到指定储存时间，会储存，同时部分逻辑会强制储存存档
            //使用时间系统增加逻辑处理刷新
            
            
        }
    }
}