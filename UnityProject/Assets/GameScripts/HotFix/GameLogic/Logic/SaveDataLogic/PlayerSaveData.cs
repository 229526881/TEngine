using System.Collections.Generic;

namespace GameLogic
{
    public class PlayerSaveData:BaseSaveData
    {
        /// <summary>
        /// 拥有的道具字典
        /// </summary>
        public Dictionary<int, int> propDict = new Dictionary<int, int>();
        
        /// <summary>
        /// 属性字段
        /// </summary>
        public Dictionary<string, int> propertyDict = new Dictionary<string, int>();
        
        /// <summary>
        /// 棋盘奖励栏 先进后出
        /// </summary>
        public List<int> topRewards = new List<int>();

        //部分模块存档

        public SettingSaveData SettingSaveData;
        
        public TaskSaveData TaskSaveData;
        
        public GuideSaveData GuideSaveData;
        
        public EnergySaveData EnergySaveData;
    }

    public class PropertySaveData
    {
        
    }

    public class SettingSaveData
    {
        /// <summary>
        ///  音量 音效
        /// </summary>
        public bool MusicEnable=true;
        public float MusicVolume=1;
        
        public bool SoundEnable=true;
        public float SoundVolume=1;
        
        public bool UISoundEnable=true;
        public float UISoundVolume=1;

      
        /// <summary>
        /// 是否开启合成提示
        /// </summary>
        public bool MergeTip = true;

        public void SaveData()
        {
       
        }
    }
    
    /// <summary>
    /// 剧情数据
    /// </summary>
    public class TaskSaveData
    {
        public TaskSaveData(int taskDay,int taskId)
        {
            this.taskDay = taskDay;
            this.taskId = taskId;
        }

        /// <summary>
        /// 当前的taskId
        /// </summary>
        public int taskId;

        /// <summary>
        /// 任务天数
        /// </summary>
        public int taskDay;
    }

    /// <summary>
    /// 体力相关数据
    /// </summary>
    public class EnergySaveData 
    {
        // /// <summary>
        // /// 免费购买的次数
        // /// </summary>
        // public int freeTime = 0;
        //
        // /// <summary>
        // /// 体力补给的序号，每日进来会刷新
        // /// </summary>
        // public int energySupplyIndex = 0;

        /// <summary>
        /// 刷新时间
        /// </summary>
        public long supplyRefreshTime;

        /// <summary>
        /// 进行下一次体力回复时间
        /// </summary>
        public long EnergyReplyTime = 0;

        /// <summary>
        /// 体力回满的时间
        /// </summary>
        public long EnergyTotalTime = 0;
    }

    /// <summary>
    /// 存档逻辑是否该调整，思考下
    /// </summary>
    public class GuideSaveData
    {
        /// <summary>
        /// 当前强引导步骤纪录，有继续保存使用逻辑
        /// </summary>
        public int forceGuideId = -1;

        /// <summary>
        /// 已完成的存档步骤
        /// </summary>
        public List<string> achieveEventSteps = new List<string>();

        /// <summary>
        /// 进特定页面触发特定引导,这里会有问题就是需要记录部分棋子数据
        /// </summary>
        public Dictionary<string, int> panelGuideSaveStep = new Dictionary<string, int>();

    }
}