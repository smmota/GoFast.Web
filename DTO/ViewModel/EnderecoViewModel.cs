using System.ComponentModel.DataAnnotations;

namespace GoFast.UI.DTO.ViewModel
{
    public class EnderecoViewModel
    {
        public string Rua { get; set; }

        public int Numero { get; set; }

        public string CEP { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Complemento { get; set; }
    }
}