using System.ComponentModel.DataAnnotations;

namespace ColegioSanJose.Models.ViewModels
{
    public class ExpedienteViewModel
    {
        public int ExpedienteId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un alumno.")]
        public int AlumnoId { get; set; }

        [Display(Name = "Alumno")]
        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una materia.")]
        public int MateriaId { get; set; }

        [Display(Name = "Materia")]
        public string? NombreMateria { get; set; }

        [Range(0, 100, ErrorMessage = "La nota final debe estar entre 0 y 100.")]
        [Display(Name = "Nota Final")]
        public decimal NotaFinal { get; set; }

        [MaxLength(500, ErrorMessage = "Las observaciones no pueden superar los 500 caracteres.")]
        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }
    }
}