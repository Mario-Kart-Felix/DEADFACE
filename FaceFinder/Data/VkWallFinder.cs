using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceFinder.Data
{
    public class VkWallFinder : AbstractFinder<VkProfile, object>
    {
        public override string Name { get; } = "Стена ВКонтакте";
        public override void Find()
        {
            IsReliable = false;
            base.Find();
        }
    }
}
