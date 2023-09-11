using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskListName
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }

        //Navigation properties 
        public ICollection<UserTask> UserTasks { get; set; }
    }
}
