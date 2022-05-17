using Inko.Orders.Web.Models.Storage;
using InkoOrders.Services;
using InkoOrders.Services.Model.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Inko.Orders.Web.Controllers
{
    public class StorageController : Controller
    {
        private readonly IStorageService storage;

        public StorageController(IStorageService storage)
        {
            this.storage = storage;
        }

        public IActionResult AddComponent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComponent(ComponentViewModel model)
        {

            this.storage.AddComponent(model);


            return View("Views/Home/Index.cshtml");
        }
    }
}
