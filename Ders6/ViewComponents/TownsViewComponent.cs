using Ders6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ders6.ViewComponents
{
    public class TownsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var tw = new List<Town>
            {

                new Town{Name="Adalar"},
                new Town{Name="Beşiktaş"},
                new Town{Name="Kadıköy"},
                new Town{Name="Maltepe"},
                new Town{Name="Eyüpsultan"},
                new Town{Name="Bakırköy"},
                new Town{Name="Zeytinburnu"}

            };

            return View(tw);
        }

    }
}
