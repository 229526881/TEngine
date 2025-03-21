using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TEngine;

namespace GameLogic
{
    public partial class Entity: IMemory
    {
        public  List<Entity> components = new List<Entity>();

        public void AddComponent(Entity component)
        {
            
        }
        
        public void AddComponent<T>()
        {
              ObjectPoolBase
        }

        public virtual Entity GetComponent(Type type)
        {

            return null;
        }

        public void Clear()
        {
            
        }
    }
}
