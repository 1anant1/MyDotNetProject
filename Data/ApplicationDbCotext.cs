using Microsoft.EntityFrameworkCore;
using Registration_Form.Models;

namespace Registration_Form.Data
{
    public class ApplicationDbCotext : DbContext
    {
        public ApplicationDbCotext(DbContextOptions<ApplicationDbCotext> options) : base(options)
        {

        }

        public DbSet<Registration> Registrations  { get; set; }
        public DbSet<ExamQuestions> ExamQuestions { get; set; }
    }
}
