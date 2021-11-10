using System.Threading.Tasks;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Domain.Services.Contracts
{
    public interface ILoginDomainService : IDomainService
    {
        #region Contarct
        /// <summary>
        /// verifica si existe un usuario con los datos proporcionados
        /// </summary>
        /// <param name="user"></param>
        /// <returns>usuario</returns>
        Task<User> FindUserAsync(User user);
        /// <summary>
        /// Crea token para autenticación
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string CreateToken(User user);
        #endregion
    }
}
