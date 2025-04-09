using Cysharp.Threading.Tasks;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ChessMonoComponent:Entity
    {
        
        private Transform _transform;

        public Transform transform { private set;  get; }

        private ChessEffectPlayComponent _chessEffectPlayComponent;
        public  async UniTask Instantiate(Transform parent)
        {
            //实例化由棋盘的资源控制器进行处理
            transform = (await GameModule.Resource.LoadGameObjectAsync("Chess",parent)).transform;
            //这里可以增加逻辑就是实例化过程中被dispose 销毁就取消
           // _chessEffectPlayComponent = GetComponent<ChessEffectPlayComponent>();
           //增加一个特效节点位置TODO
           _chessEffectPlayComponent= AddComponent<ChessEffectPlayComponent>();
        }

        public void StartMove()
        {
            //修改父节点，不过这些参数需要如何读取还是要思考的，然后对特效相关进行跟踪位置 TODO
            //_chessEffectPlayComponent
        }

        public void UpdateDeltaPos(Vector2 deltaPos)
        {
            
        }
        
        public void SetPos(Vector2 pos)
        {
            
        }
        
        public void EndMove()
        {
            //根据当前坐标做处理
        }
    }
}