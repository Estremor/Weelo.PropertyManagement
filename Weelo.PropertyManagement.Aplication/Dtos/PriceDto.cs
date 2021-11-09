using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.PropertyManagement.Aplication.Dtos
{
    public class PriceDto
    {
        /// <summary>
        /// Codigo interno de la propiedad
        /// </summary>
        public string InernalCode { get; set; }
        /// <summary>
        /// Nuevo Precio 
        /// </summary>
        public decimal Price { get; set; }
    }
}
