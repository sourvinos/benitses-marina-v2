using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.DocumentTypes {

    public interface IDocumentTypeRepository : IRepository<DocumentType> {

        IEnumerable<DocumentTypeListVM> Get();
        IEnumerable<DocumentTypeBrowserListVM> GetForBrowser();
        Task<DocumentType> GetByIdAsync(int id);

    }

}