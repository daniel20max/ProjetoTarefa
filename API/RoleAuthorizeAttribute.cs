using Microsoft.AspNetCore.Authorization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTarefa.API
{
    public class RoleAuthorizeAttribute : AuthorizeAttribute
    {
        public RoleAuthorizeAttribute(params RoleTypes[] r)
        {
            var roles = r.Select(x => Enum.GetName(typeof(RoleTypes), x));
            Roles = string.Join(",", roles);
        }
    }
}
