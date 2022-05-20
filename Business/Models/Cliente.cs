namespace Business.Models
{
    public class Cliente
    {
        public int Id { get; set; }
      
        public int TipoIdentificacion { get; set; }

        public string? NumeroIdentificacion { get; set; }

        public string? RazonSocial { get; set; }

        public int PaisCodigo { get; set; }

        public int DepartamentoCodigo { get; set; }

        public int MunicipioCodigo { get; set; }

    }
}
