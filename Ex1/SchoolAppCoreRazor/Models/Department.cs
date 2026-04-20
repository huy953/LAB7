namespace SchoolAppCoreRazor.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
    }
}
