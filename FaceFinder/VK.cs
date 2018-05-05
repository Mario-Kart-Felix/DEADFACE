using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace FaceFinder
{
    public abstract class VkApi
    {
        public Newtonsoft.Json.Linq.JToken Go()
        {
            string url = "https://api.vk.com/method/";
            string method = GetType().Name.Replace("_", ".");
            url += method;
            url += "?v=5.8&access_token=2010037d3a49142291a1a4938b53a6988f6fea2b8a8efd33c1c45fe33e7ad72764a28ff6e54f9c4417260&";
            Dictionary<string, object> param = GetType().GetFields().ToDictionary(x => x.Name, x => x.GetValue(this));
            url += string.Join("&", param.Select(x => x.Key + "=" + x.Value).ToArray());
            return SimpleGet.GetJson(url)["response"];
        }
        public static System.Xml.Linq.XElement Foaf(int user_id)
        {
            return SimpleGet.GetXml("https://vk.com/foaf.php?id="+user_id).Root;
        }
        public class users_search : VkApi
        {
            public string q;
            public int city;
            public int birth_day;
            public int birth_month;
        }
        public class friends_get : VkApi
        {
            public int user_id;
        }
    }
}
