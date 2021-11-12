using System;
using System.Net;

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
