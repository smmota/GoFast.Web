using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace GoFast.UI.DTO
{
    public class MotoristaDTO
    {
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public string Nascimento { get; set; }

        [Required]
        public EnderecoDTO Endereco { get; set; }

        [Required]
        public CarroDTO Carro { get; set; }

        public MotoristaDTO()
        {
        }

        public MotoristaDTO(string nome, string email, string nascimento, EnderecoDTO endereco, CarroDTO carro)
        {
            Nome = nome;
            Email = email;
            Nascimento = nascimento;
            Endereco = endereco;
            Carro = carro;
        }
    }
}
