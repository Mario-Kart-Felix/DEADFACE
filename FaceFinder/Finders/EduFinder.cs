using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FaceFinder.Data;

namespace FaceFinder.Finders
{
    public class EduFinder : AbstractFinder<IEnumerable<XElement>, Dictionary<string, bool?>>
    {
        public override string Name { get; } = "Образование";
        public override void Find()
        {
            Output = new Dictionary<string, bool?>();
            if (Input.Count(x => x.Elements().Count(y => y.Name.LocalName == "school") != 0) == 0)
            {
                IsReliable = false;
                Output["Среднее образование"] = null;
            }
            if (Input.Count(x=>x.Elements().Count(y=>y.Name.LocalName == "university") != 0) == 0)
            {
                IsReliable = false;
                Output["Высшее образование"] = null;
            }
            base.Find();
        }
    }
}
