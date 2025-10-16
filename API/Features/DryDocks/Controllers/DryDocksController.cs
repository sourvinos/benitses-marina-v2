using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.DryDocks {

    [Route("api/[controller]")]
    public class DryDocksController(IDryDockRepository repo, IDryDockValidation validation) : ControllerBase {

        #region variables

        private readonly IDryDockRepository repo = repo;
        private readonly IDryDockValidation validation = validation;

        #endregion

        [HttpGet()]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<DryDockListVM> Get() {
            return repo.Get();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ResponseWithBody> GetByIdAsync(string id) {
            var x = await repo.GetByIdAsync(id, true);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Body = DryDockMappingRead.Get(x),
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
        public async Task<ResponseWithBody> PostAsync([FromBody] DryDockWriteDto writeDto) {
            var x = validation.IsValidAsync(null, writeDto);
            if (await x == 200) {
                var z = repo.Create((DryDock)repo.AttachMetadataToPutDto(DryDockMappingWrite.DtoToDomain(writeDto)));
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
        public async Task<ResponseWithBody> Put([FromBody] DryDockWriteDto writeDto) {
            var x = await repo.GetByIdAsync(writeDto.Id.ToString(), true);
            if (x != null) {
                var z = validation.IsValidAsync(x, writeDto);
                if (await z == 200) {
                    var i = repo.Update((DryDock)repo.AttachMetadataToPutDto(x, DryDockMappingWrite.DtoToDomain(writeDto)));
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

    }

}