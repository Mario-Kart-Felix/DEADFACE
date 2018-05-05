using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceFinder.Data;

namespace FaceFinder.Finders
{
    public class VkFriendsFinder : AbstractFinder<VkProfile, string>
    {
        public override string Name { get; } = "Друзья ВКонтакте";
        public override void Find()
        {
            var res = new VkApi.friends_get
            {
                user_id = Input.id
            }.Go();
            int friends = Convert.ToInt32(res["count"]);
            if (friends < 50)
            {
                Output = "Мало друзей: " + friends;
                IsReliable = false;
            }
            else if(friends > 250)
            {
                Output = "Подозрительно много друзей: " + friends;
                IsReliable = false;
            }
            base.Find();
        }
    }
}
