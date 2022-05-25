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
        private readonly IBoughtByInkoService tool;

        public StorageController(IComponentService component, 
            IMaterialsInkoService material, 
            IBoughtByInkoService tool)
        {
            this.component = component;
            this.material = material;
            this.tool = tool;
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

            this.tool.AddTool(model);

            return View("Views/Home/Index.cshtml");
        }
    }
}
