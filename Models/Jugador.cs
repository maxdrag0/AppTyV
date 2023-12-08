using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace AppTyV.Models
{


    public class Jugador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Nacimiento { get; set; }

        [Required(ErrorMessage = "El puesto es requerido.")]
        public Puesto Puesto { get; set; }


        [Required(ErrorMessage = "La pierna hábil es requerida.")]
        [EnumDataType(typeof(PiernaHabil))]
        [Display(Name = "Pierna hábil")]
        public PiernaHabil PiernaHabil { get; set; }

        [Required(ErrorMessage = "El sexo es requerido.")]
        [EnumDataType(typeof(Sexo))]
        public Sexo Sexo { get; set; }

        /*[Required(ErrorMessage = "La contraseña es requerida.")]
        public string Contraseña { get; set; }
        */

    }


}
