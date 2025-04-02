using System.IO;

namespace GameLogic
{
    public class SaveModule:Singleton<UIModule>
    {

        protected override void OnInit()
        {
            
        }

        protected override void OnRelease()
        {
            
        }


        public void SaveSpecificData(string fileName,string content)
        {
            //   string path = GetSaveDataPath(fileName);
            string path = fileName;
#if UNITY_EDITOR
            string directoryPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
#endif
            File.WriteAllText(path, content);
        }
    }
}