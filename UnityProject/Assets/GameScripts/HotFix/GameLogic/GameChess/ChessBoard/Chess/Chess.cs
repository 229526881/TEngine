using System.Collections;
using System.Collections.Generic;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class Chess : Entity
    {
        private Chess_ConfigItem _chessConfigItem;

        public Chess_ConfigItem ChessConfigItem { get { return _chessConfigItem; } set { _chessConfigItem = value; } }

        
        public virtual void  InitChessConfig(Chess_ConfigItem chessConfigItem)
        {
            this._chessConfigItem=chessConfigItem;
            AddComponent<ChessDetailComponent,Chess>(this);
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

        public virtual void SetChessMono(ChessMono chessMono)
        {
            AddChild<ChessMono,Chess>(this);
        }

        public virtual void OnChessClick()
        {
            
        }

        public static void Create(Chess_ConfigItem _chessConfigItem)
        {
            Chess chess = new Chess();
            
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
