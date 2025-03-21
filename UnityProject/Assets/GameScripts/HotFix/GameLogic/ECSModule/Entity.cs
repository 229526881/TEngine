using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TEngine;

namespace GameLogic
{
    public partial class Entity:  IMemory
    {
        protected Entity domain;

        protected long Id;
        //一系列entity的作用域
        public Entity Domain
        {
            get
            {
                return this.domain;
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

        private void AddChild(Entity entity)
        {
            this.Children.Add(entity.Id, entity);
          //  this.AddChildDB(entity);
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
                //this.Domain = this.parent.domain;
            }
        }
        
        public  List<Entity> components = new List<Entity>();

        public Dictionary<Type,Entity>allComponents = new Dictionary<Type, Entity>();
        public Entity AddComponent(Type type)
        {
            if (allComponents==null&&allComponents.ContainsKey(type))
            {
                throw new Exception($"entity already has component: {type.FullName}");
            }
            Entity entity = MemoryPool.Acquire(type) as  Entity;
            if (entity == null)
            {
                entity=(Entity)Activator.CreateInstance(type);
            }
            entity.ComponentParent = this;
            allComponents.Add(type, entity);
            return entity;
        }
        
        public T AddComponent<T>() where T : Entity
        {
            Type type = typeof(T);
            Entity entity = AddComponent(type);
            return entity as T;
        }
        
        
        

        public virtual Entity GetComponent(Type type)
        {
            if (allComponents!=null&&allComponents.TryGetValue(type, out Entity component))
            {
                return component;
            }
            return null;
        }

        public bool RemoveComponent(Entity entity)
        {
            return false;
        }


        private Entity CreateEntity(Type type)
        {
          //  MemoryPool.Acquire<>
          return null;
        }

        public void Clear()
        {
            
        }
    }
}
