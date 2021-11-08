using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.PropertyManagement.Aplication.Dtos
{
    public class PropertyTraceDto
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
        /// Año de construccion de la propiedad
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Identificación del propietario
        /// </summary>
        public string OwnerDocument { get; set; }
        /// <summary>
        /// Volor por el cual se vendio
        /// </summary>
        public decimal? Value { get; set; }
        /// <summary>
        /// Impuesto
        /// </summary>
        public decimal? Tax { get; set; }
        /// <summary>
        /// informacion adicional
        /// </summary>
        public string DataSale { get; set; }
    }
}
