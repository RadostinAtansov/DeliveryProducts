using Inko.Orders.Web.Models.Storage.Show;
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
            string stringFile = UploadFile(model.Picture);

            this.material.AddMaterials(model, stringFile);

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
            string stringFile = UploadFile(model.Picture);

            this.component.AddComponent(model, stringFile);
            return View("Views/Home/Index.cshtml");
        }

        public IActionResult AddBoughtTool() 
        { 
            return View();
        }
 
        [HttpPost]
        public IActionResult AddBoughtTool(AddBoughtByInkoSeviceViewModel model)
        {
            string stringFile = UploadFile(model.Picture);

            this.toolBought.AddTool(model, stringFile);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult AddCreatedTool()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCreatedTool(AddCreatedByInkoServiceViewModel model)
        {
            string stringFile = UploadFile(model.Picture);

            this.toolCreated.AddCreated(model, stringFile);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult AddWare()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWare(AddWareServiceViewModel model)
        {
            string stringFile = UploadFile(model.Picture);
               
            this.ware.AddWare(model, stringFile);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult ShowAllWare()
        {

            var allWares = data.WaresInko
                .Select(w => new ShowAllWareViewModel
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

        public IActionResult ShowAllMaterials()
        {
            var allMaterials = data.MaterialsInInko
                .Select(m => new ShowAllMaterialViewModel
                {
                    Name = m.Name,
                    Quаntity = m.Quаntity,
                    Comment = m.Comment,
                    PlaceInStorageAndCity = m.PlaceInStorageAndCity,
                    Insignificant = m.Insignificant,
                    Picture = m.Picture,
                    Price = m.Price,
                    TimeInInko = m.TimeInInko,
                })
                .ToList();

            return View(allMaterials);
        }

        public IActionResult ShowAllComponents()
        {
            var allComponents = data.Components
                .Select(c => new ShowAllComponentsViewModel
                {
                    Name = c.Name,
                    Quantity = c.Quantity,
                    Picture = c.Picture,
                    Price = c.Price,
                    PlaceInStorageAndCity = c.PlaceInStorageAndCity,
                    Insignificant = c.Insignificant,
                    Comment = c.Comment,
                    BuyedTime = c.BuyedTime,
                })
                .ToList();
            return View(allComponents);
        }

        public IActionResult ShowAllTools()
        {
            ShowAllToolsViewModel vm = new ShowAllToolsViewModel();
            vm.BoughtTools = GetBought();
            vm.CreatedTools= GetCreated();

            return View(vm);
        }

        private IEnumerable<ShowAllCreatedToolsViewModel> GetCreated()
        {
            var AllCreated = data.ToolCreatedByInko
            .Select(tc => new ShowAllCreatedToolsViewModel
            {
                Name = tc.Name,
                CreatedFrom = tc.CreatedFrom,
                Comment = tc.Comment,
                Picture = tc.Picture,
                Insignificant = tc.Insignificant,
                PlaceInStorageAndCity = tc.PlaceInStorageAndCity,
                Quantity = tc.Quantity,
                TimeWhenCreated = tc.TimeWhenCreated,
            })
            .ToList();

            return AllCreated;
        }

        private IEnumerable<ShowAllBoughtToolsViewModel> GetBought()
        {
            var AllBought = data.TooldBoughtByInko
            .Select(tc => new ShowAllBoughtToolsViewModel
            {
                Name = tc.Name,
                Comment = tc.Comment,
                Picture = tc.Picture,
                Insignificant = tc.Insignificant,
                PlaceInStorageAndCity = tc.PlaceInStorageAndCity,
                Quantity = tc.Quantity,
                Bought = tc.Bought,
                BoughtFrom = tc.BoughtFrom,
                TimeBought = tc.TimeBought,
            })
            .ToList();

            return AllBought;
        }

        private string UploadFile(IFormFile model)
        {
            string fileName = null;
            if (model != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + model.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.CopyTo(fileStream);
            }
            return fileName;
        }
    }
}
