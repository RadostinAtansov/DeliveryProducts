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

        public async Task<IActionResult> ShowWholeStorage(string id)
        {

            ShowWholeStorageViewMoedel sws = new ShowWholeStorageViewMoedel();


            sws.Bought = GetBought(searchString);
            sws.Created = GetCreated(searchString);
            sws.Ware = GetWare(searchString);
            sws.Materials = GetMaterials(searchString);
            sws.Components = GetComponents(searchString);

            return View(sws);
        }

        private IEnumerable<ShowAllComponentsViewModel> GetComponents(string searchString)
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
                .AsEnumerable();

            if (!string.IsNullOrEmpty(searchString))
            {
                allComponents = allComponents.Where(b => b.Name!.Contains(searchString));
            }

            return allComponents;
        }

        private IEnumerable<ShowAllMaterialViewModel> GetMaterials(string searchString)
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
                .AsEnumerable();

            if (!string.IsNullOrEmpty(searchString))
            {
                allMaterials = allMaterials.Where(b => b.Name!.Contains(searchString));
            }

            return allMaterials;
        }

        private IEnumerable<ShowAllWareViewModel> GetWare(string searchString)
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
               .AsEnumerable();

            if (!string.IsNullOrEmpty(searchString))
            {
                allWares = allWares.Where(b => b.Name!.Contains(searchString));
            }

            return allWares;
        }

        public IActionResult ShowAllTools(string searchString)
        {
            ShowAllToolsViewModel vm = new ShowAllToolsViewModel();

            vm.BoughtTools = GetBought(searchString);
            vm.CreatedTools= GetCreated(searchString);

            return View(vm);
        }

        private IEnumerable<ShowAllCreatedToolsViewModel> GetCreated(string searchString)
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
             .AsEnumerable();

            if (!string.IsNullOrEmpty(searchString))
            {
                AllCreated = AllCreated.Where(b => b.Name!.Contains(searchString));
            }

            return AllCreated;
        }

        private IEnumerable<ShowAllBoughtToolsViewModel> GetBought(string searchString)
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
             .AsEnumerable();

            if (!string.IsNullOrEmpty(searchString))
            {
                AllBought = AllBought.Where(b => b.Name!.Contains(searchString));
            }

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
