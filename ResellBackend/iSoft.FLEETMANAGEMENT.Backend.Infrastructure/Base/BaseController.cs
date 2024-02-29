using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base
{
  
    public class BaseController: ControllerBase
    {
        protected int GetUserId()
        {
            string strUserId = User.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
            try
            {
                var userId = int.Parse(strUserId);
                return userId;
            }
            catch
            {
                throw new InvalidJwtException("Invalid jwt.");
            }
        }
    }
}
