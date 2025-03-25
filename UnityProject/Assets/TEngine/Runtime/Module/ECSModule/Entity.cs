using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TEngine
{
    public partial class Entity:  IMemory
    {
        protected Entity domain;

        protected long Id;
        
        public long InstanceId
        {
            
            get;
            protected set;
        }
 
        public bool IsDisposed => this.InstanceId == 0;
        
        //一系列entity的作用域
        public Entity Domain
        {
            get
            {
                return this.domain;
            }
            private set
            {
                if (value == null)
                {
                    throw new Exception($"domain cant set null: {this.GetType().Name}");
                }

                if (this.domain == value)  //作用域可以会触发system 进行注册的处理
                {
                    return;
                }
                
                Entity preDomain = this.domain;
                if (preDomain == null)
                {
                    InstanceId = Utility_IdGenerater.GenerateInstanceId();
                    this.IsRegister = true;
                    
                }
                
                
                // 递归设置孩子的Domain
                if (this.children != null)
                {
                    foreach (Entity entity in this.children.Values)
                    {
                        entity.Domain = this.domain;
                    }
                }

                if (this.components != null)
                {
                    foreach (Entity component in this.components.Values)
                    {
                        component.Domain = this.domain;
                    }
                }
            }
        }

        private bool IsComponent;
        
        protected Entity parent;

        public Entity Parent
        {
            get => this.parent;

            set
            {
                if (value == null)
                {
                    throw new Exception($"cant set parent null: {this.GetType().Name}");
                }
                
                if (value == this)
                {
                    throw new Exception($"cant set parent self: {this.GetType().Name}");
                }
                this.parent = value;
                this.parent.AddChild(this);
                this.IsComponent = false;
            }
        }
        
        private Dictionary<long, Entity> children;

        public Dictionary<long, Entity> Children
        {
            get
            {
                if (this.children == null)
                {
                    //this.children = childrenPool.Fetch();
                }
                return this.children;
            }
        }



        private Entity ComponentParent
        {
            set
            {
                if (this.parent != null)
                {
                    throw new Exception($"Component parent is not null: {this.GetType().Name}");
                }

                this.parent = value;
                this.IsComponent = true;
                this.Domain = this.parent.domain;
            }
        }
        
        private bool isRegister;
        protected bool IsRegister
        {
            get => isRegister;
            set
            {
                if (this.isRegister == value)
                {
                    return;
                }
                isRegister = value;
                //同时注册对应的进入运行逻辑
              //  EventSystem.Instance.RegisterSystem(this, value);
            }
        }
        
      //  public  List<Entity> components = new List<Entity>();

        public Dictionary<Type,Entity>components = new Dictionary<Type, Entity>();


        private Entity AddComponentSelf(Type type)
        {
            if (components==null&&components.ContainsKey(type))
            {
                throw new Exception($"entity already has component: {type.FullName}");
            }

            Entity entity = Create(type);
            entity.ComponentParent = this;
            entity.Id = Id; //和挂载的entity一致
            components.Add(type, entity);
            return entity;
        }
        
        private Entity AddChildSelf(Type type,long id=-1)
        {
            Entity entity =Create(type);
            if (id < 0)
            {
                id=Utility_IdGenerater.GenerateInstanceId();
            }

            entity.Id = id;
            entity.Parent = this;
            return entity;
        }
        
        public Entity AddComponent(Type type)
        {
            Entity entity= AddComponentSelf(type);
            
            return entity;
        }
        
        public T AddComponent<T>() where T : Entity
        {
            
            Type type = typeof(T);
            Entity entity = AddComponent(type);
            //EventSystem.Instance.Awake(component);
            return entity as T;
        }
        
        public T AddComponent<T,K>(K k1) where T : Entity
        {
            
            Type type = typeof(T);
            Entity entity = AddComponent(type);
            //EventSystem.Instance.Awake(component,k1);
            return entity as T;
        }


        public T AddChild<T>() where T : Entity
        {
            Entity child = AddChildSelf(typeof(T));
            //EventSystem.Instance.Awake(component);
            return child as T;
        }
        
        public T AddChild<T,K>(K k1) where T : Entity
        {
            Entity child = AddChildSelf(typeof(T));
            //EventSystem.Instance.Awake(component,k1);
            return child as T;
        }

        public T AddChildWithId<T>(long id) where T : Entity
        {
            Entity child = AddChildSelf(typeof(T),id);
            return child as T;
        }

        private void AddChild(Entity entity)
        {
            this.Children.Add(entity.Id, entity);
            //  this.AddChildDB(entity);
        }
        
        private bool RemoveChild(Entity entity)
        {
            return false;
        }
        
        public bool RemoveComponent(Entity entity)
        {
            return false;
        }


        public static Entity Create(Type type)
        {
            Entity entity = MemoryPool.Acquire(type) as  Entity;
            if (entity == null)
            {
                entity=(Entity)Activator.CreateInstance(type);
            }

            return entity;
        }

        public virtual Entity GetComponent(Type type) 
        {
            if (components!=null&&components.TryGetValue(type, out Entity component))
            {
                return component;
            }
            return null;
        }

        
        public void Clear()
        {
            if(this.IsDisposed)
                return;
            isRegister = false;
            InstanceId = 0;
            //回收组件
            if (components != null)
            {
                
            }

            //清理children
            if (children != null)
            {
                
            }
            
            //触发destory 事件
        }
    }
}
