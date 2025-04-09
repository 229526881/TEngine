using Cysharp.Threading.Tasks;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class Slot:Entity
    {
        private SlotData data;

        private GameObject go;
        //然后他还需要包含他的创建能力，

        public void Init(SlotData data)
        {
             this.data = data;
        }

        public async UniTask Instantiate(Transform parent)
        {
            //这里有对图片的替换逻辑才行
             go=  await   GameModule.Resource.LoadGameObjectAsync("Slot",parent);
        }
    }
}