using Domain.CustomEntities;
using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITokenService
    {
        LoginResult GetToken(Usuario auth);
        Task<(bool, Usuario)> IsValidUser(Usuario login);
    }
}