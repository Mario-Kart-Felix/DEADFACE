using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceFinder.Data
{
    public class VkProfile
    {
        public int id;
        public string first_name;
        public string last_name;

        public VkProfile(Newtonsoft.Json.Linq.JToken user)
        {
            id = Convert.ToInt32(user["id"].ToString());
            first_name = user["first_name"].ToString();
            last_name = user["last_name"].ToString();
        }
    }
}
