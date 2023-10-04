using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationSalon.Models.Metadata
{
    public class UserMetadata
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Surname { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [Required, MaxLength(150)]
        public string Patronymic { get; set; }
        [Required, MaxLength(50)] 
        public string Login { get; set; }
        [Required, MaxLength(150)]
        public string Password { get; set; }
        [Required]
        public byte[] Photo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "01/01/1900", "04/10/2005", ErrorMessage = "Пользователь должен быть старше 18 лет.")]
        public System.DateTime BirthDate { get; set; }

        [Required]
        public virtual Role Role { get; set; }
    }
}
