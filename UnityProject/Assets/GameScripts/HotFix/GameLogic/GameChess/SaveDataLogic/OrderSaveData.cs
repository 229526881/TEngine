using System.Collections.Generic;

namespace GameLogic
{
    public class OrderSaveData:BaseSaveData
    {  
        /// <summary>
        /// 每生成一个订单就自增
        /// </summary>
        public int serialId = 1;
        
        /// <summary>
        /// 当前拥有的订单
        /// </summary>
        public List<OrderData> orders=new List<OrderData>();
        
        /// <summary>
        /// 已完成的订单
        /// </summary>
        public List<int> achieveOrderList=new List<int>();
    }
}