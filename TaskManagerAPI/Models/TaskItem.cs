using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
namespace TaskManagerAPI.Models
{
    public class TaskItem
        {
            [Key]
        public int TaskId { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public TaskStatus Status { get; set; } = TaskStatus.ToDo;

        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        public DateTime? DueDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
