using Newtonsoft.Json;

namespace GameLogic
{
    
    /// <summary>
    /// 棋子存档
    /// </summary>
    public class SlotData
    {
        /// <summary>
        /// 撤回临时纪录的数据
        /// </summary>
        [JsonIgnore]
        public int tempSlotIndex=-1;
        /// <summary>
        /// 棋子Id
        /// </summary>
        public int id=-1;

        /// <summary>
        /// 可以生成的数量
        /// </summary>
        public int spawn=0;

        /// <summary>
        /// 是否解锁
        /// </summary>
        public bool isLock = false;

        /// <summary>
        /// -1锁住,0半解锁，1解锁
        /// </summary>
        public int lockState = -1;

        /// <summary>
        /// 生产器用完次数,和cd变化有关
        /// </summary>
        public int round = 0;

        /// <summary>
        /// cd转完时间
        /// </summary>
        public long cdT;

        /// <summary>
        /// 状态，暂时和状态生产器相关
        /// </summary>
        public int state = 0;
        
        /// <summary>
        /// 气泡对应的棋子ID
        /// </summary>
        public int orignBubblyId = -1;

        public void Reset()
        {
            id = -1;
            spawn = 0;
            isLock = false;
            round = 0;
            cdT = 0;
            state = 0;
            orignBubblyId = -1;
        }

        public void SetData(SlotData data)
        {
            id = data.id;
            spawn = data.spawn;
            isLock =data.isLock;
            round = data.round;
            cdT = data.cdT;
            state = data.state;
            lockState = data.lockState;
            orignBubblyId = data.orignBubblyId;
        }
    }

    /// <summary>
    /// 仓库存档信息
    /// </summary>
    public class BaseWareHouseSaveData
    {
        /// <summary>
        /// 是否解锁
        /// </summary>
        public bool isLock = true;
        public SlotData slotData = null;
    }

    /// <summary>
    /// 补充部分参数后的仓库
    /// </summary>
    public class NormalWareHouseSaveData : BaseWareHouseSaveData
    {
        [JsonIgnore]
        public int price;
        [JsonIgnore]
        public bool  isPay=false;
    }
}