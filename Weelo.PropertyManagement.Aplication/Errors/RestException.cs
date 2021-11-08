using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.PropertyManagement.Aplication.Errors
{
    public class RestException : Exception
    {
        public readonly HttpStatusCode Code;
        public readonly object Errors;
        public RestException(HttpStatusCode code, object errors = null)
        {
            this.Code = code;
            this.Errors = errors;
        }
    }
}
