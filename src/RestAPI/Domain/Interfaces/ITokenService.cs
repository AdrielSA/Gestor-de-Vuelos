using Domain.CustomEntities;
using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITokenService
    {
        LoginResponse GetToken(Usuario auth);
        Task<(bool, Usuario)> IsValidUser(LoginRequest login);
    }
}