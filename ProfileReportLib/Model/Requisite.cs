using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSmart.Reporting.ProfileReportLib.Model
{
    public class Requisite
    {
        public string Icon { get; set; }

        public string Name { get; set; }

        public Requisite(string icon, string name) {
            Icon = icon;
            Name = name;
        }
    }
}
