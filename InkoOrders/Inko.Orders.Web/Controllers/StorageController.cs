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
        private readonly IProviderOrder provider;
        private readonly InkoOrdersDBContext data;
        public IWebHostEnvironment WebHostEnvironment;

        public StorageController(IComponentService component, 
            IMaterialsInkoService material,
            IBoughtByInkoService toolBought,
            ICreatedByInkoService toolCreated,
            IWareInkoService ware,
            IProviderOrder provider,
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
            this.provider = provider;
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

        //Make error Page----------------------------------------------
        //Make error Page----------------------------------------------
        //Make error Page----------------------------------------------

        public IActionResult AddProviderOrder()
        {
            return View();
        }

        //[HttpPost] ??? where?

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

        [HttpPost]
        public IActionResult ShowAllWare(string search)
        {
            var ware = GetWare(search);
            //if (ware.Count() == 0)
            //{
            //    return View("Views/Storage/NotFoundElement.cshtml");
            //}

            return View(ware);
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

        [HttpPost]
        public IActionResult ShowAllMaterials(string search)
        {
            var materials = GetMaterials(search);

            return View(materials);
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

        [HttpPost]
        public IActionResult ShowAllComponents(string search)
        {
            var components = GetComponents(search);

            return View(components);
        }

        public IActionResult ShowAllTools()
        {
            ShowAllToolsViewModel vm = new ShowAllToolsViewModel();

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

            vm.CreatedTools = AllCreated;
            vm.BoughtTools = AllBought;

            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowAllTools(string search)
        {
            ShowAllToolsViewModel sws = new ShowAllToolsViewModel();

            var AllCreated = data.ToolCreatedByInko
                .Where(c => c.Name!.ToLower() == search.ToLower() || c.Name.Contains(search))
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

            var AllBought = data.TooldBoughtByInko
                .Where(c => c.Name!.ToLower() == search.ToLower() || c.Name.Contains(search))
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

            sws.CreatedTools = AllCreated;
            sws.BoughtTools = AllBought;

            return View(sws);
        }

        public IActionResult ShowWholeStorage()
        {
            var result  = AllInOneStorage();
            
            return View(result);
        }

        [HttpPost]
        public IActionResult ShowWholeStorage(string search)
        {

            ShowWholeStorageViewMoedel sws = new ShowWholeStorageViewMoedel();

            sws.Bought = GetBought(search);
            sws.Created = GetCreated(search);
            sws.Ware = GetWare(search);
            sws.Materials = GetMaterials(search);
            sws.Components = GetComponents(search);

            return View(sws);
        }

        private IEnumerable<ShowAllComponentsViewModel> GetComponents(string search)
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

            if (!string.IsNullOrEmpty(search))
            {
                allComponents = allComponents.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search));
            }

            return allComponents;
        }

        private IEnumerable<ShowAllMaterialViewModel> GetMaterials(string search)
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

            if (!string.IsNullOrEmpty(search))
            {
                allMaterials = allMaterials.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search));
            }

            return allMaterials;
        }

        private IEnumerable<ShowAllWareViewModel> GetWare(string search)
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
               .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                allWares = allWares.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search));
            }

            return allWares;
        }

        private IEnumerable<ShowAllCreatedToolsViewModel> GetCreated(string search)
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

            if (!string.IsNullOrEmpty(search))
            {
                AllCreated = AllCreated.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search));
            }

            return AllCreated;
        }

        private IEnumerable<ShowAllBoughtToolsViewModel> GetBought(string search)
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
            
            if (!string.IsNullOrEmpty(search))
            {
                AllBought = AllBought.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search));
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

        private ShowWholeStorageViewMoedel AllInOneStorage()
        {
            ShowWholeStorageViewMoedel sws = new ShowWholeStorageViewMoedel();


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

                sws.Components = allComponents;
            
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

               sws.Materials = allMaterials;
            
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



                sws.Ware = allWares;

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

               sws.Created = AllCreated;
            

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

                sws.Bought = AllBought;

            return sws;
        }
    }
}
