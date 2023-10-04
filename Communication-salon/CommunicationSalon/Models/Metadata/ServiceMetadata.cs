using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationSalon.Models.Metadata
{
    public class ServiceMetadata
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(500)]
        public string Name { get; set; }
        [Required, MaxLength(4000)]
        public string Description { get; set; }
        [Required, Range(150, 5000)]
        public decimal Cost { get; set; }

        [Required]
        public byte[] Photo { get; set; }
    }
}
