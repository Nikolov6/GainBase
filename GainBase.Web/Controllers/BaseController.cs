using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GainBase.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string? GetCurrentUserId()
        {
            return User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
