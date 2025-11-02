namespace ColegioSanJose.Models.ViewModels
{
    public class ExpedienteViewModel
    {
        public int ExpedienteId { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreMateria { get; set; }
        public double NotaFinal { get; set; }
        public string? Observaciones { get; set; }
    }

}
