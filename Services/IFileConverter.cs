using BlazorInputFile;
using System.Threading.Tasks;

namespace GoFast.UI.Services
{
    public interface IFileConverter
    {
        Task<string> UploadAsync(IFileListEntry arquivo);
    }
}
