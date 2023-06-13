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

        public CarroDTO(string placa, string modelo, DateTime anoFabricacao, DocumentoCarroDTO documentoCarro)
        {
            Placa = placa;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            DocumentoCarro = documentoCarro;
        }
    }
}