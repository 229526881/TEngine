using System;
using System.Collections.Generic;
using GameConfig;
using TEngine;


namespace GameLogic
{
    public class ChessDetailComponent : Entity
    {
        private Chess chess;
        private Chess_ConfigItem chessConfigItem;
        
        /// <summary>
        /// 脏数据标记
        /// </summary>
        private bool isDirty = false;
        
        /// <summary>
        /// 当前描述
        /// </summary>
        private string desContent = "";

        //标题单独处理TO
        //private string title = "";

        /// <summary>
        /// 某些描述会动态变化并且修改组件的值，根据需求增加
        /// </summary>
        private Action<string> onUpdateContentEvent;
        
        /// <summary>
        /// 标题处理
        /// </summary>
        private Action<string> onUpdateTitleEvent;


        public void Init(Chess chess)
        {
            this.chess = chess;
            chessConfigItem = chess.ChessConfigItem;
            isDirty = true;
        }

        public void UpdateByChessType()
        {
            //这里表格的懒加载还没用
            Chess_TypePropertyItem typePropertyItem = null;
            string content = desContent;
            if (string.IsNullOrEmpty(chessConfigItem.GroupIndex_Ref.GroupDes))
            {
                string contentFormate = chess.ChessConfigItem.IsMax ? typePropertyItem.MaxContentStr : typePropertyItem.NotMaxContentStr;

                content = Utility.Text.Format(contentFormate, chess.DealDetailMidStr());
                //下面是具体的逻辑到时要分配个每个棋子处理
                //     if (chess.ChessConfigItem.IsMax)
                //     {
                //         contentList[0] = "";
                //         contentList[2] = "这个棋子已经达到最高等级。";
                //     }
                //     else
                //     {
                //         contentList[0] = "合成相同棋子,进行升级。";
                //         contentList[2] = "";
                //     }
                //
                //     //组件内部自己控制
                //     switch (chess.ChessConfigItem.Type)
                //     {
                //         case ChessType.Currency:
                //             contentList[1] = string.Format(chessConfigItem.GroupIndex_Ref.DesExtra, chessConfigItem.RewardList[0].Count);
                //             break;
                //         case ChessType.Task:
                //             if (chess.ChessConfigItem.IsMax)
                //             {
                //                 contentList[0] = "点击收集建筑材料。";
                //                 contentList[2] = "这个棋子已经达到最高等级。";
                //             }
                //             else
                //             {
                //                 contentList[0] = "合成相同棋子,进行升级。";
                //                 contentList[2] = "";
                //             }
                //
                //             break;
                //         case ChessType.Bubbly:
                //             break;
                //         case ChessType.Activity:
                //             //这个需要根据活动的数据进行变化TODO
                //             // contentList[1] = string.Format(chessConfigItem.GroupIndex_Ref.DesExtra,activity.ConfigItem.LevelPoint[chessConfig.Level-1] );
                //             break;
                //         case ChessType.NormalProducer:
                //         case ChessType.AutoProducer:
                //             if (chessConfigItem.ChessSpawnItemList.Count > 0)
                //             {
                //                 contentList[1] = "点击以生成新棋子";
                //             }
                //
                //             break;
                //         case ChessType.StateProducer:
                //             contentList[1] = "点击多次以生成棋子";
                //             break;
                //         case ChessType.Treasure:
                //             //TODO
                //             //宝箱在不同状态下会展示不同的提示这个有点单独的逻辑
                //             if (chessConfigItem.ChessSpawnItemList.Count > 0)
                //             {
                //                 contentList[1] = "点击以生成新棋子";
                //             }
                //
                //             break;
                //}
            }
            else
            {
                content = chessConfigItem.GroupIndex_Ref.GroupDes;
            }
            //对第一个阶段单独处理

            //基础的逻辑

            if (!content.Equals(desContent))
            {
                isDirty = true;
            }

            if (isDirty)
            {
                desContent = content;
                onUpdateContentEvent?.Invoke(desContent); 
                //这里用事件的方式进行传递会比较好TODO
                isDirty = false;
            }
        }

        private string GetContent() //如果弃用这个数据也会丢失引用
        {
            if (!isDirty)
            {
                return desContent;
            }

            isDirty = false;
            UpdateByChessType();
            return desContent;
        }

        /// <summary>
        /// 描述栏获得描述理论上会动态更新数据才对，
        /// </summary>
        /// <param name="updateAction"></param>
        /// <returns></returns>
        public string BindGetContent(Action<string> updateAction = null) //如果弃用这个数据也会丢失引用
        {
            onUpdateContentEvent = updateAction;
            return GetContent();
        }

        /// <summary>
        /// 注销event
        /// </summary>
        protected override void OnDispose()
        {
            onUpdateContentEvent?.Invoke("");
            onUpdateContentEvent = null;
        }
    }

    public class ChessDetailComponentAwakeSystem : AwakeSystem<ChessDetailComponent, Chess>
    {
        public override void Awake(ChessDetailComponent self, Chess a)
        {
            self.Init(a);
        }
    }
    
}