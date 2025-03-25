namespace TEngine
{
    public class Utility_IdGenerater
    {
        private static int instanceId = 0;//暂时先用这种做法
        public static int GenerateInstanceId()
        {
            instanceId++;
            return instanceId;
        }
    }
}