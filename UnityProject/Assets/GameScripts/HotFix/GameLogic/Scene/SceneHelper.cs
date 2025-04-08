using TEngine;
namespace GameLogic
{
    public class SceneHelper
    {
        
        public static Scene CreateScene(long instanceId,string name,Entity parent=null)
        {
            return new Scene(instanceId,name,parent);
        }
        
        
        public static Scene CreateScene(long id,long instanceId,string name,Entity parent=null)
        {
            return new Scene(id,instanceId,name,parent);
        }
    }
}