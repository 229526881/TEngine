using System.Collections;
using System.Collections.Generic;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class Chess : Entity
    {
        protected Chess_ConfigItem _chessConfigItem;

        public virtual void UpdateChessType()
        {
            
        }

        public virtual void SetChessMono()
        {
            
        }

        public virtual void OnChessClick()
        {
            
        }

        public static void Create(Chess_ConfigItem _chessConfigItem)
        {
            Chess chess = new Chess();
            
        }
    }
}
