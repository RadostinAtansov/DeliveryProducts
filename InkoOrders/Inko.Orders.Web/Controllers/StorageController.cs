using Inko.Orders.Web.Models.Storage.Edit;
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

        public IActionResult AddInvoiceToComponent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInvoiceToComponent(AddInvoiceComponentServiceViewModel model)
        {
            string stringFile = UploadFile(model.Picture);

            this.component.AddInvoiceComponent(model, stringFile);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult AddInvoiceToMaterial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInvoiceToMaterial(AddInvoiceMaterialServiceViewModel model)
        {
            string stringFile = UploadFile(model.Picture);

            this.material.AddInvoiceToMaterial(model, stringFile);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult AddInvoiceToWare()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInvoiceToWare(AddInvoiceWareServiceViewModel model)
        {
            string stringFile = UploadFile(model.Picture);

            this.ware.AddInvoiceToWare(model, stringFile);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult AddInvoiceToToolBought()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInvoiceToToolBought(AddInvoiceToolBoughtServiceViewModel model)
        {
            string stringFile = UploadFile(model.Picture);

            this.toolBought.AddInvoiceToToolBought(model, stringFile);

            return View("Views/Home/Index.cshtml");
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

        public IActionResult EditComponent(int id)
        {

            var editComponent = data.Components
                .Select(c => new EditComponentServiceViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    City = c.City,
                    Picture = c.Picture,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    BuyedTime = c.BuyedTime,
                    Comment = c.Comment,
                    PlaceInStorage = c.PlaceInStorage,
                    Insignificant = c.Insignificant,
                })
                .FirstOrDefault(x => x.Id == id);

            return View(editComponent);
        }

        [HttpPost]
        public IActionResult EditComponent(EditComponentServiceViewModel model)
        {
            this.component.Edit(model);

            return View("Views/Home/Index.cshtml");
        }


        public IActionResult EditMaterial(int id)
        {

            var editComponent = data.MaterialsInInko
                .Select(c => new EditMaterialServiceViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    City = c.City,
                    Picture = c.Picture,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    Comment = c.Comment,
                    PlaceInStorage = c.PlaceInStorage,
                    Insignificant = c.Insignificant,
                    
                })
                .FirstOrDefault(x => x.Id == id);

            return View(editComponent);
        }

        [HttpPost]
        public IActionResult EditMaterial(EditMaterialServiceViewModel model)
        {
            this.material.Edit(model);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult EditWare(int id)
        {

            var editComponent = data.WaresInko
                .Select(c => new EditWareServiceViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    City = c.City,
                    Designation = c.Designation,
                    Picture = c.Picture,
                    Quantity = c.Quantity,
                    Comment = c.Comment,
                    PlaceInStorage = c.PlaceInStorage,
                    Insignificant = c.Insignificant,

                })
                .FirstOrDefault(x => x.Id == id);

            return View(editComponent);
        }

        [HttpPost]
        public IActionResult EditWare(EditWareServiceViewModel model)
        {
            this.ware.Edit(model);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult EditToolBought(int id)
        {

            var editComponent = data.TooldBoughtByInko
                .Select(c => new EditToolBoughtServiceViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    City = c.City,
                    Designation = c.Designation,
                    Picture = c.Picture,
                    Quantity = c.Quantity,
                    Comment = c.Comment,
                    PlaceInStorage = c.PlaceInStorage,
                    Insignificant = c.Insignificant,

                })
                .FirstOrDefault(x => x.Id == id);

            return View(editComponent);
        }

        [HttpPost]
        public IActionResult EditToolBought(EditToolBoughtServiceViewModel model)
        {
            this.toolBought.Edit(model);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult EditToolCreated(int id)
        {

            var editComponent = data.ToolCreatedByInko
                .Select(c => new EditToolCreatedServiceViewModel
                {
                    Id = c.Id,
                    CreatedFrom = c.CreatedFrom,
                    TimeWhenCreated = c.TimeWhenCreated,
                    Name = c.Name,
                    City = c.City,
                    Designation = c.Designation,
                    Picture = c.Picture,
                    Quantity = c.Quantity,
                    Comment = c.Comment,
                    PlaceInStorage = c.PlaceInStorage,
                    Insignificant = c.Insignificant,

                })
                .FirstOrDefault(x => x.Id == id);

            return View(editComponent);
        }

        [HttpPost]
        public IActionResult EditToolCreated(EditToolCreatedServiceViewModel model)
        {
            this.toolCreated.Edit(model);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult AddProviderOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProviderOrder(AddProviderServiceViewModel model)
        {
            this.provider.AddProviderOrder(model);

            return View("Views/Home/Index.cshtml");
        }

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

        public IActionResult ShowAllOrders()
        {
            var allOrders = data.ProviderOrders
                .Select(o => new ShowAllOrdersViewModel
                {
                    Id = o.Id,
                    ProviderName = o.ProviderName,
                    Identifier = o.Identifier,
                    Arrived = o.Arrived,
                    ArrivedQuantityAndProductsFromOrder = o.ArrivedQuantityAndProductsFromOrder,
                    ChangeStatusChangeDatetime = o.ChangeStatusChangeDatetime,
                    HowManyProductsOrderedByPosition = o.HowManyProductsOrderedByPosition,
                    OrderDescription = o.OrderDescription,
                    OrderedDate = o.OrderedDate,
                    Price = o.Price,
                    Quantity = o.Quantity,
                    Status = o.Status,
                    URL = o.URL,
                })
                .ToList();

            return View(allOrders);
        }

        public IActionResult ShowAllInvoiceComponents(int id)
        {
            var allInvoices = data.InvoicesStorageComponents
                .Where(x => x.ComponentId == id)
                .Select(x => new ShowAllInvoiceForComponentViewModel
                {
                    Id = x.Id,
                    BoughtFrom = x.BoughtCompanyName,
                    ProductName = x.ProductName,
                    TimeWhenBoughtOnInvoice = x.TimeWhenBoughtOnInvoice,
                    Quantity = x.Qantity,
                    Picture = x.Picture,
                    Comment = x.Comment
                })
                .ToList();

            return View(allInvoices);
        }

        public IActionResult ShowAllInvoiceMaterials(int id)
        {
            var allInvoices = data.InvoicesStorageMaterials
                .Where(x => x.MaterialId == id)
                .Select(x => new ShowAllInvoicesMaterialsViewModel
                {
                    Id = x.Id,
                    BoughtFrom = x.BoughtCompanyName,
                    ProductName = x.ProductName,
                    TimeWhenBoughtOnInvoice = x.TimeWhenBoughtOnInvoice,
                    Quantity = x.Qantity,
                    Picture = x.Picture,
                    Comment = x.Comment
                })
                .ToList();

            return View(allInvoices);
        }

        public IActionResult ShowAllInvoiceWares(int id)
        {
            var allInvoices = data.InvoicesStorageWares
                .Where(x => x.WareInkoId == id)
                .Select(x => new ShowAllInvoicesWareViewModel
                {
                    Id = x.Id,
                    BoughtFrom = x.BoughtCompanyName,
                    ProductName = x.ProductName,
                    TimeWhenBoughtOnInvoice = x.TimeWhenBoughtOnInvoice,
                    Quantity = x.Qantity,
                    Picture = x.Picture,
                    Comment = x.Comment
                })
                .ToList();

            return View(allInvoices);
        }

        public IActionResult ShowAllInvoiceToolBought(int id)
        {
            var allInvoices = data.InvoicesStorageToolBoughtByInkos
                .Where(x => x.ToolBoughtByInkoId == id)
                .Select(x => new ShowAllInvoicesToolBoughtViewModel
                {
                    Id = x.Id,
                    BoughtCompanyName = x.BoughtCompanyName,
                    ProductName = x.ProductName,
                    TimeWhenBoughtOnInvoice = x.TimeWhenBoughtOnInvoice,
                    Quantity = x.Quantity,
                    Picture = x.Picture,
                    Comment = x.Comment
                })
                .ToList();

            return View(allInvoices);
        }

        public IActionResult ShowAllWare()
        {
            var allWares = data.WaresInko
                .Select(w => new ShowAllWareViewModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    Designation = w.Designation,
                    Quantity = w.Quantity,
                    ActiveOrOld = w.ActiveOrOld,
                    TimeActiveAndHowOld = w.TimeActiveAndHowOld,
                    Insignificant = w.Insignificant,
                    Comment = w.Comment,
                    Picture = w.Picture,
                    PlaceInStorage = w.PlaceInStorage,
                    City = w.City
                })
                .ToList();

            return View(allWares);
        }

        [HttpPost]
        public IActionResult ShowAllWare(string search)
        {
            var ware = GetWare(search);

            return View(ware);
        }

        public IActionResult ShowAllMaterials()
        {
            var allMaterials = data.MaterialsInInko
                .Select(m => new ShowAllMaterialViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Designation = m.Designation,
                    Quаntity = m.Quantity,
                    Comment = m.Comment,
                    PlaceInStorage = m.PlaceInStorage,
                    City = m.City,
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
                    Id = c.Id,
                    Name = c.Name,
                    Quantity = c.Quantity,
                    Picture = c.Picture,
                    Designation = c.Designation,
                    Price = c.Price,
                    City = c.City,
                    PlaceInStorage = c.PlaceInStorage,
                    Insignificant = c.Insignificant,
                    Comment = c.Comment,
                    BuyedTime = c.BuyedTime,
                })
                .ToList();
            return View(allComponents);
        }

        public IActionResult DeleteInvoiceComponent(int id)
        {
            var invoice = data.InvoicesStorageComponents.Find(id);

            this.data.InvoicesStorageComponents.Remove(invoice);
            data.SaveChanges();

            return RedirectToAction(nameof(ShowAllComponents));
        }


        public IActionResult DeleteInvoiceMaterial(int id)
        {
            var invoice = data.InvoicesStorageMaterials.Find(id);

            this.data.InvoicesStorageMaterials.Remove(invoice);
            data.SaveChanges();

            return RedirectToAction(nameof(ShowAllMaterials));
        }

        public IActionResult DeleteInvoiceWare(int id)
        {
            var invoice = data.InvoicesStorageWares.Find(id);

            this.data.InvoicesStorageWares.Remove(invoice);
            data.SaveChanges();

            return RedirectToAction(nameof(ShowAllWare));
        }

        public IActionResult DeleteInvoiceToolBought(int id)
        {
            var invoice = data.InvoicesStorageToolBoughtByInkos.Find(id);

            this.data.InvoicesStorageToolBoughtByInkos.Remove(invoice);
            data.SaveChanges();

            return RedirectToAction(nameof(ShowAllWare));
        }

        public IActionResult DeleteComponent(int id)
        {
            var removeThis = this.data.Components.Find(id);

            var componentInvoices = data.InvoicesStorageComponents
                .Where(x => x.ComponentId == id)
                .ToList();


            data.InvoicesStorageComponents.RemoveRange(componentInvoices);
            data.SaveChanges();

            this.data.Components.Remove(removeThis);
            this.data.SaveChanges();

            return RedirectToAction(nameof(ShowAllComponents));
        }

        public IActionResult DeleteMaterial(int id)
        {
            var removeThis = this.data.MaterialsInInko.Find(id);

            this.data.MaterialsInInko.Remove(removeThis);
            this.data.SaveChanges();

            return RedirectToAction(nameof(ShowAllMaterials));
        }

        public IActionResult DeleteProvidersOrder(int id)
        {
            var removeThis = this.data.ProviderOrders.Find(id);

            this.data.ProviderOrders.Remove(removeThis);
            this.data.SaveChanges();

            return RedirectToAction(nameof(ShowAllOrders));
        }

        public IActionResult DeleteCreatedTool(int id)
        {

            var removeThis = this.data.ToolCreatedByInko.Find(id);

            this.data.ToolCreatedByInko.Remove(removeThis);
            this.data.SaveChanges();

            return RedirectToAction(nameof(ShowAllTools));
        }

        public IActionResult DeleteBoughtTool(int id)
        {

            var removeThis = this.data.TooldBoughtByInko.Find(id);

            this.data.TooldBoughtByInko.Remove(removeThis);
            this.data.SaveChanges();

            return RedirectToAction(nameof(ShowAllTools));
        }

        public IActionResult DeleteWare(int id)
        {

            var removeThis = this.data.WaresInko.Find(id);

            this.data.WaresInko.Remove(removeThis);
            this.data.SaveChanges();

            return RedirectToAction(nameof(ShowAllWare));
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
                    Id = tc.Id,
                    Name = tc.Name,
                    CreatedFrom = tc.CreatedFrom,
                    Comment = tc.Comment,
                    Picture = tc.Picture,
                    Insignificant = tc.Insignificant,
                    PlaceInStorage = tc.PlaceInStorage,
                    City = tc.City,
                    Quantity = tc.Quantity,
                    TimeWhenCreated = tc.TimeWhenCreated,
                })
                 .AsEnumerable();


            var AllBought = data.TooldBoughtByInko
            .Select(tc => new ShowAllBoughtToolsViewModel
            {
                Id = tc.Id,
                Name = tc.Name,
                Designation = tc.Designation,
                Comment = tc.Comment,
                Picture = tc.Picture,
                Insignificant = tc.Insignificant,
                PlaceInStorage = tc.PlaceInStorage,
                City = tc.City,
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
                    PlaceInStorage = tc.PlaceInStorage,
                    City = tc.City,
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
                    PlaceInStorage = tc.PlaceInStorage,
                    City = tc.City,
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
                    Id = c.Id,
                    Name = c.Name,
                    Designation = c.Name,
                    Quantity = c.Quantity,
                    Picture = c.Picture,
                    Price = c.Price,
                    PlaceInStorage = c.PlaceInStorage,
                    City = c.City,
                    Insignificant = c.Insignificant,
                    Comment = c.Comment,
                    BuyedTime = c.BuyedTime,
                })
                .AsEnumerable();

            if (!string.IsNullOrEmpty(search))
            {
                allComponents = allComponents.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search) || b.Designation!.ToLower().Contains(search.ToLower()) || b.Designation.Contains(search) || b.Comment!.ToLower().Contains(search.ToLower()) || b.Comment.Contains(search));
            }

            return allComponents;
        }

        private IEnumerable<ShowAllMaterialViewModel> GetMaterials(string search)
        {
            var allMaterials = data.MaterialsInInko
                .Select(m => new ShowAllMaterialViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Designation = m.Designation,
                    Quаntity = m.Quantity,
                    Comment = m.Comment,
                    PlaceInStorage = m.PlaceInStorage,
                    City = m.City,
                    Insignificant = m.Insignificant,
                    Picture = m.Picture,
                    Price = m.Price,
                    TimeInInko = m.TimeInInko,
                })
                .AsEnumerable();

            if (!string.IsNullOrEmpty(search))
            {
                allMaterials = allMaterials.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search) || b.Designation!.ToLower().Contains(search.ToLower()) ||   b.Designation.Contains(search) || b.Comment!.ToLower().Contains(search.ToLower()) || b.Comment.Contains(search));
            }

            return allMaterials;
        }

        private IEnumerable<ShowAllWareViewModel> GetWare(string search)
        {
            var allWares = data.WaresInko
               .Select(w => new ShowAllWareViewModel
               {
                   Name = w.Name,
                   Designation = w.Designation,
                   Quantity = w.Quantity,
                   ActiveOrOld = w.ActiveOrOld,
                   TimeActiveAndHowOld = w.TimeActiveAndHowOld,
                   Insignificant = w.Insignificant,
                   Comment = w.Comment,
                   Picture = w.Picture,
                   PlaceInStorage = w.PlaceInStorage,
                   City = w.City,
               })
               .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                allWares = allWares.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search) || b.Designation!.ToLower().Contains(search.ToLower()) || b.Designation.Contains(search) || b.Comment!.ToLower().Contains(search.ToLower()) || b.Comment.Contains(search));
            }

            return allWares;
        }

        private IEnumerable<ShowAllCreatedToolsViewModel> GetCreated(string search)
        {
            var AllCreated = data.ToolCreatedByInko
            .Select(tc => new ShowAllCreatedToolsViewModel
            {
                Name = tc.Name,
                Designation = tc.Designation,
                CreatedFrom = tc.CreatedFrom,
                Comment = tc.Comment,
                Picture = tc.Picture,
                Insignificant = tc.Insignificant,
                PlaceInStorage = tc.PlaceInStorage,
                City = tc.City,
                Quantity = tc.Quantity,
                TimeWhenCreated = tc.TimeWhenCreated,
            })
             .AsEnumerable();

            if (!string.IsNullOrEmpty(search))
            {
                AllCreated = AllCreated.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search) || b.Designation!.ToLower().Contains(search.ToLower()) || b.Designation.Contains(search) || b.Comment!.ToLower().Contains(search.ToLower()) || b.Comment.Contains(search));
            }

            return AllCreated;
        }

        private IEnumerable<ShowAllBoughtToolsViewModel> GetBought(string search)
        {
            var AllBought = data.TooldBoughtByInko
            .Select(tc => new ShowAllBoughtToolsViewModel
            {
                Name = tc.Name,
                Designation = tc.Designation,
                Comment = tc.Comment,
                Picture = tc.Picture,
                Insignificant = tc.Insignificant,
                PlaceInStorage = tc.PlaceInStorage,
                City = tc.City,
                Quantity = tc.Quantity,
                Bought = tc.Bought,
                BoughtFrom = tc.BoughtFrom,
                TimeBought = tc.TimeBought,
            })
             .AsEnumerable();
            
            if (!string.IsNullOrEmpty(search))
            {
                AllBought = AllBought.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search) || b.Designation!.ToLower().Contains(search.ToLower()) || b.Designation.Contains(search) || b.Comment!.ToLower().Contains(search.ToLower()) || b.Comment.Contains(search));
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
                    Id = c.Id,
                    Name = c.Name,
                    Quantity = c.Quantity,
                    Picture = c.Picture,
                    Price = c.Price,
                    PlaceInStorage = c.PlaceInStorage,
                    City = c.City,
                    Insignificant = c.Insignificant,
                    Comment = c.Comment,
                    BuyedTime = c.BuyedTime,
                })
                .AsEnumerable();

                sws.Components = allComponents;
            
                var allMaterials = data.MaterialsInInko
                    .Select(m => new ShowAllMaterialViewModel
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Quаntity = m.Quantity,
                        Comment = m.Comment,
                        PlaceInStorage = m.PlaceInStorage,
                        City = m.City,
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
                       Id= w.Id,
                       Name = w.Name,
                       Designation = w.Designation,
                       Quantity = w.Quantity,
                       ActiveOrOld = w.ActiveOrOld,
                       TimeActiveAndHowOld = w.TimeActiveAndHowOld,
                       Insignificant = w.Insignificant,
                       Comment = w.Comment,
                       Picture = w.Picture,
                       PlaceInStorage = w.PlaceInStorage,
                       City = w.City,
                   })
                   .AsEnumerable();



                sws.Ware = allWares;

                var AllCreated = data.ToolCreatedByInko
                .Select(tc => new ShowAllCreatedToolsViewModel
                {
                    Id = tc.Id,
                    Name = tc.Name,
                    CreatedFrom = tc.CreatedFrom,
                    Comment = tc.Comment,
                    Picture = tc.Picture,
                    Insignificant = tc.Insignificant,
                    PlaceInStorage = tc.PlaceInStorage,
                    City = tc.City,
                    Quantity = tc.Quantity,
                    TimeWhenCreated = tc.TimeWhenCreated,
                })
                 .AsEnumerable();

               sws.Created = AllCreated;
            

                var AllBought = data.TooldBoughtByInko
                .Select(tc => new ShowAllBoughtToolsViewModel
                {
                    Id = tc.Id,
                    Name = tc.Name,
                    Comment = tc.Comment,
                    Picture = tc.Picture,
                    Insignificant = tc.Insignificant,
                    PlaceInStorage = tc.PlaceInStorage,
                    City = tc.City,
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
