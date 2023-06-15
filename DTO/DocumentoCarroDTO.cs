using Org.BouncyCastle.Crypto.Digests;
using System.ComponentModel.DataAnnotations;

namespace GoFast.UI.DTO
{
    public class DocumentoCarroDTO : DocumentoDTO
    {
        public DocumentoCarroDTO(DateTime renovacao) : base(Enums.TipoDocumentoEnum.Renavam, "", DateTime.Now)
        {
            Renovacao = renovacao;
        }

        [Required]
        public DateTime Renovacao { get; set; }
    }
}