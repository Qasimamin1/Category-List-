
using System.ComponentModel.DataAnnotations;

namespace BulkyBookNew.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int DisplayName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
