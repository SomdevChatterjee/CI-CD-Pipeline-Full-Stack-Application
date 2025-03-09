using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerAPI.Models
{
    public class User
    {
        [Key]
        public int UserId{get; set;}
        
        [Required, MaxLength(100)]
        public string FullName {get; set;}
        public string Email {get; set;}

        [Required]
        public string Password {get; set;}

        public ICollection<TaskItem> Tasks {get; set;} = new List<TaskItem>();
    }

}