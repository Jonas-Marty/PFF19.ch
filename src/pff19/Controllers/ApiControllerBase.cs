using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pff19.Utiles;

namespace pff19.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected int GetUserId()
        {
            var userIdClaim = HttpContext.User.FindFirst(c => c.Type == Constants.UserIdClameType);
            return int.Parse(userIdClaim.Value);
        }
    }
}
