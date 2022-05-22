using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class Cliente
    {
        public int Id { get; set; }
     
        [Required(ErrorMessage = "Seleccione una opción")]
        public int TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        public string? NumeroIdentificacion { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        public string? RazonSocial { get; set; }

        [Required(ErrorMessage = "Seleccione un pais")]
        public int PaisCodigo { get; set; }

        [Required(ErrorMessage = "Seleccione un departamento")]
        public int DepartamentoCodigo { get; set; }

        [Required(ErrorMessage = "Seleccione un municipio")]
        public int MunicipioCodigo { get; set; }

        public string? NombreTipoIdentificacion { get; set; }

        public string? Pais { get; set; }

        public string? Departamento { get; set; }

        public string? Municipio { get; set; }

    }
}
