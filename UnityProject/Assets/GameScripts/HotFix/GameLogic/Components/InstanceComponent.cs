using TEngine;
using UnityEngine;

namespace GameLogic
{
    //实例化的行为
    public class InstanceComponent:Entity
    {
        public string assetPath;
        public Transform parent;

        private GameObject go;
        public  GameObject Instance(Transform parent)
        {
            go= GameModule.Resource.LoadGameObject(assetPath, parent);
            return go;
        }

        public void Destroy()
        {
            GameModule.Resource.UnloadAsset(go);
        }
    }
}