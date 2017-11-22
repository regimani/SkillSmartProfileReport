namespace SkillSmart.Reporting.ProfileReportLib.Model
{
    public class JobReference
    {
        public string Name { get; set; }

        public string Designation { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public JobReference(string name, string designation, string email, string phone)
        {
            Name = name;
            Designation = designation;
            Email = email;
            Phone = phone;
        }
    }
}
