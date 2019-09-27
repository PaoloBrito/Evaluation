using System.ComponentModel.DataAnnotations;

namespace apiEval.Models
{
    public enum StateType
    {
        Approved,
        Failed
    }
    public class Grade
    {
        [Key]
        public string Subject { get; set; }
        [Required]
        [Range(0, 100)]
        public int Score { get; set; }
        [Required]
        public StateType State { get; set; }

        [Required]
        public Student Student { get; set; }
    }
}