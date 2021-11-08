using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.PropertyManagement.Domain.Entities
{
    public partial class User
    {
        public Guid IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
