using System.ComponentModel.DataAnnotations;

namespace GoFast.UI.DTO.ViewModel
{
    public class MotoristaViewModel
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime Nascimento { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        public CarroViewModel Carro { get; set; }

        public Guid idEnderecoRefMotorista { get; set; }

        public Guid idCarroRefMotorista { get; set; }

        public MotoristaViewModel()
        {
        }

        public MotoristaViewModel(string nome, string email, DateTime nascimento, EnderecoViewModel endereco, CarroViewModel carro)
        {
            Nome = nome;
            Email = email;
            Nascimento = nascimento;
            Endereco = endereco;
            Carro = carro;
        }
    }
}
