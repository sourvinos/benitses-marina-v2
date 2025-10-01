using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Prices {

    [Route("api/[controller]")]
    public class PricesController : ControllerBase {

        #region variables

        private readonly IPriceRepository priceRepo;
        private readonly IPriceValidation priceValidation;

        #endregion

        public PricesController(IPriceRepository priceRepo, IPriceValidation priceValidation) {
            this.priceRepo = priceRepo;
            this.priceValidation = priceValidation;
        }

        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<PriceListVM> Get() {
            return priceRepo.Get();
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<PriceListBrowserVM> GetForBrowser() {
            return priceRepo.GetForBrowser();
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ResponseWithBody> GetByIdAsync(int id) {
            var x = await priceRepo.GetByIdAsync(id, true);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Message = ApiMessages.OK(),
                    Body = PriceMappingDomainToDto.Get(x)
                };
            } else {
                throw new CustomException() {
                    ResponseCode = 404
                };
            }
        }

        [HttpGet("[action]/{code}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ResponseWithBody> GetByCodeAsync(string code) {
            var x = await priceRepo.GetByCodeAsync(code);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Body = PriceMappingDomainToDto.Get(x),
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
        public async Task<ResponseWithBody> PostAsync([FromBody] PriceWriteDto price) {
            var x = priceValidation.IsValidAsync(null, price);
            if (await x == 200) {
                var z = priceRepo.Create((Price)priceRepo.AttachMetadataToPutDto(PriceMappingDtoPostToDomain.Post(price)));
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

        [HttpPut]
        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<ResponseWithBody> PutAsync([FromBody] PriceWriteDto price) {
            var x = await priceRepo.GetByIdAsync(price.Id, false);
            if (x != null) {
                var z = priceValidation.IsValidAsync(x, price);
                if (await z == 200) {
                    var i = priceRepo.Update((Price)priceRepo.AttachMetadataToPutDto(x, PriceMappingDtoPutToDomain.Put(x, price)));
                    return new ResponseWithBody {
                        Code = 200,
                        Icon = Icons.Success.ToString(),
                        Body = i,
                        Message = ApiMessages.OK()
                    };
                } else {
                    throw new CustomException() {
                        ResponseCode = await z
                    };
                }
            } else {
                throw new CustomException() {
                    ResponseCode = 404
                };
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ResponseWithBody> Delete([FromRoute] int id) {
            var x = await priceRepo.GetByIdAsync(id, false);
            if (x != null) {
                priceRepo.Delete(x);
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Body = x,
                    Message = ApiMessages.OK()
                };
            } else {
                throw new CustomException() {
                    ResponseCode = 404
                };
            }
        }

    }

}