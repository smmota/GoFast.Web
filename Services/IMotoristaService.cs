using GoFast.UI.DTO;

namespace GoFast.UI.Services
{
    public interface IMotoristaService
    {
        Task<List<MotoristaDTO>> GetAll();

        Task<MotoristaDTO> GetById(Guid id);

        Task Create(MotoristaDTO motoristaDTO);

        Task DeleteById(Guid id);

        Task Update(MotoristaDTO motoristaDTO);
    }
}
