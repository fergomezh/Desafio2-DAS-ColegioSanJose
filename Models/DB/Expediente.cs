using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ColegioSanJose.Models.DB;

public partial class Expediente
{
    public int ExpedienteId { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un alumno.")]
    public int AlumnoId { get; set; }

    [Required(ErrorMessage = "Debe seleccionar una materia.")]
    public int MateriaId { get; set; }

    [Range(0, 100, ErrorMessage = "La nota final debe estar entre 0 y 100.")]
    public decimal NotaFinal { get; set; }

    [MaxLength(500, ErrorMessage = "Las observaciones no pueden superar los 500 caracteres.")]
    public string? Observaciones { get; set; }

    public virtual Alumno Alumno { get; set; } = null!;

    public virtual Materia Materia { get; set; } = null!;
}
