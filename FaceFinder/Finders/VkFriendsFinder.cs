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
            IsReliable = false;
            Output = "Мало друзей";
            base.Find();
        }
    }
}
