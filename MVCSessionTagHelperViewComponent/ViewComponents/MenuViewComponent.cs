using Microsoft.AspNetCore.Mvc;
using MVCSessionTagHelperViewComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent.ViewComponents
{
    public class MenuViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new List<MenuViewModel>
            {
                new MenuViewModel
                {
                    ActionName = "Index",
                    ControllerName = "Home",
                    Title= "Anasayfa"
                },
                new MenuViewModel
                {
                  ActionName = "Privacy",
                  ControllerName = "Home",
                  Title = "Gizlilik"
                },
                 new MenuViewModel
                {
                  ActionName = "SetSession",
                  ControllerName = "Session",
                  Title = "Oturum Kaydet"
                },
                  new MenuViewModel
                {
                  ActionName = "GetSession",
                  ControllerName = "Session",
                  Title = "Oturum Getir"
                }
            };

            return View(await Task.FromResult(model));
        }
    }
}
