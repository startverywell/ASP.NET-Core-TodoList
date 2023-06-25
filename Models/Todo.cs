using System.ComponentModel.DataAnnotations;

namespace TodoCRUD.Models
{
    public class Todo
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "name")]
        [StringLength(50)]
        public required string Name { get; set; }

        public short type { get; set; } = 0;
        public short active { get; set; } = 0;
    }

    public class TodoFilter
    {
        public string Name { get; set; } = "";
        public short? active { get; set; }
    }
}
