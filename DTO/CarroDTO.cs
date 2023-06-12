using System.ComponentModel.DataAnnotations;

namespace GoFast.UI.DTO
{
    public class CarroDTO
    {
        [Required]
        [MaxLength(7)]
        public string Placa { get; set; }

        [Required]
        [MaxLength(50)]
        public string Modelo { get; set; }

        [Required]
        public DateTime AnoFabricacao { get; set; }

        public DocumentoCarroDTO DocumentoCarro { get; set; }
    }
}