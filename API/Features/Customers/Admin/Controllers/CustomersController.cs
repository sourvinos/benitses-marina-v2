using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Customers.Admin {

    [Route("api/[controller]")]
    public class CustomersController(ICustomerRepository repo, ICustomerValidation validation) : ControllerBase {

        #region variables

        private readonly ICustomerRepository repo = repo;
        private readonly ICustomerValidation validation = validation;

        #endregion

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<CustomerListVM> Get() {
            return repo.Get();
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<CustomerBrowserListVM> GetForBrowser() {
            return repo.GetForBrowser();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ResponseWithBody> GetByIdAsync(int id) {
            var x = await repo.GetByIdAsync(id, true);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Body = CustomerMappingDomainToDto.DomainToDto(x),
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
        public ResponseWithBody Post([FromBody] CustomerWriteDto customer) {
            var x = validation.IsValidAsync(null, customer).Result;
            if (x == 200) {
                var z = repo.Create((Customer)repo.AttachMetadataToPutDto(CustomerMappingDtoToDomain.DtoToDomain(customer)));
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Body = z,
                    Message = ApiMessages.OK()
                };
            } else {
                throw new CustomException() {
                    ResponseCode = x
                };
            }
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<ResponseWithBody> Put([FromBody] CustomerWriteDto customer) {
            var x = await repo.GetByIdAsync(customer.Id, true);
            if (x != null) {
                var z = validation.IsValidAsync(x, customer).Result;
                if (z == 200) {
                    var i = repo.Update((Customer)repo.AttachMetadataToPutDto(x, CustomerMappingDtoToDomain.DtoToDomain(customer)));
                    return new ResponseWithBody {
                        Code = 200,
                        Icon = Icons.Success.ToString(),
                        Body = i,
                        Message = ApiMessages.OK()
                    };
                } else {
                    throw new CustomException() {
                        ResponseCode = z
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
            var x = await repo.GetByIdAsync(id, true);
            if (x != null) {
                repo.Delete(x);
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