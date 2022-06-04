using Inko.Orders.Web.Models.Storage;
using InkoOrders.Data;
using InkoOrders.Data.Model.Storage;
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
        private readonly InkoOrdersDBContext data;
        public IWebHostEnvironment WebHostEnvironment;

        public StorageController(IComponentService component, 
            IMaterialsInkoService material,
            IBoughtByInkoService toolBought,
            ICreatedByInkoService toolCreated,
            IWareInkoService ware, 
            InkoOrdersDBContext data,
            IWebHostEnvironment webHostEnvironment)
        {
            this.component = component;
            this.material = material;
            this.toolBought = toolBought;
            this.toolCreated = toolCreated;
            this.ware = ware;
            this.data = data;
            this.WebHostEnvironment = webHostEnvironment;
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

        //Make error Page----------------

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
            string stringFile = UploadFile(model);
               
            this.ware.AddWare(model, stringFile);
            return View("Views/Home/Index.cshtml");
        }


        private string UploadFile(AddWareServiceViewModel model)
        {
            string fileName = null;
            if (model.Picture != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + model.Picture.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.Picture.CopyTo(fileStream);
            }
            return fileName;
        }

        public IActionResult ShowAllWare()
        {
            var allWares = data.WaresInko
                .Select(w => new AllWareViewModel
                {
                    Name = w.Name,
                    Quantity = w.Quantity,
                    ActiveOrOld = w.ActiveOrOld,
                    TimeActiveAndHowOld = w.TimeActiveAndHowOld,
                    Insignificant = w.Insignificant,
                    Comment = w.Comment,
                    Picture = w.Picture,
                    PlaceInStorageAndCity = w.PlaceInStorageAndCity,
                })
                .ToList();

            return View(allWares);
        }
    }
}
