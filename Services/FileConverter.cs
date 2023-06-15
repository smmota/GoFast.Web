using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GoFast.UI.Services
{
    public class FileConverter : IFileConverter
    {
        private readonly IWebHostEnvironment _environment;
        public FileConverter(IWebHostEnvironment env)
        {
            _environment = env;
        }

        public async Task<string> UploadAsync(IFileListEntry arquivoEntrada)
        {
            string file;
            var path = Path.Combine(_environment.ContentRootPath, "Uploads",
                    arquivoEntrada.Name);

            var ms = new MemoryStream();

            await arquivoEntrada.Data.CopyToAsync(ms);

            using (FileStream arquivo = new FileStream(path, FileMode.Create,
                FileAccess.Write))
            {
                ms.WriteTo(arquivo);
            }

            Byte[] bytes = File.ReadAllBytes(path);
            file = Convert.ToBase64String(bytes);

            //var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 4096, FileOptions.DeleteOnClose);

            using (FileStream stream = new FileStream(path, FileMode.Truncate, FileAccess.Write, FileShare.Delete, 4096, true))
            {
                stream.Flush();
                File.Delete(path);
            }

            return file;
        }
    }
}
