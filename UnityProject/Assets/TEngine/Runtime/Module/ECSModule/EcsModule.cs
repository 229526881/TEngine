using TEngine;

namespace TEngine
{
    public class EcsModule: Module,IEcsModule
    {
        public override void OnInit()
        {
        }

        public override void Shutdown()
        {
        }

        /// <summary>
        /// 注册事件进行运行
        /// </summary>
        /// <param name="component"></param>
        /// <param name="isRegister"></param>
        public void RegisterSystem(Entity component, bool isRegister = true)
        {
        }

        /// <summary>
        /// system Awake
        /// </summary>
        /// <param name="component"></param>
        public void AwakeSystem(Entity component)
        {
        }

        /// <summary>
        /// system Awake
        /// </summary>
        /// <param name="component"></param>
        /// <param name="t1"></param>
        /// <typeparam name="T"></typeparam>
        public void AwakeSystem<T>(Entity component, T t1)
        {
        }

        public void Update()
        {
            
        }

        public void LateUpdate()
        {
            
        }

        public void FixedUpdate()
        {
            
        }

        public void DestroySystem(Entity component)
        {
            
        }
    }
}