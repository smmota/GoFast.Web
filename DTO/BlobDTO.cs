using System.ComponentModel.DataAnnotations;

namespace GoFast.UI.DTO
{
    public class BlobDTO
    {
        public string Name { get; set; }

        public string imagemBase64 { get; set; }

        public string Link { get; set; }

        public BlobDTO(string name, string imagemBase64, string link)
        {
            Name = name;
            this.imagemBase64 = imagemBase64;
            Link = link;
        }

        public BlobDTO()
        {
        }
    }
}
