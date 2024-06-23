using Microsoft.AspNetCore.Mvc;

namespace Ders6.ViewComponents
{
    public class SimpleMessageViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            string message = "Merhaba Ben View Component Kullanmayı Öğrendim";

            return View("Default",message);
        }

    }
}
