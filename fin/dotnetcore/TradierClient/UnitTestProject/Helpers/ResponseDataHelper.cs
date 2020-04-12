using Newtonsoft.Json;

//using System.Xml.Serialization;
//using System.IO;

namespace UnitTestProject.Helpers
{
    public class ResponseDataHelper
    {
        public static T DeserializeStringToJson<T>(string data) where T : class
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        // TODO: Implement DeserializeXmlResponse<T>
    }
}
