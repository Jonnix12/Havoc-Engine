using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Voyage_Engine.Game_Engine.ResourcesSystem
{
    public sealed class Resources
    {
        private static FileStream _fileStream;
        private static BinaryFormatter _formatter = new BinaryFormatter();
            
        public static T Load<T>(string path)
        {
            _fileStream = new FileStream(path, FileMode.Open,FileAccess.Read);

            return (T)_formatter.Deserialize(_fileStream);
        }
        
        public static List<T> LoadAll<T>(string path)
        {
            List<T> output = new List<T>();
            
            _fileStream = new FileStream(path, FileMode.Open,FileAccess.Read);

            return (List<T>)_formatter.Deserialize(_fileStream);
        }
    }
}