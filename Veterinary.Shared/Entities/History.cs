using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinary.Shared.Entities
{
    public class History
    {


        public int Id { get; set; }


        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "No se permiten más de 50 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }


        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd HH:mm}",ApplyFormatInEditMode = true)]  
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public DateTime Date { get; set; }

        public string Remarks { get; set; }

        public DateTime DateLocal=>Date.ToLocalTime();


        public ServiceType ServiceTypes { get; set; }

        public Pet Pets { get; set; }

    }
}
