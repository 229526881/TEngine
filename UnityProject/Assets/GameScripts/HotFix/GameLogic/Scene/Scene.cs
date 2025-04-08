using TEngine;
namespace GameLogic
{
        public class Scene:Entity
        {
            
            public string Name
            {
                get;
                set;
            }

            public Scene(long instanceId,string name,Entity parent)
            {
                this.InstanceId = instanceId;
                this.Name = name;
                
                
                this.IsRegister = true;
                this.Parent = parent;
                this.Domain = this;
            }
            
            public Scene(long id, long instanceId,string name,Entity parent)
            {
                this.Id = id;
                this.InstanceId = instanceId;
                this.Name = name;
                
                
                this.IsRegister = true;
                this.Parent = parent;
                this.Domain = this;
            }
            
            public new Entity Domain
            {
                get => this.domain;
                set => this.domain = value;
            }
            
            
            public new Entity Parent
            {
                get
                {
                    return this.parent;
                }
                set
                {
                    if (value == null)
                    {
                        this.parent = this;
                        return;
                    }

                    this.parent = value;
                    this.parent.Children.Add(this.Id, this);
                }
            }
        }
}