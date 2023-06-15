using System.ComponentModel.DataAnnotations;

namespace GoFast.UI.DTO.ViewModel
{
    public class CarroViewModel
    {
        public string Placa { get; set; }

        public string Modelo { get; set; }

        public DateTime AnoFabricacao { get; set; }

        public DocumentoCarroViewModel DocumentoCarro { get; set; }
    }
}