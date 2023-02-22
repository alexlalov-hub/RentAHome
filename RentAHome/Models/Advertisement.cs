using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAHome.Models
{
    public class Advertisement
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public Property Property { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public ApplicationUser Creator { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
