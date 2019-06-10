using Microsoft.AspNetCore.Mvc;

namespace movieStore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}