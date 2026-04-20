using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using SchoolAppCoreMVC.Models;

namespace SchoolAppCoreMVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly SchoolContext _context;

        public ReportController(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult StudentsReport()
        {
            // Lấy dữ liệu từ database
            var students = _context.Students
                .Select(s => new
                {
                    s.StudentID,
                    s.FirstName,
                    s.LastName,
                    s.EnrollmentDate
                })
                .ToList();

            // === SỬA ĐƯỜNG DẪN (quan trọng nhất) ===
            string reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Report", "StudentsReport.rdlc");

            // Kiểm tra file có tồn tại không (giúp debug)
            if (!System.IO.File.Exists(reportPath))
            {
                return Content("Không tìm thấy file report: " + reportPath, "text/plain");
            }

            LocalReport report = new LocalReport();
            report.ReportPath = reportPath;

            // === TÊN DATASET PHẢI KHỚP CHÍNH XÁC ===
            // Bạn mở file StudentsReport.rdlc → right-click Table → Dataset Properties → General → xem ô "Name"
            report.DataSources.Add(new ReportDataSource("DsStudents", students));   // ←←← Thay tên này

            byte[] pdfBytes = report.Render("PDF");

            return File(pdfBytes, "application/pdf", "DanhSachSinhVien.pdf");
        }
    }
}
