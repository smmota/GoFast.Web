using GoFast.UI.DTO;

namespace GoFast.UI.Services.Authentication
{
    public interface IAuthService
    {
        Task<LoginResultDTO> Login(LoginDTO loginDTO);
        Task Logout();
        Task<RegisterResultDTO> Register(RegisterDTO registerDTO);
        Task<string> GetTokenAsync();
    }
}
