namespace TEngine
{
    public interface IEcsModule
    {
        /// <summary>
        /// 注册事件进行运行
        /// </summary>
        /// <param name="component"></param>
        /// <param name="isRegister"></param>
        void RegisterSystem(Entity component, bool isRegister = true);

        void Remove(long instanceId);


        /// <summary>
        /// system Awake
        /// </summary>
        /// <param name="component"></param>
        void AwakeSystem(Entity component);

        /// <summary>
        /// system Awake
        /// </summary>
        /// <param name="component"></param>
        /// <param name="t1"></param>
        /// <typeparam name="T"></typeparam>
        void AwakeSystem<T>(Entity component,T t1);

        void Update();

        void LateUpdate();
         
        void FixedUpdate();
         
        void DestroySystem(Entity component);
    }
}