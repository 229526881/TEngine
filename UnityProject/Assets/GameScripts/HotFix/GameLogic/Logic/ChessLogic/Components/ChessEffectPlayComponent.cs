using TEngine;
using UnityEngine;

namespace GameLogic
{
    /// <summary>
    /// 播放棋子特效的组件
    /// </summary>
    public class ChessEffectPlayComponent:Entity
    {
        /// <summary>
        /// 播放棋子的spine特效，这里需要考虑放置的位置和父节点，还有是否是一次性的，思考部分跟随棋子移动的特效，思考dc的处理
        /// </summary>
        /// <param name="location"></param>
        /// <param name="loop"></param>
        /// <param name="parent"></param>
        public void PlaySpineEffect(string location,bool  loop,Transform parent)
        {
            
        }

        public void StartMove()
        {
            
        }
        
        public void SetPos(Vector2 pos)
        {
            
        }
    }
}