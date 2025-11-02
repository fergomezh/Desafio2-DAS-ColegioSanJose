using System;
using System.Collections.Generic;

namespace ColegioSanJose.Models.DB;

public partial class Materia
{
    public int MateriaId { get; set; }

    public string NombreMateria { get; set; } = null!;

    public string Docente { get; set; } = null!;

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
}
