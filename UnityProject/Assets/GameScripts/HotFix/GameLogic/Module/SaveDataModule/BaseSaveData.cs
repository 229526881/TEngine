using TEngine;

namespace GameLogic
{
    public abstract class BaseSaveData
    {
        protected string className;

        public BaseSaveData()
        {
            className = GetType().Name;
        }

        public virtual void SaveData()
        {
            bool compress = true;     
#if UNITY_EDITOR
            compress = false;
#endif
            string data =Utility.Json.ToJson(this);
            //存档逻辑，这里有个问题就是字段无法序列化成父类字段 TODO
            
        }
    }
}