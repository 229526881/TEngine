using System;
using System.Collections.Generic;
using System.Reflection;
using GameLogic;
using TEngine;

namespace TEngine
{
    public class EcsModule: Singleton<EcsModule>,IUpdate,IFixedUpdate,ILateUpdate
    {

        private List<Assembly> _hotfixAssemble;
        private Dictionary<long,Entity> allEntities = new Dictionary<long,Entity>();
        
        private Queue<long> fixedUpdates = new Queue<long>();
        private Queue<long> fixedUpdates2 = new Queue<long>();

        private Queue<long> updates = new Queue<long>();
        private Queue<long> updates2 = new Queue<long>();

        private Queue<long> lateUpdates = new Queue<long>();
        private Queue<long> lateUpdates2 = new Queue<long>();
        
        private static readonly Dictionary<string, Type> _cachedTypes = new Dictionary<string, Type>(StringComparer.Ordinal);



        protected override void OnInit()
        {
            
        }

        protected override void OnRelease()
        {
            
        }

        public void InitAssemblys(List<Assembly> _hotfixAssembly)
        {
            this._hotfixAssemble = _hotfixAssembly;
        }
        
        /// <summary>
        /// 获取已加载的程序集中的指定类型。
        /// </summary>
        /// <param name="typeName">要获取的类型名。</param>
        /// <returns>已加载的程序集中的指定类型。</returns>
        public  Type GetType(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                throw new GameFrameworkException("Type name is invalid.");
            }

            Type type = null;
            if (_cachedTypes.TryGetValue(typeName, out type))
            {
                return type;
            }

            type = Type.GetType(typeName);
            if (type != null)
            {
                _cachedTypes.Add(typeName, type);
                return type;
            }

            foreach (System.Reflection.Assembly assembly in _hotfixAssemble)
            {
                type = Type.GetType(Utility.Text.Format("{0}, {1}", typeName, assembly.FullName));
                if (type != null)
                {
                    _cachedTypes.Add(typeName, type);
                    return type;
                }
            }

            return null;
        }

        /// <summary>
        /// 注册事件进行运行
        /// </summary>
        /// <param name="component"></param>
        /// <param name="isRegister"></param>
        public void RegisterSystem(Entity component, bool isRegister = true)
        {
            if(component==null) return;
            if (!isRegister)
            {
                Remove(component.InstanceId);
                return;
            }

            allEntities.TryAdd(component.InstanceId, component);
            
            //找到拥有的生命周期逻辑进行注册 ,程序集 是懒加载做的，如何寻找所有就是一个问题其实也好，命名是一致的
            string typeName = component.GetType().Name;
            if (GetType(Utility.Text.Format("{0}, {1}", typeName, "UpdateSystem")) !=null)
            {
                updates.Enqueue(component.InstanceId);
            }
            if (GetType(Utility.Text.Format("{0}, {1}", typeName, "FixedUpdateSystem")) !=null)
            {
                fixedUpdates.Enqueue(component.InstanceId);
            }
            if (GetType(Utility.Text.Format("{0}, {1}", typeName, "LateUpdateSystem")) !=null)
            {
                lateUpdates.Enqueue(component.InstanceId);
            }
        }

        public void Remove(long instanceId)
        {
            allEntities.Remove(instanceId);
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

        public void OnUpdate()
        {
            while (this.updates.Count > 0)
            {
                long instanceId = this.updates.Dequeue();
                Entity component;
                if (!this.allEntities.TryGetValue(instanceId, out component))
                {
                    continue;
                }
            
                if (component.IsDisposed)
                {
                    continue;
                }

                //这里思考下多个泛型的update的用法
                IUpdateSystem iUpdateSystem = GetType(Utility.Text.Format("{0}, {1}",  component.GetType().Name, "UpdateSystem")) as IUpdateSystem;
                if (iUpdateSystem == null)
                {
                    continue;
                }
            
                this.updates2.Enqueue(instanceId);
            
                try
                {
                    iUpdateSystem.Run(component);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
            //重新交换,保证已经回收update不重复使用
            Utlility_ObjectHelper.Swap(ref this.updates, ref this.updates2);
        }

        public void OnLateUpdate()
        {
            while (this.lateUpdates.Count > 0)
            {
                long instanceId = this.lateUpdates.Dequeue();
                Entity component;
                if (!this.allEntities.TryGetValue(instanceId, out component))
                {
                    continue;
                }
            
                if (component.IsDisposed)
                {
                    continue;
                }

                //这里思考下多个泛型的update的用法
                ILateUpdateSystem iLateUpdateSystem = GetType(Utility.Text.Format("{0}, {1}",  component.GetType().Name, "LateUpdateSystem")) as ILateUpdateSystem;
                if (iLateUpdateSystem == null)
                {
                    continue;
                }
            
                this.lateUpdates2.Enqueue(instanceId);
            
                try
                {
                    iLateUpdateSystem.Run(component);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
            //重新交换,保证已经回收update不重复使用
            Utlility_ObjectHelper.Swap(ref this.lateUpdates, ref this.lateUpdates2 );
        }

        public void OnFixedUpdate()
        {
            
        }

        public void DestroySystem(Entity component)
        {
            
        }


    }
}