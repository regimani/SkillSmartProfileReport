using System;
using SkillSmart.Reporting.ProfileReportLib;
namespace SkillSmart.Reporting
{
    class Program
    {
        static void Main(string[] args)
        {
            new ProfileReport().Generate();
        }
    }
}
