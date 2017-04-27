using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.Web.TheStoreCore.Common;
using TheStoreCore.Web.TheStoreCore.Services;

namespace TheStoreCore.Web.TheStoreCore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        

        public CartSummaryViewComponent()
        {
            
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
