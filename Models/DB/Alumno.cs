using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ColegioSanJose.Models.DB
{
    public partial class Alumno
    {
        public int AlumnoId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede superar los 50 caracteres.")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "Debe ingresar una fecha válida.")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateOnly FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El grado es obligatorio.")]
        [StringLength(20, ErrorMessage = "El grado no puede superar los 20 caracteres.")]
        [Display(Name = "Grado")]
        public string Grado { get; set; } = null!;

        public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
    }
}