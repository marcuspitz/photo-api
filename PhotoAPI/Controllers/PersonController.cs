using System;
using System.Threading.Tasks;
using Interface.services;
using Interface.viewmodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PhotoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(ILogger<PersonController> logger, IPersonService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new
            {
                success = true,
                data = await this._service.GetAll()
            }
            );
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(Guid Id)
        {
            return Ok(new
            {
                success = true,
                data = await this._service.GetById(Id)
            }
            );
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]PersonViewModel model)
        {
            var vModel = await this._service.Add(model);
            if (vModel != null)
                return Ok(new
                {
                    success = true,
                    data = vModel
                }
                );
            else
                return Ok(new
                {
                    success = false,
                }
                );
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]PersonViewModel model)
        {
            var vModel = await this._service.Update(model);
            if (vModel != null)
                return Ok(new
                {
                    success = true,
                    data = vModel
                }
                );
            else
                return Ok(new
                {
                    success = false,
                }
                );
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove([FromBody]PersonViewModel model)
        {
            return Ok(new
            {
                success = await _service.Remove(model),
                data = model
            }
            );
        }
    }
}
