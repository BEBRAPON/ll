using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace library
{
    public class Serialize_Deserialize
    {
        public static void Serialize<T>(T data, string filename)
        {
            string json = JsonConvert.SerializeObject(data);
            if (File.Exists(filename))
            {
                File.WriteAllText(filename, json);
            }
            else
            {
                File.Create(filename).Close();
                File.WriteAllText(filename, json);
            }
        }
        public static T Deserialize<T>(string filename)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(filename));
        }
    }
}