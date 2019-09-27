

namespace apiEval.Models
{
    using System.Data.Entity;
    public class DataContext: DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<apiEval.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<apiEval.Models.Grade> Grades { get; set; }
    }
}