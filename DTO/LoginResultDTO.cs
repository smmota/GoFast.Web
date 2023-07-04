namespace GoFast.UI.DTO
{
    public class LoginResultDTO
    {
        public UsuarioResultDTO Usuario { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }

    public class UsuarioResultDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string LoginUser { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public bool Ativo { get; set; }
    }
}
