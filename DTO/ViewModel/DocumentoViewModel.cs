using GoFast.UI.DTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace GoFast.UI.DTO.ViewModel
{
    public class DocumentoViewModel
    {
        public TipoDocumentoEnum TipoDocumento { get; set; }

        public string Numero { get; set; }

        public DateTime Expedicao { get; set; }

        public Guid blobId { get; set; }

        public BlobStorageViewModel BlobStorage { get; set; }

        public DocumentoViewModel(TipoDocumentoEnum tipoDocumento, string numero, DateTime expedicao, BlobStorageViewModel blobStorage)
        {
            TipoDocumento = tipoDocumento;
            Numero = numero;
            Expedicao = expedicao;
            BlobStorage = blobStorage;
        }
    }
}