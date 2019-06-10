using Microsoft.AspNetCore.Mvc;

namespace movieStore.Controllers
{
    public abstract class BaseController : Controller
    {
        protected void ShowMessage(string mensagem)
        {
            this.TempData["txt"] = mensagem;
        }
    }
}