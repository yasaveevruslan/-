using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationSalon.Models.Metadata
{
    public class ClientServiceMetadata
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "03/10/2024", "01/01/2028", ErrorMessage = "Тариф можно взять от 1 года до 5 лет")]
        public System.DateTime EndDate { get; set; }
        [Required]
        public virtual Service Service { get; set; }
        [Required]
        public virtual User User { get; set; }

    }
}
