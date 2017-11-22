using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSmart.Reporting.ProfileReportLib;
namespace ProfileReportTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new ProfileReport().Generate();
        }
    }
}
