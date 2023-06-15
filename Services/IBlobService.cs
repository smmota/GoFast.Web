using GoFast.UI.DTO;

namespace GoFast.UI.Services
{
    public interface IBlobService
    {
        Task<BlobDTO> GetById(string id);

        Task<String> Create(string base64);

        Task DeleteById(Guid id);
    }
}
