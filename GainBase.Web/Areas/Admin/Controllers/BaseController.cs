using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GainBase.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public abstract class BaseController : Controller
    {
        protected string? GetCurrentUserId()
        {
            return User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
