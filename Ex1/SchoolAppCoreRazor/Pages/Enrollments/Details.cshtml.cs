using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;

namespace SchoolAppCoreRazor.Pages.Enrollments
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolAppCoreRazor.Models.SchoolContext _context;

        public DetailsModel(SchoolAppCoreRazor.Models.SchoolContext context)
        {
            _context = context;
        }

        public Enrollment Enrollment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(m => m.EnrollmentID == id);

            if (enrollment is not null)
            {
                Enrollment = enrollment;

                return Page();
            }

            return NotFound();
        }
    }
}
