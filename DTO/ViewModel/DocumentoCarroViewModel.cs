using System.ComponentModel.DataAnnotations;

namespace GoFast.UI.DTO.ViewModel
{
    public class DocumentoCarroViewModel : DocumentoViewModel
    {
        public DocumentoCarroViewModel(DateTime renovacao) : base(Enums.TipoDocumentoEnum.Renavam, "", DateTime.Now, new BlobStorageViewModel())
        {
            Renovacao = renovacao;
        }

        [Required]
        public DateTime Renovacao { get; set; }
    }
}