using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAHome.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public byte[] Bytes { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public Property Property { get; set; }

        public string FileExtension { get; set; }
        public decimal Size { get; set; }
    }
}
