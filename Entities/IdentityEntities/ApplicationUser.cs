using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.IdentityEntities
{
    //A child class of IdentityUser class
    public class ApplicationUser : IdentityUser<Guid>    {
        public string? PersonName { get; set; } // User name can be diffirent from the Usernmae property of IdentityUser class
    }
}
