using Ders6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ders6.ViewComponents
{
    public class WeatherViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            var vt = new WeatherInfo
            {
                City = "İstanbul",
                Temperature = "25 C",
                Description = "Guneşli"


            };

            return View(vt);
        }
    }
}
