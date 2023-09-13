using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskListName
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }

        public int CompletedTasks { get; set;  }
        public int PendingTasks { get; set; }

        //Navigation properties 
        public ICollection<UserTask> UserTasks { get; set; }

        public TaskListName()
        {
            // Initialize the UserTasks collection to an empty list
            UserTasks = new List<UserTask>();
        }
    }
}
