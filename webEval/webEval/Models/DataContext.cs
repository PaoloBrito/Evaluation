

namespace webEval.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<webEval.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<webEval.Models.Grade> Grades { get; set; }
    }
}