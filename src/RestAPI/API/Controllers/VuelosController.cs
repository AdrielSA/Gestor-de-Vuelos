using API.Responses;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private readonly IVueloRepository repository;
        private readonly HttpContext httpContext;

        public VuelosController(
            IVueloRepository repository,
            IHttpContextAccessor contextAccessor)
        {
            this.repository = repository;
            this.httpContext = contextAccessor.HttpContext;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var rol = httpContext.User.FindFirst(ClaimTypes.Role).Value;
                var result = await repository.GetAllAsync(rol);
                if (result.Any())
                {
                    var response = new ApiResponse<IEnumerable<Vuelo>>
                    {
                        IsSuccess = true,
                        Data = result
                    };
                    return Ok(response);
                }
                return NoContent();
            }
            catch (CustomException ex)
            {
                var error = new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
                return BadRequest(error);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            try
            {
                var result = await repository.GetAsync(id);
                var response = new ApiResponse<Vuelo>
                {
                    IsSuccess = true,
                    Data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var error = new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
                return BadRequest(error);
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody]Vuelo vuelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await repository.AddAsync(vuelo);
                    var response = new ApiResponse { IsSuccess = true };
                    return Ok(response);
                }
                return BadRequest("Modelo inválido.");
            }
            catch (CustomException ex)
            {
                var error = new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
                return BadRequest(error);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody]Vuelo vuelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await repository.UpdateAsync(id, vuelo);
                    var response = new ApiResponse { IsSuccess = true };
                    return Ok(response);
                }
                return BadRequest("Modelo inválido.");
            }
            catch (CustomException ex)
            {
                var error = new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
                return BadRequest(error);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                await repository.DeleteAsync(id);
                var response = new ApiResponse { IsSuccess = true };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var error = new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
                return BadRequest(error);
            }
        }
    }
}
