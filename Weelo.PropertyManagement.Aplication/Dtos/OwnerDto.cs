using System;

namespace Weelo.PropertyManagement.Aplication.Dtos
{
    public class OwnerDto
    {
        /// <summary>
        /// Nombre del comprador o propietario
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Direccion
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Numero de documento
        /// </summary>
        public string Document { get; set; }
        /// <summary>
        /// Imagen del comprador (Base64string)
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        public string Birthday { get; set; }
    }
}
