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
        public DateTime Nascimento { get; set; }

        [Required]
        public EnderecoDTO Endereco { get; set; }

        [Required]
        public CarroDTO Carro { get; set; }

        [Required]
        public BlobDTO Blob { get; set; }

        public MotoristaDTO()
        {
        }

        public MotoristaDTO(string nome, string email, DateTime nascimento, EnderecoDTO endereco, CarroDTO carro, BlobDTO blobDTO)
        {
            Nome = nome;
            Email = email;
            Nascimento = nascimento;
            Endereco = endereco;
            Carro = carro;
            Blob = blobDTO;
        }
    }
}
