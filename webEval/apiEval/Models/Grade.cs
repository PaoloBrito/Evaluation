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
        [Required]
        public string Subject { get; set; }
        [Required]
        [Range(0, 100)]
        public int Score { get; set; }
        [Required]
        public StateType State { get; set; }

        public Student Student { get; set; }
    }
}