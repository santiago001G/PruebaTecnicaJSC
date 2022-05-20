namespace PruebaTecnicaJSC.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        public int TipoIdentificacion { get; set; }

        public string? NumeroIdentificacion { get; set; }

        public string? RazonSocial { get; set; }

        public int PaisCodigo { get; set; }

        public int DepartamentoCodigo { get; set; }

        public int MunicipioCodigo { get; set; }

        public string? NombreTipoIdentificacion { get; set; }

        public string? Pais { get; set; }

        public string? Departamento { get; set; }

        public string? Municipio { get; set; }
    }
}
