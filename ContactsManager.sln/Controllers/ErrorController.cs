using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Controllers
{
    [AllowAnonymous]
    [Route("[Controller]")]
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
