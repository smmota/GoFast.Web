using System.ComponentModel.DataAnnotations;

namespace GoFast.UI.DTO
{
    public class EnderecoDTO
    {
        [Required]
        public string Rua { get; set; }

        [Required]
        [Range(0, 20000)]
        public int Numero { get; set; }

        [Required]
        [MaxLength(9)]
        public string CEP { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        public string Complemento { get; set; }

        public EnderecoDTO(string rua, int numero, string cEP, string bairro, string cidade, string estado, string complemento)
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