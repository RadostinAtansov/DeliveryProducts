using Inko.Orders.Web.Models.Storage;
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
        private readonly IBoughtByInkoService toolBought;
        private readonly ICreatedByInkoService toolCreated;
        private readonly IWareInkoService ware;

        public StorageController(IComponentService component, 
            IMaterialsInkoService material,
            IBoughtByInkoService toolBought,
            ICreatedByInkoService toolCreated,
            IWareInkoService ware)
        {
            this.component = component;
            this.material = material;
            this.toolBought = toolBought;
            this.toolCreated = toolCreated;
            this.ware = ware;
        }

        public IActionResult AddMaterial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMaterial(AddMaterialsServiceViewModel model)
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
        public IActionResult AddComponent(AddComponentServiceViewModel model)
        {

            this.component.AddComponent(model);


            return View("Views/Home/Index.cshtml");
        }

        public IActionResult AddBoughtTool() 
        { 
            return View();
        }
 
        [HttpPost]
        public IActionResult AddBoughtTool(AddBoughtByInkoSeviceViewModel model)
        {

            this.toolBought.AddTool(model);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult AddCreatedTool()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCreatedTool(AddCreatedByInkoServiceViewModel model)
        {
            this.toolCreated.AddCreated(model);
            return View("Views/Home/Index.cshtml");
        }

        public IActionResult AddWare()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWare(AddWareServiceViewModel model)
        {
            this.ware.AddWare(model);
            return View("Views/Home/Index.cshtml");
        }
    }
}
