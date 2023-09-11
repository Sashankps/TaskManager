using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class UserTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        //Navigation properties 
        //Foreign key property to link to a TaskListName
        public int TaskListNameId { get; set; }

        //Navigation property to represent TaskList
        public TaskListName TaskListName { get; set; }
    }
}
