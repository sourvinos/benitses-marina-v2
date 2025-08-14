using API.Infrastructure.Interfaces;

namespace API.Features.HullTypes {

    public interface IHullTypeValidation : IRepository<HullType> {

        int IsValid(HullType x, HullTypeWriteDto hullType);

    }

}