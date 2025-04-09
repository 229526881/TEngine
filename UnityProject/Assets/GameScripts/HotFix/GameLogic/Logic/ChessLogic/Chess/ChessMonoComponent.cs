using System.Threading;
using Cysharp.Threading.Tasks;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ChessMonoComponent:Entity
    {
        
        private GameObject _go;

        public GameObject go { private set;  get; }

        private ChessEffectPlayComponent _chessEffectPlayComponent;

        //private CancellationToken cancellationToken;
        
        //这里思考一个点就是逻辑和UI分离的问题
        public  async UniTask Instantiate(Transform parent)
        {
            //实例化由棋盘的资源控制器进行处理
            
            _go = await GameModule.Resource.LoadGameObjectAsync("Chess",parent,(Parent as Chess).CancellationToken);
            //这里可以增加逻辑就是实例化过程中被dispose 销毁就取消
            // _chessEffectPlayComponent = GetComponent<ChessEffectPlayComponent>();
            //增加一个特效节点位置TODO
            if(_go ==null)
                return;
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

        protected override void OnDispose()
        {
            
            //取消逻辑补充
            //if()
            GameModule.Resource.UnloadAsset(_go);
            //回收生成的元素对象池TODO
            //如果没有处理则使用取消节点的cancel逻辑
        }
    }
}