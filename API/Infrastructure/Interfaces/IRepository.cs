using System.Collections.Generic;

namespace API.Infrastructure.Interfaces {

    public interface IRepository<T> where T : class {

        T Create(T entity);
        void CreateList(List<T> entities);
        T Update(T entity);
        T SoftDelete(T entity);
        void Delete(T entity);
        IMetadata AttachMetadataToPutDto(IMetadata entity);
        IMetadata AttachMetadataToPutDto(IMetadata existingEntity, IMetadata updatedEntity);

    }

}