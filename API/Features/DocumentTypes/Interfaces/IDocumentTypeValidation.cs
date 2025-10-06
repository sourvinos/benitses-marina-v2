using API.Infrastructure.Interfaces;

namespace API.Features.DocumentTypes {

    public interface IDocumentTypeValidation : IRepository<DocumentType> {

        int IsValid(DocumentType x, DocumentTypeWriteDto documentType);

    }

}