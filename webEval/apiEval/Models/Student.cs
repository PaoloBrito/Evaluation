using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiEval.Models
{
    public enum GenderType
    {
        Male,
        Female,
        Other
    }
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public GenderType Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public int Birthday { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }


}