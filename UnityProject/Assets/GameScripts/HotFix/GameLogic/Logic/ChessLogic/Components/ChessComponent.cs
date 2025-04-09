using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ChessComponent : Entity
    {
        public List<Chess> chessList=new List<Chess>();

        public Dictionary<int, Chess> chessDict = new Dictionary<int, Chess>();

        private Transform chessParent;

        private bool initEnd = false;

        public  async UniTaskVoid CreateResetMono(Transform parent)
        {
           //棋子根据实例化   
           chessParent = parent;
           for (int i = 0; i < chessList.Count; i++)
           {
               Chess chess = chessList[i];
               await  chess.GetComponent<ChessMonoComponent>().Instantiate(parent);
           }
           initEnd = true;
        }

        /// <summary>
        /// 根据存档数据初始化表格，获得根据变化
        /// </summary>
        public void InitChessList()
        {
            
        }

        public void AddChessLast(Chess chess)
        {
            
        }

        public void AddChess(int slotIndex,Chess chess)
        {
            chessList[slotIndex] = chess;
        }


        public void RemoveChess(int slotIndex)
        {
            
        }

        public void RemoveChess(Chess chess)
        {
            
        }

    }
}
