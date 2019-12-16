using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class JsonConvertor: IJsonConvertor
    {
        public T UpLoad<T>(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                using(JsonTextReader jr = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jr);
                }
            }
        }

        public void Save<T>(T item, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                using (JsonTextWriter jw = new JsonTextWriter(sw))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(jw, item);
                }
            }
        }
    }
}
