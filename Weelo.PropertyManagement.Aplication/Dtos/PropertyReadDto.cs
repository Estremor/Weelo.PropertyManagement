using System;

namespace Weelo.PropertyManagement.Aplication.Dtos
{
    /// <summary>
    /// uso unicamente para realizar filtros con ODTA
    /// </summary>
    public class PropertyReadDto
    {
        /// <summary>
        /// Id unico de la propiedad
        /// </summary>
        public Guid IdProperty { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Direccion
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Precio
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Codigo interno
        /// </summary>
        public string CodeInternal { get; set; }
        /// <summary>
        /// Año de creacion
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// propietario
        /// </summary>
        public Guid IdOwner { get; set; }
    }
}
