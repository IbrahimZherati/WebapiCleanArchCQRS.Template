using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebapiCleanArchCQRS.Template.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
       public string? FullName { get; set; }

    }
}
