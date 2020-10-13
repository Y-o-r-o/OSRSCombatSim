using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.Models
{
    public class Tab
    {

        public TabTypeModel Type { get; set; }

        public string Png { get { return "../Resources/App/Tab/" + Type.ToString() + ".png"; } }

        public Tab(TabTypeModel type)
        {
            Type = type;
        }
    }
}
