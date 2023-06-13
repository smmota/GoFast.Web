using GoFast.UI.DTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace GoFast.UI.DTO
{
    public class DocumentoDTO
    {
        public TipoDocumentoEnum TipoDocumento { get; set; }

        [Required]
        [MaxLength(30)]
        public string Numero { get; set; }

        [Required]
        public DateTime Expedicao { get; set; }

        [Required]
        public Guid IdBlob { get; set; }

        public DocumentoDTO(TipoDocumentoEnum tipoDocumento, string numero, DateTime expedicao, Guid idBlob)
        {
            TipoDocumento = tipoDocumento;
            Numero = numero;
            Expedicao = expedicao;
            IdBlob = idBlob;
        }
    }
}