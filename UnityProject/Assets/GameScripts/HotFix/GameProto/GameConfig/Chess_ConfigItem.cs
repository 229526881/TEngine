
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;


namespace GameConfig
{
public sealed partial class Chess_ConfigItem : Luban.BeanBase
{
    public Chess_ConfigItem(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Key = _buf.ReadInt();
        Name = _buf.ReadString();
        Icon = _buf.ReadString();
        GroupIndex = _buf.ReadInt();
        GroupIndex_Ref = null;
        IsMax = _buf.ReadBool();
        Type = (ChessType)_buf.ReadInt();
        EndType = (ProducerEndType)_buf.ReadInt();
        SaleCoin = _buf.ReadInt();
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);Coin = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); Coin.Add(_e0);}}
        CoinRate = _buf.ReadFloat();
        Gem = _buf.ReadInt();
        BubblePossible = _buf.ReadInt();
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);BubblyRewardWeight = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); BubblyRewardWeight.Add(_e0);}}
        ConsumeCount = _buf.ReadInt();
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);ChessSpawnItemList = new System.Collections.Generic.List<RandomWeightItem>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { RandomWeightItem _e0;  _e0 = RandomWeightItem.DeserializeRandomWeightItem(_buf); ChessSpawnItemList.Add(_e0);}}
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);RewardList = new System.Collections.Generic.List<Rewards>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { Rewards _e0;  _e0 = Rewards.DeserializeRewards(_buf); RewardList.Add(_e0);}}
        {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);CdList = new System.Collections.Generic.List<int>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { int _e0;  _e0 = _buf.ReadInt(); CdList.Add(_e0);}}
        Limit = _buf.ReadInt();
        StateNum = _buf.ReadInt();
        PreCDT = _buf.ReadInt();
        LinkChessId = _buf.ReadInt();
        UnlockReward = Rewards.DeserializeRewards(_buf);
        NoProduceTip = _buf.ReadBool();
        ActivityKey = _buf.ReadString();
        CombinId = _buf.ReadInt();
    }

    public static Chess_ConfigItem DeserializeChess_ConfigItem(ByteBuf _buf)
    {
        return new Chess_ConfigItem(_buf);
    }

    /// <summary>
    /// 棋子ID
    /// </summary>
    public readonly int Id;
    /// <summary>
    /// 棋子索引
    /// </summary>
    public readonly int Key;
    /// <summary>
    /// 名称
    /// </summary>
    public readonly string Name;
    /// <summary>
    /// 图片名
    /// </summary>
    public readonly string Icon;
    /// <summary>
    /// 组Id
    /// </summary>
    public readonly int GroupIndex;
    public Chess_GroupItem GroupIndex_Ref;
    /// <summary>
    /// 是否是最大
    /// </summary>
    public readonly bool IsMax;
    /// <summary>
    /// 类型
    /// </summary>
    public readonly ChessType Type;
    /// <summary>
    /// 生产器用完状态
    /// </summary>
    public readonly ProducerEndType EndType;
    /// <summary>
    /// 售卖价格
    /// </summary>
    public readonly int SaleCoin;
    /// <summary>
    /// 金币价格
    /// </summary>
    public readonly System.Collections.Generic.List<int> Coin;
    /// <summary>
    /// 金币倍数
    /// </summary>
    public readonly float CoinRate;
    /// <summary>
    /// 钻石价格
    /// </summary>
    public readonly int Gem;
    /// <summary>
    /// 气泡概率
    /// </summary>
    public readonly int BubblePossible;
    /// <summary>
    /// 气泡产出道具权重
    /// </summary>
    public readonly System.Collections.Generic.List<int> BubblyRewardWeight;
    /// <summary>
    /// 消耗的体力量
    /// </summary>
    public readonly int ConsumeCount;
    /// <summary>
    /// 生产器生成的对应内容
    /// </summary>
    public readonly System.Collections.Generic.List<RandomWeightItem> ChessSpawnItemList;
    /// <summary>
    /// 棋子使用获得的ID和数量
    /// </summary>
    public readonly System.Collections.Generic.List<Rewards> RewardList;
    /// <summary>
    /// 生产器的cd秒
    /// </summary>
    public readonly System.Collections.Generic.List<int> CdList;
    /// <summary>
    /// 限制的数量
    /// </summary>
    public readonly int Limit;
    /// <summary>
    /// 状态生产器的次数
    /// </summary>
    public readonly int StateNum;
    /// <summary>
    /// 前置冷却时间
    /// </summary>
    public readonly int PreCDT;
    /// <summary>
    /// 变化后对应的ID
    /// </summary>
    public readonly int LinkChessId;
    /// <summary>
    /// 解锁的奖励
    /// </summary>
    public readonly Rewards UnlockReward;
    /// <summary>
    /// 是否没有生产器效果
    /// </summary>
    public readonly bool NoProduceTip;
    public readonly string ActivityKey;
    /// <summary>
    /// 组合棋子对应的ID
    /// </summary>
    public readonly int CombinId;
   
    public const int __ID__ = 699740244;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
        GroupIndex_Ref = tables.ChessGroup.GetOrDefault(GroupIndex);
    }

    public override string ToString()
    {
        return "{ "
        + "id:" + Id + ","
        + "key:" + Key + ","
        + "name:" + Name + ","
        + "icon:" + Icon + ","
        + "groupIndex:" + GroupIndex + ","
        + "isMax:" + IsMax + ","
        + "type:" + Type + ","
        + "endType:" + EndType + ","
        + "saleCoin:" + SaleCoin + ","
        + "coin:" + Luban.StringUtil.CollectionToString(Coin) + ","
        + "coinRate:" + CoinRate + ","
        + "gem:" + Gem + ","
        + "bubblePossible:" + BubblePossible + ","
        + "bubblyRewardWeight:" + Luban.StringUtil.CollectionToString(BubblyRewardWeight) + ","
        + "consumeCount:" + ConsumeCount + ","
        + "ChessSpawnItemList:" + Luban.StringUtil.CollectionToString(ChessSpawnItemList) + ","
        + "rewardList:" + Luban.StringUtil.CollectionToString(RewardList) + ","
        + "cdList:" + Luban.StringUtil.CollectionToString(CdList) + ","
        + "limit:" + Limit + ","
        + "stateNum:" + StateNum + ","
        + "preCDT:" + PreCDT + ","
        + "linkChessId:" + LinkChessId + ","
        + "unlockReward:" + UnlockReward + ","
        + "noProduceTip:" + NoProduceTip + ","
        + "activityKey:" + ActivityKey + ","
        + "combinId:" + CombinId + ","
        + "}";
    }
}

}

