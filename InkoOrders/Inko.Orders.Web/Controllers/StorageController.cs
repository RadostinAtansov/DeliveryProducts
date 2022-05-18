using InkoOrders.Services;
using InkoOrders.Services.IStorageServices;
using InkoOrders.Services.Model.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Inko.Orders.Web.Controllers
{
    public class StorageController : Controller
    {
        private readonly IComponentService component;
        private readonly IMaterialsInkoService material;

        public StorageController(IComponentService component, IMaterialsInkoService material)
        {
            this.component = component;
            this.material = material;
        }

        public IActionResult AddMaterial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMaterial(AddMaterialsServicesViewModel model)
        {
            this.material.AddMaterials(model);

            return View("Views/Home/Index.cshtml");
        }

        //Make error Page

        public IActionResult AddComponent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComponent(AddComponentServicesViewModel model)
        {

            this.component.AddComponent(model);


            return View("Views/Home/Index.cshtml");
        }
    }
}
