using System.ComponentModel.DataAnnotations;

namespace Rock.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Display order must be >0")]
        public int DisplayOrder { get; set; }
    }
}
