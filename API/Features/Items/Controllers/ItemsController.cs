using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Items {

    [Route("api/[controller]")]
    public class ItemsController(IItemRepository itemRepo, IItemValidation itemValidation) : ControllerBase {

        #region variables

        private readonly IItemRepository itemRepo = itemRepo;
        private readonly IItemValidation itemValidation = itemValidation;

        #endregion

        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<ItemListVM> Get() {
            return itemRepo.Get();
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<ItemBrowserListVM> GetForBrowser() {
            return itemRepo.GetForBrowser();
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ResponseWithBody> GetByIdAsync(int id) {
            var x = await itemRepo.GetByIdAsync(id, true);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Message = ApiMessages.OK(),
                    Body = ItemMappingDomainToDto.Get(x)
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
            var x = await itemRepo.GetByCodeAsync(code);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Body = ItemMappingDomainToDto.Get(x),
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
        public async Task<ResponseWithBody> PostAsync([FromBody] ItemWriteDto item) {
            var x = itemValidation.IsValidAsync(null, item);
            if (await x == 200) {
                var z = itemRepo.Create((Item)itemRepo.AttachMetadataToPutDto(ItemMappingDtoPostToDomain.Post(item)));
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
        public async Task<ResponseWithBody> PutAsync([FromBody] ItemWriteDto item) {
            var x = await itemRepo.GetByIdAsync(item.Id, false);
            if (x != null) {
                var z = itemValidation.IsValidAsync(x, item);
                if (await z == 200) {
                    var i = itemRepo.Update((Item)itemRepo.AttachMetadataToPutDto(x, ItemMappingDtoPutToDomain.Put(x, item)));
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
            var x = await itemRepo.GetByIdAsync(id, false);
            if (x != null) {
                itemRepo.Delete(x);
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