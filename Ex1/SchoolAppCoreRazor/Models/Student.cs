namespace SchoolAppCoreRazor.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
    }
}
