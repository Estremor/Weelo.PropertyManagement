using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.PropertyManagement.Domain.Base.Contract
{
    /// <summary>
    /// Define los atributos y métodos de un servicio de dominio
    /// </summary>
    public interface IDomainService : IDisposable
    {
        /// <summary>
        /// Asigna el contexto de datos a todos los repositorios del servicio
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        void SetContext(DbContext context);
    }
}
