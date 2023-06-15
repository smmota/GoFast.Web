using GoFast.UI.DTO;
using GoFast.UI.DTO.ViewModel;

namespace GoFast.UI.Services
{
    public interface IMotoristaService
    {
        Task<List<MotoristaViewModel>> GetAll();

        Task<MotoristaViewModel> GetById(string id);

        Task<String> Create(MotoristaDTO motoristaDTO);

        Task DeleteById(Guid id);

        Task Update(MotoristaDTO motoristaDTO);
    }
}
