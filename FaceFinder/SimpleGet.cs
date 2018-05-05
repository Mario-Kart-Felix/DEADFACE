using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace FaceFinder
{
    public static class SimpleGet
    {
        public static string Get(string request)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(request);
            myRequest.Method = "GET";
            using (WebResponse myResponse = myRequest.GetResponse())
            {
                using (StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.GetEncoding(1251)))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        public static JToken GetJson(string request)
        {
            string s = Get(request);
            if (string.IsNullOrEmpty(s))
                return null;
            return JToken.Parse(s);
        }
        public static System.Xml.Linq.XDocument GetXml(string request)
        {
            string s = Get(request);
            return System.Xml.Linq.XDocument.Parse(s);
        }
    }
}
