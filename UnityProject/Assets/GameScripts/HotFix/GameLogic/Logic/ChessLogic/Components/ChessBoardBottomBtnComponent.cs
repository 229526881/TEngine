using System.Collections.Generic;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ChessBoardBottomBtnComponent:Entity
    {
        //这里需要做子组件逻辑TODO
        /// <summary>
        ///  底部按钮
        /// </summary>
        private Dictionary<ChessDetailTag,ChessBoardBottmBtn>bottomBtns=new Dictionary<ChessDetailTag, ChessBoardBottmBtn>();

        /// <summary>
        /// 正在展示的按钮
        /// </summary>
        private List<ChessBoardBottmBtn> showBtns=new List<ChessBoardBottmBtn>();


        private Chess showChess;
        
        public void SetState(bool state, ChessDetailTag chessDetailType=ChessDetailTag.None)
        {

        }

        public void SetChessShow(ChessDetailTagComponent chessDetailTagComponent)
        {
            if(chessDetailTagComponent==null ||chessDetailTagComponent.IsDisposed) return;
            //刷新展示，并且部分按钮有其自己的刷新逻辑

            ChessDetailTag tag = chessDetailTagComponent.GetChessDetailType();
            //使用遍历寻找当前实际有的类型
            if (!bottomBtns.TryGetValue(tag, out ChessBoardBottmBtn btn))
            {
                //需要根据类型去找到对应的组件才行
                //AddComponent<>
            }
        }

        protected override void OnDispose()
        {
            
        }
    }
}