using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Domain.Base
{
    public abstract class DomainService : IDomainService
    {
        #region Methods

        /// <summary>
        /// Asigna el contexto de datos a todos los repositorios del servicio
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public void SetContext(DbContext context)
        {
            //Recorremos todos los miembros privados para reasignar la unidad de trabajo a los repositorios
            var members = GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Where(f => typeof(Contract.IRepository).IsAssignableFrom(f.FieldType) || typeof(IDomainService).IsAssignableFrom(f.FieldType)).ToList();
            for (int i = 0; i < members.Count; i++)
            {
                var val = members[i].GetValue(this);
                if (val != null)
                {
                    if (val is Contract.IRepository)
                        (val as Contract.IRepository).Initialize(context);
                    if (val is IDomainService)
                        (val as IDomainService).SetContext(context);
                }
            }
        }

        /// <summary>
        /// Destruye la instancia
        /// </summary>
        public void Dispose()
        {
            //Recorremos cada miembro privado para destruir su instancia
            var members = GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Where(f => typeof(IDisposable).IsAssignableFrom(f.FieldType)).ToList();
            for (int i = 0; i < members.Count; i++)
            {
                var val = members[i].GetValue(this);
                if (val != null)
                    (val as IDisposable).Dispose();
            }
        }

        #endregion
    }
}
