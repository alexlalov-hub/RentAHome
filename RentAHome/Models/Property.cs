using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RentAHome.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PropertyTypes Type { get; set; }

        [Required]
        public ICollection<Feature> Features { get; set; }

        [Required]
        public double Area { get; set; }

        public Image Image { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [MaxLength(250)]
        public string Desciption { get; set; }

        [Required]
        public decimal Price { get; set; }

        public enum PropertyTypes
        {
            Apartment,
            House,
            Villa,
            Floor
        }
    }
}
