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

        public EnderecoViewModel()
        {
        }

        public EnderecoViewModel(string rua, int numero, string cEP, string bairro, string cidade, string estado, string complemento)
        {
            Rua = rua;
            Numero = numero;
            CEP = cEP;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Complemento = complemento;
        }
    }
}