using System;
using System.Collections.Generic;
using System.Text;
using DeadFace.Data;

namespace DeadFace.Finders
{
    public class VkFinder : AbstractFinder<InputData, object>
    {
        public override void Find()
        {
            base.Find();
            if (Input.phone == null)
                IsReliable = null;
            else
                IsReliable = false;
            Output = "Всё плохо";
        }

        public override string Name { get; } = "Социальная сеть ВКонтакте";
    }
}
