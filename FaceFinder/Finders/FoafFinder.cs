using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FaceFinder.Finders
{
    public class FoafFinder : AbstractFinder<int, XElement>
    {
        public FoafFinder()
        {
            Children = new AbstractFinder[]
            {
                new EduFinder(),
                new DateFinder(), 
            };
        }
        public override string Name { get; } = null;
        public override void Find()
        {
            var foaf = VkApi.Foaf(Input);
            GetF<EduFinder>().Input = foaf.Elements().FirstOrDefault().Elements().Where(x => x.Name.LocalName == "edu");
            GetF<DateFinder>().Input = foaf.Elements().FirstOrDefault().Elements().Where(x => x.Name.LocalName == "created");
            base.Find();
        }
    }
}
