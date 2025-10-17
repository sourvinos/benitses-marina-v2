using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Sales {

    [Route("api/[controller]")]
    public class SalesController(ISaleRepository repo, ISaleValidation validation) : ControllerBase {

        #region variables

        private readonly ISaleRepository repo = repo;
        private readonly ISaleValidation validation = validation;

        #endregion

        [HttpGet()]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<SaleListVM> Get() {
            return repo.Get();
        }

        [HttpGet("{saleId}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ResponseWithBody> GetByIdAsync(string saleId) {
            var x = await repo.GetByIdAsync(saleId, true);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Body = SaleMappingRead.Read(x),
                    Message = ApiMessages.OK()
                };
            } else {
                throw new CustomException() {
                    ResponseCode = 404
                };
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<ResponseWithBody> PostAsync([FromBody] SaleWriteDto sale) {
            var x = validation.IsValidAsync(null, sale);
            if (await x == 200) {
                var z = repo.Create((Sale)repo.AttachMetadataToPutDto(SaleMappingWrite.Write(sale)));
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Body = z,
                    Message = ApiMessages.OK()
                };
            } else {
                throw new CustomException() {
                    ResponseCode = await x
                };
            }
        }

    }

}