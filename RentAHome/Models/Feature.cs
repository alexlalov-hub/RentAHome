using System.ComponentModel.DataAnnotations;

namespace RentAHome.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
