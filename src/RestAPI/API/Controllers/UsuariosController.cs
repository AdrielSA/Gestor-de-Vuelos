using API.Responses;
using Domain.CustomEntities;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository repository;
        private readonly ITokenService service;

        public UsuariosController(IUsuarioRepository repository, ITokenService service)
        {
            this.repository = repository;
            this.service = service;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await service.IsValidUser(login);
                    if (result.Item1)
                    {
                        var response = service.GetToken(result.Item2);
                        return Ok(response);
                    }
                    throw new CustomException("Contraseña inválida.");
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

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await repository.AddAsync(usuario);
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
    }
}
