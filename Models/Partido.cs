using AppTyV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppTyV

{
    public class Partido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "El lugar es requerido.")]
        public required string Lugar { get; set; }

        [Required(ErrorMessage = "La fecha es requerida.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
        [Required]
        public DateTime Hora { get; set; }

        [Required(ErrorMessage = "El número de jugadores es requerido.")]
        [Range(1, MaximoJugadores, ErrorMessage = "El número de jugadores debe estar entre 1 y 10")]
        [Display(Name = "Total de jugadores")]
        public int TotalJugadores { get; set; }

        [Required]
        [EnumDataType(typeof(Tipo))]
        public Tipo Tipo { get; set; }

        [Required]
        [EnumDataType(typeof(Estado))]
        public Estado Estado { get; set; }

        public const int MaximoJugadores = 10;



    }
}
