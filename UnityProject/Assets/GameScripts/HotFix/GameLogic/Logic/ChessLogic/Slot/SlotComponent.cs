using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TEngine;
using UnityEngine;


namespace GameLogic
{
    public partial class SlotComponent
    {
        private List<int[]> arourdPoint = new List<int[]>() { new[] { -1, 0 }, new[] { 0, 1 }, new[] { 0, -1 }, new[] { 1, 0 } };
        /// <summary>
        /// 找到周围9格内的空格子
        /// </summary>
        /// <returns></returns>
        public List<int> GetNearSlotEmptysAround(int index)
        {
            List<int> nearIndexs = new List<int>();
            int row = index / maxCol;
            int col = index % maxCol;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int row1 = row + i;
                    int col1 = col + j;
                    if (row == row1 && col == col1)
                        continue;
                    if (!CheckIsInBorder(row1, col1))
                    {
                        continue;
                    }
                    int res = row1 * maxCol + col1;
                    if (CheckSlotEqual(res,-1))
                    {
                        nearIndexs.Add(res);
                    }
                }
            }

            return nearIndexs;
        }

        public List<int> GetNearEmptySlots(int index, int count)
        {
            List<int> nearIndexs = new List<int>();
            int bottom = -1, right = 1;
            int row = index / maxCol;
            int col = index % maxCol;
            int maxTurn = 2 * Math.Max(Math.Max(row - 1, maxRow - row), Math.Max(col - 1, maxCol - col));
            for (int turn = 1; turn <= maxTurn + 3; turn++)
            {
                for (int i = 0; i < turn; i++)
                {
                    row += bottom;
                    if (!CheckIsInBorder(row, col))
                        continue;
                    
                    int res = row * maxCol + col;
                    if (CheckSlotEqual(res,-1))
                    {
                        nearIndexs.Add(res);
                        if (nearIndexs.Count >= count)
                            return nearIndexs;
                    }
                }

                for (int i = 0; i < turn; i++)
                {
                    col += right;
                    if (!CheckIsInBorder(row, col))
                        continue;
                    int res = row * maxCol + col;
                    if (CheckSlotEqual(res,-1))
                    {
                        nearIndexs.Add(res);
                        if (nearIndexs.Count >= count)
                            return nearIndexs;
                    }
                }

                bottom = -bottom;
                right = -right;
            }

            return nearIndexs;
        }

        public int GetNearEmptySlot(int index)
        {
            int bottom = -1, right = 1;
            int row = index / maxCol;
            int col = index % maxCol;
            int maxTurn = 2 * Math.Max(Math.Max(row - 1, maxRow - row), Math.Max(col - 1, maxCol - col));
            for (int turn = 1; turn <= maxTurn + 3; turn++)
            {
                for (int i = 0; i < turn; i++)
                {
                    row += bottom;
                    if (!CheckIsInBorder(row, col))
                        continue;
                    int res = row * maxCol + col;
                    if (CheckSlotEqual(res,-1))
                    {
                        return res;
                    }
                }

                for (int i = 0; i < turn; i++)
                {
                    col += right;
                    if (!CheckIsInBorder(row, col))
                        continue;
                    int res = row * maxCol + col;
                    if (CheckSlotEqual(res,-1))
                    {
                        return res;
                    }
                }

                bottom = -bottom;
                right = -right;
            }

            return -1;
        }

        /// <summary>
        /// 获得默认周围4个方向的棋子，符合条件的棋子
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<int> GetNearSlotsAroundLock(int index, Func<SlotData, bool> checkSlot, List<int[]>  arourdPoint=null)
        {
            List<int> nearIndexs = new List<int>();
            int row = index / maxCol;
            int col = index % maxCol;

            List<int[]> arourds = arourdPoint;
            if (arourds == null)
            {
                arourds = this.arourdPoint;
            }

            for (int i = 0; i < arourds.Count; i++)
            {
                int row1 = row + arourds[i][0];
                int col1 = col + arourds[i][1];
                if (row == row1 && col == col1)
                    continue;
                if (!CheckIsInBorder(row1, col1))
                {
                    continue;
                }

                int res = row1 * maxCol + col1;
                if (checkSlot(slotDatas[res]))
                {
                    nearIndexs.Add(res);
                }
            }

            return nearIndexs;
        }

        /// <summary>
        /// 从头到尾找空
        /// </summary>
        /// <returns></returns>
        public int GetEmptySlot()
        {
            for (int i = 0; i < slotDatas.Count; i++)
            {
                if (slotDatas[i].id < 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private bool CheckIsInBorder(int row, int col)
        {
            return row >= 0 && row < maxRow && col >= 0 & col < maxCol;
        }

        private bool CheckSlotEqual(int slotIndex,int val)
        {
            return slotDatas[slotIndex].id == val;
        }
    }

    public partial class SlotComponent : Entity
    {
        private List<SlotData> slotDatas;

        private List<Slot> slots;

        private int maxRow;
        
        private int maxCol;

        private Transform slotParent;

        /// <summary>
        /// 是否实例化完成
        /// </summary>
        private bool initEnd = false;
        public void Init()
        {
            maxRow = GameDefine.ChessboardRow;
            maxCol = GameDefine.ChessboardCol;

            for (int i = 0; i < slotDatas.Count; i++)
            {
                Slot slot= AddComponent<Slot, SlotData>(slotDatas[i]);
                slots.Add(slot);
            }
        }

        public async UniTask  CreateResetMono(Transform slotParent)
        {
            this.slotParent = slotParent;
            for (int i = 0; i < slots.Count; i++)
            {
               await   slots[i].Instantiate(slotParent);
            }

            initEnd = true;
        }

        //更新棋子数据需要同步到存档中
    }
}