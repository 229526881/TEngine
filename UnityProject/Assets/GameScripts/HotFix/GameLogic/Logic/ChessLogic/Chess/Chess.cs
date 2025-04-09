using System.Collections;
using System.Collections.Generic;
using System.Threading;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class Chess : Entity
    {
        private Chess_ConfigItem _chessConfigItem;

        public Chess_ConfigItem ChessConfigItem { get { return _chessConfigItem; } set { _chessConfigItem = value; } }

        private CancellationTokenSource cancellationTokenSource;

        public CancellationToken CancellationToken
        {
            get => cancellationTokenSource.Token;
        }

        public virtual void  InitChessConfig(Chess_ConfigItem chessConfigItem)
        {
            this._chessConfigItem=chessConfigItem;
            AddComponent<ChessDetailComponent,Chess>(this);
            AddComponent<ChessDetailTagComponent,Chess>(this);
        }

        public virtual void UpdateChessType()
        {
            GetComponent<ChessDetailComponent>()?.UpdateByChessType();
        }

        /// <summary>
        /// 处理棋子的特殊描述
        /// </summary>
        /// <returns></returns>
        public virtual string DealDetailMidStr()
        {
            return "";
        }
        
        /// <summary>
        /// 处理棋子的特殊操作类型,比如生产器会动态刷新时间
        /// </summary>
        /// <returns></returns>
        public virtual ChessDetailTag DealDetailType()
        {
            return ChessDetailTag.None;
        }

        public virtual void SetChessMono(ChessMonoComponent chessMonoComponent)
        {
            AddChild<ChessMonoComponent,Chess>(this);
        }
        
        /// <summary>
        /// 棋子的选中逻辑,暂时是修改描述的功能
        /// </summary>
        public virtual void OnChessSelect()
        {
            
        }

        /// <summary>
        /// 棋子的双击逻辑,不同棋子的行为不同
        /// </summary>
        public virtual void OnChessClick()
        {
            
        }

        public static void Create(Chess_ConfigItem _chessConfigItem)
        {
            Chess chess = new Chess();
            
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            cancellationToken.Cancel();
        }
    }

    /// <summary>
    /// 生产器棋子
    /// </summary>
    public class ProducerChess : Chess
    {
        public override void InitChessConfig(Chess_ConfigItem chessConfigItem)
        {
            
        }
    }
}
