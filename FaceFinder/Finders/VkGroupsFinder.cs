using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceFinder.Data;

namespace FaceFinder.Finders
{
    public class VkGroupsFinder : AbstractFinder<VkProfile, object>
    {
        public override string Name { get; } = "Группы ВКонтакте";
        public override void Find()
        {
            base.Find();
        }
    }
}
