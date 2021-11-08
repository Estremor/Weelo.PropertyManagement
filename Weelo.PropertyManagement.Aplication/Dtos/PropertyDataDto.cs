using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.PropertyManagement.Aplication.Dtos
{
    public class PropertyDataDto
    {
        /// <summary>
        /// Nombre de la propiedad
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Direccion de la propiedad
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Valor de la propiedad
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Codigo Interno para la propiedad
        /// </summary>
        public string CodeInternal { get; set; }
        /// <summary>
        /// Año de construccion de la propiedad
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Identificación del propietario
        /// </summary>
        public string OwnerDocument { get; set; }

        public List<Image> PropertyImages { get; set; }
        public class Image
        {
            /// <summary>
            /// Base64 image
            /// </summary>
            public string File { get; set; }
            /// <summary>
            /// Estado
            /// </summary>
            public bool Enabled { get; set; }
        }
    }
}
