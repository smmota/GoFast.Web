using System.ComponentModel.DataAnnotations;

namespace GoFast.UI.DTO
{
    public class DocumentoCarroDTO : DocumentoDTO
    {
        [Required]
        public DateTime Renovacao { get; set; }
    }
}