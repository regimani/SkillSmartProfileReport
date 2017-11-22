using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSmart.Reporting.ProfileReportLib.Model;
namespace SkillSmart.Reporting.ProfileReportLib.Utility
{
    public class TestDataLibrary
    {
        public static List<JobReference> ReferencesGet()
        {
            List<JobReference> refs = new List<JobReference>();
            refs.Add(new JobReference("John Smith", "Foreman", "test@test.net", "802-123-4567"));
            refs.Add(new JobReference("Prof. John Smith", "Professor", "test@test.net", "802-123-4567"));
            refs.Add(new JobReference("John Smith", "Teacher", "test@test.net", "804-123-4567"));
            return refs;
        }

        public static List<Requisite> RequisitesGet()
        {
            List<Requisite> refs = new List<Requisite>();
            refs.Add(new Requisite("&", "Bachelors Degree"));
            refs.Add(new Requisite("*", "IELTS Clearence with Full Scope"));
            return refs;
        }
    }
}
