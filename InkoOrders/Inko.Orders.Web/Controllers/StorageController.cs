using InkoOrders.Data;
using Microsoft.AspNetCore.Mvc;
using InkoOrders.Data.Model.Storage;
using InkoOrders.Services.Model.Storage;
using Inko.Orders.Web.Models.Storage.Show;
using InkoOrders.Services.IStorageServices;


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

            if (!ModelState.IsValid)
            {
                return View();
            }

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

            if (!ModelState.IsValid)
            {
                return View();
            }

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

            if (!ModelState.IsValid)
            {
                return View();
            }

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

            if (!ModelState.IsValid)
            {
                return View();
            }

            string stringFile = UploadFile(model.Picture);

            this.toolBought.AddInvoiceToToolBought(model, stringFile);

            return View("Views/Home/Index.cshtml");
        }

        [HttpPost]
        public IActionResult AddMaterial(AddMaterialsServiceViewModel model)
        {
            var toolCheck = data.MaterialsInInko
            .FirstOrDefault(x => x.Name == model.Name);

            if (toolCheck != null)
            {
                ModelState.AddModelError("", "This Name already exist!");
                return View();
            }

            if (model.Quantity > 0)
            {
                var history = new HistoryStorage
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    ReasonTransaction = "Add by User Material",
                    Date = DateTime.Now,
                };
                this.data.HistoryStorages.Add(history);
                this.data.SaveChanges();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

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
                    City = c.City,
                    Name = c.Name,
                    Price = c.Price,
                    Picture = c.Picture,
                    Comment = c.Comment,
                    Quantity = c.Quantity,
                    BuyedTime = c.BuyedTime,
                    Designation = c.Designation,
                    Insignificant = c.Insignificant,
                    PlaceInStorage = c.PlaceInStorage,
                })
                .FirstOrDefault(x => x.Id == id);

            return View(editComponent);
        }

        [HttpPost]
        public IActionResult EditComponent(EditComponentServiceViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            this.component.Edit(model);

            return View("Views/Home/Index.cshtml");
        }


        public IActionResult EditMaterial(int id)
        {

            var editComponent = data.MaterialsInInko
                .Select(c => new EditMaterialServiceViewModel
                {
                    Id = c.Id,
                    City = c.City,
                    Name = c.Name,
                    Price = c.Price,
                    Picture = c.Picture,
                    Comment = c.Comment,
                    Quantity = c.Quantity,
                    Designation = c.Designation,
                    Insignificant = c.Insignificant,
                    PlaceInStorage = c.PlaceInStorage,
                    
                })
                .FirstOrDefault(x => x.Id == id);

            return View(editComponent);
        }

        [HttpPost]
        public IActionResult EditMaterial(EditMaterialServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.material.Edit(model);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult EditWare(int id)
        {

            var editComponent = data.WaresInko
                .Select(c => new EditWareServiceViewModel
                {
                    Id = c.Id,
                    City = c.City,
                    Name = c.Name,
                    Comment = c.Comment,
                    Picture = c.Picture,
                    Quantity = c.Quantity,
                    Designation = c.Designation,
                    Insignificant = c.Insignificant,
                    PlaceInStorage = c.PlaceInStorage,

                })
                .FirstOrDefault(x => x.Id == id);

            return View(editComponent);
        }
        //validaciii na viewtata
        [HttpPost]
        public IActionResult EditWare(EditWareServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.ware.Edit(model);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult EditToolBought(int id)
        {

            var editComponent = data.TooldBoughtByInko
                .Select(c => new EditToolBoughtServiceViewModel
                {
                    Id = c.Id,
                    City = c.City,
                    Name = c.Name,
                    Comment = c.Comment,
                    Picture = c.Picture,
                    Quantity = c.Quantity,
                    Designation = c.Designation,
                    Insignificant = c.Insignificant,
                    PlaceInStorage = c.PlaceInStorage,

                })
                .FirstOrDefault(x => x.Id == id);

            return View(editComponent);
        }

        [HttpPost]
        public IActionResult EditToolBought(EditToolBoughtServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.toolBought.Edit(model);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult EditToolCreated(int id)
        {

            var editComponent = data.ToolCreatedByInko
                .Select(c => new EditToolCreatedServiceViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    City = c.City,
                    Picture = c.Picture,
                    Comment = c.Comment,
                    Quantity = c.Quantity,
                    Designation = c.Designation,
                    CreatedFrom = c.CreatedFrom,
                    Insignificant = c.Insignificant,
                    PlaceInStorage = c.PlaceInStorage,
                    TimeWhenCreated = c.TimeWhenCreated,

                })
                .FirstOrDefault(x => x.Id == id);

            return View(editComponent);
        }

        [HttpPost]
        public IActionResult EditToolCreated(EditToolCreatedServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

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
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.provider.AddProviderOrder(model);

            return View("Views/Home/Index.cshtml");
        }

        public IActionResult AddComponent()
        {
            return View();
        }

        public IActionResult ShowAllHistory()
        {
            var history = this
                .data
                .HistoryStorages
                .Select(cw => new ShowAllHistoryViewModel
                {
                    Name = cw.Name,
                    Quantity = cw.Quantity,
                    DateTransaction = cw.Date,
                    ReasonTransaction = cw.ReasonTransaction,
                })
                .ToList();

            return View(history);
        }

        [HttpPost]
        public IActionResult ShowAllHistory(string searchFrom, string searchTo)
        {
            if (searchFrom == string.Empty || searchTo == string.Empty)
            {
                ModelState.AddModelError("", "You need to write word");
            }

            DateTime dateSearchFrom = Convert.ToDateTime(searchFrom);
            DateTime dateSearchTo = Convert.ToDateTime(searchTo);

            var history = this
                .data
                .HistoryStorages
                .Where(cw => 
                cw.Date.Day >= dateSearchFrom.Day 
                && cw.Date.Day <= dateSearchTo.Day 
                && cw.Date.Month >= dateSearchTo.Month 
                && cw.Date.Month <= dateSearchTo.Month
                && cw.Date.Year >= dateSearchTo.Year 
                && cw.Date.Year <= dateSearchTo.Year)
                .Select(cw => new ShowAllHistoryViewModel
                {
                    Name = cw.Name,
                    Quantity = cw.Quantity,
                    DateTransaction = cw.Date,
                    ReasonTransaction = cw.ReasonTransaction,
                })
                .ToList();

            return View(history);
        }

        [HttpPost]
        public IActionResult AddComponent(AddComponentServiceViewModel model)
        {

            var toolCheck = data.Components
            .FirstOrDefault(x => x.Name == model.Name);

            if (toolCheck != null)
            {
                ModelState.AddModelError("", "This Name already exist!");
                return View();
            }

            if (model.Quantity > 0)
            {
                var history = new HistoryStorage
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    ReasonTransaction = "Add by User Component",
                    Date = DateTime.Now,
                };
                this.data.HistoryStorages.Add(history);
                this.data.SaveChanges();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

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
            var toolCheck = data.TooldBoughtByInko
            .FirstOrDefault(x => x.Name == model.Name);

            if (toolCheck != null)
            {
                ModelState.AddModelError("", "This Name already exist!");
                return View();
            }

            if (model.Quantity > 0)
            {
                var history = new HistoryStorage
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    ReasonTransaction = "Add by User Bought Tool",
                    Date = DateTime.Now,
                };
                this.data.HistoryStorages.Add(history);
                this.data.SaveChanges();
            }



            if (!ModelState.IsValid)
            {
                return View();
            }

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

            var toolCheck = data.ToolCreatedByInko
             .FirstOrDefault(x => x.Name == model.Name);

            if (toolCheck != null)
            {
                ModelState.AddModelError("","This Name already exist!");
                return View();
            }

            if (model.Quantity > 0)
            {
                var history = new HistoryStorage
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    ReasonTransaction = "Add by User Creasted Tool",
                    Date = DateTime.Now,
                };
                this.data.HistoryStorages.Add(history);
                this.data.SaveChanges();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

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
            var toolCheck = data.WaresInko
            .FirstOrDefault(x => x.Name == model.Name);

            if (toolCheck != null)
            {
                ModelState.AddModelError("", "This Name already exist!");
                return View();
            }

            if (model.Quantity > 0)
            {
                var history = new HistoryStorage
                {
                    Name = model.Name,
                    Date = DateTime.Now,
                    Quantity = model.Quantity,
                    ReasonTransaction = "Add by User Ware",
                };
                this.data.HistoryStorages.Add(history);
                this.data.SaveChanges();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

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
                    URL = o.URL,
                    Price = o.Price,
                    Status = o.Status,
                    Arrived = o.Arrived,
                    Quantity = o.Quantity,
                    Identifier = o.Identifier,
                    OrderedDate = o.OrderedDate,
                    ProviderName = o.ProviderName,
                    OrderDescription = o.OrderDescription,
                    ChangeStatusChangeDatetime = o.ChangeStatusChangeDatetime,
                    HowManyProductsOrderedByPosition = o.HowManyProductsOrderedByPosition,
                    ArrivedQuantityAndProductsFromOrder = o.ArrivedQuantityAndProductsFromOrder,
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
                    Picture = x.Picture,
                    Comment = x.Comment,
                    Quantity = x.Qantity,
                    ProductName = x.ProductName,
                    BoughtFrom = x.BoughtCompanyName,
                    TimeWhenBoughtOnInvoice = x.TimeWhenBoughtOnInvoice,
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
                    Picture = x.Picture,
                    Comment = x.Comment,
                    Quantity = x.Qantity,
                    ProductName = x.ProductName,
                    BoughtFrom = x.BoughtCompanyName,
                    TimeWhenBoughtOnInvoice = x.TimeWhenBoughtOnInvoice,
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
                    Comment = x.Comment,
                    Picture = x.Picture,
                    Quantity = x.Qantity,
                    ProductName = x.ProductName,
                    BoughtFrom = x.BoughtCompanyName,
                    TimeWhenBoughtOnInvoice = x.TimeWhenBoughtOnInvoice,
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
                    Picture = x.Picture,
                    Comment = x.Comment,
                    Quantity = x.Quantity,
                    ProductName = x.ProductName,
                    BoughtCompanyName = x.BoughtCompanyName,
                    TimeWhenBoughtOnInvoice = x.TimeWhenBoughtOnInvoice,
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
                    City = w.City,
                    Comment = w.Comment,
                    Picture = w.Picture,
                    Quantity = w.Quantity,
                    ActiveOrOld = w.ActiveOrOld,
                    Designation = w.Designation,
                    Insignificant = w.Insignificant,
                    PlaceInStorage = w.PlaceInStorage,
                    TimeActiveAndHowOld = w.TimeActiveAndHowOld,
                })
                .ToList();

            return View(allWares);
        }

        [HttpPost]
        public IActionResult ShowAllWare(string search, StorageSortingWholeStorageByCriteria StorageSortingWholeStorageByCriteria, StorageSortingByCity sortingByCity)
        {
            var ware = GetWare(search, StorageSortingWholeStorageByCriteria, sortingByCity);

            return View(ware);
        }

        public IActionResult ShowAllMaterials()
        {
            var allMaterials = data.MaterialsInInko
                .Select(m => new ShowAllMaterialViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    City = m.City,
                    Price = m.Price,
                    Comment = m.Comment,
                    Picture = m.Picture,
                    Quаntity = m.Quantity,
                    TimeInInko = m.TimeInInko,
                    Designation = m.Designation,
                    Insignificant = m.Insignificant,
                    PlaceInStorage = m.PlaceInStorage,
                })
                .ToList();

            return View(allMaterials);
        }

        [HttpPost]
        public IActionResult ShowAllMaterials(string search, StorageSortingWholeStorageByCriteria StorageSortingWholeStorageByCriteria, StorageSortingByCity sortingByCity)
        {
            var materials = GetMaterials(search, StorageSortingWholeStorageByCriteria, sortingByCity);

            return View(materials);
        }

        public IActionResult ShowAllComponents()
        {
            var allComponents = data.Components
                .Select(c => new ShowAllComponentsViewModel
                {
                    Id = c.Id,
                    City = c.City,
                    Name = c.Name,
                    Price = c.Price,
                    Picture = c.Picture,
                    Comment = c.Comment,
                    Quantity = c.Quantity,
                    BuyedTime = c.BuyedTime,
                    Designation = c.Designation,
                    Insignificant = c.Insignificant,
                    PlaceInStorage = c.PlaceInStorage,
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
        public IActionResult ShowAllComponents(string search, StorageSortingWholeStorageByCriteria StorageSortingWholeStorageByCriteria, StorageSortingByCity StorageSortingByCity)
        {
            var allComponents = GetComponents(search, StorageSortingWholeStorageByCriteria, StorageSortingByCity);

            return View(allComponents);
        }

        public IActionResult ShowAllTools()
        {
            ShowAllToolsViewModel vm = new ShowAllToolsViewModel();

            var AllCreated = data.ToolCreatedByInko
                .Select(tc => new ShowAllCreatedToolsViewModel
                {
                    Id = tc.Id,
                    Name = tc.Name,
                    City = tc.City,
                    Comment = tc.Comment,
                    Picture = tc.Picture,
                    Quantity = tc.Quantity,
                    CreatedFrom = tc.CreatedFrom,
                    Insignificant = tc.Insignificant,
                    PlaceInStorage = tc.PlaceInStorage,
                    TimeWhenCreated = tc.TimeWhenCreated,
                })
                 .AsEnumerable();


            var AllBought = data.TooldBoughtByInko
            .Select(tc => new ShowAllBoughtToolsViewModel
            {
                Id = tc.Id,
                City = tc.City,
                Name = tc.Name,
                Bought = tc.Bought,
                Comment = tc.Comment,
                Picture = tc.Picture,
                Quantity = tc.Quantity,
                BoughtFrom = tc.BoughtFrom,
                TimeBought = tc.TimeBought,
                Designation = tc.Designation,
                Insignificant = tc.Insignificant,
                PlaceInStorage = tc.PlaceInStorage,
            })
             .AsEnumerable();

            vm.CreatedTools = AllCreated;
            vm.BoughtTools = AllBought;

            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowAllTools(string search, StorageSortingWholeStorageByCriteria StorageSortingWholeStorageByCriteria, StorageSortingByCity StorageSortingByCity)
        {
            ShowAllToolsViewModel sws = new ShowAllToolsViewModel();

            var AllCreated = data.ToolCreatedByInko
                .Select(tc => new ShowAllCreatedToolsViewModel
                {
                    Name = tc.Name,
                    City = tc.City,
                    Comment = tc.Comment,
                    Picture = tc.Picture,
                    Quantity = tc.Quantity,
                    CreatedFrom = tc.CreatedFrom,
                    Insignificant = tc.Insignificant,
                    PlaceInStorage = tc.PlaceInStorage,
                    TimeWhenCreated = tc.TimeWhenCreated,
                })
                 .AsEnumerable();

            var AllBought = data.TooldBoughtByInko
                .Select(tc => new ShowAllBoughtToolsViewModel
                {
                    Name = tc.Name,
                    City = tc.City,
                    Bought = tc.Bought,
                    Comment = tc.Comment,
                    Picture = tc.Picture,
                    Quantity = tc.Quantity,
                    BoughtFrom = tc.BoughtFrom,
                    TimeBought = tc.TimeBought,
                    Insignificant = tc.Insignificant,
                    PlaceInStorage = tc.PlaceInStorage,
                })
                 .AsEnumerable();

            AllBought = StorageSortingByCity switch
            {
                StorageSortingByCity.ChooseCity => AllBought.OrderBy(n =>
                n.Id),
                StorageSortingByCity.Shumen => AllBought.Where(n =>
                n.City == "Shumen"),
                StorageSortingByCity.Varna => AllBought.Where(bt => bt.City ==
                "Varna"),
                StorageSortingByCity.Sofia => AllBought.Where(d => d.City == "Sofia"),
                StorageSortingByCity.Canada => AllBought.Where(p =>
                p.City == "Canada")
            };

            AllBought = StorageSortingWholeStorageByCriteria switch
            {
                StorageSortingWholeStorageByCriteria.ChooseCriteria => AllBought.OrderBy(n =>
                n.Id),
                StorageSortingWholeStorageByCriteria.Name => AllBought.OrderByDescending(n =>
                n.Name),
                StorageSortingWholeStorageByCriteria.TimeAscending => AllBought.OrderBy(bt =>
                bt.TimeBought),
                StorageSortingWholeStorageByCriteria.TimeDescending => AllBought.OrderByDescending(bt =>
                bt.TimeBought),
                StorageSortingWholeStorageByCriteria.QuantityAscending => AllBought.OrderBy(p =>
                p.Quantity),
                StorageSortingWholeStorageByCriteria.QuantityDescending => AllBought.OrderByDescending(p =>
                p.Quantity),
            };

            if (!string.IsNullOrEmpty(search))
            {
                AllBought = AllBought.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search) || b.Designation!.ToLower().Contains(search.ToLower()) || b.Designation.Contains(search) || b.Comment!.ToLower().Contains(search.ToLower()) || b.Comment.Contains(search));
            }

            AllCreated = StorageSortingByCity switch
            {
                StorageSortingByCity.ChooseCity => AllCreated.OrderBy(n =>
                n.Id),
                StorageSortingByCity.Shumen => AllCreated.Where(n =>
                n.City == "Shumen"),
                StorageSortingByCity.Varna => AllCreated.Where(bt => bt.City ==
                "Varna"),
                StorageSortingByCity.Sofia => AllCreated.Where(d => d.City == "Sofia"),
                StorageSortingByCity.Canada => AllCreated.Where(p =>
                p.City == "Canada")
            };

            AllCreated = StorageSortingWholeStorageByCriteria switch
            {
                StorageSortingWholeStorageByCriteria.ChooseCriteria => AllCreated.OrderBy(n =>
                n.Id),
                StorageSortingWholeStorageByCriteria.Name => AllCreated.OrderByDescending(n =>
                n.Name),
                StorageSortingWholeStorageByCriteria.TimeAscending => AllCreated.OrderBy(bt =>
                bt.TimeWhenCreated),
                StorageSortingWholeStorageByCriteria.TimeDescending => AllCreated.OrderByDescending(bt =>
                bt.TimeWhenCreated),
                StorageSortingWholeStorageByCriteria.QuantityAscending => AllCreated.OrderBy(p =>
                p.Quantity),
                StorageSortingWholeStorageByCriteria.QuantityDescending => AllCreated.OrderByDescending(p =>
                p.Quantity)
            };

            if (!string.IsNullOrEmpty(search))
            {
                AllCreated = AllCreated.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search) || b.Designation!.ToLower().Contains(search.ToLower()) || b.Designation.Contains(search) || b.Comment!.ToLower().Contains(search.ToLower()) || b.Comment.Contains(search));
            }

            sws.CreatedTools = AllCreated;
            sws.BoughtTools = AllBought;

            return View(sws);
        }

        public IActionResult ShowWholeStorage()
        {
            var result = AllInOneStorage();

            return View(result);
        }

        [HttpPost]
        public IActionResult ShowWholeStorage(string search, StorageSortingWholeStorageByCriteria StorageSortingWholeStorageByCriteria, StorageSortingByCity StorageSortingByCity)
        {

            ShowWholeStorageViewMoedel sws = new ShowWholeStorageViewMoedel();

            sws.Components = GetComponents(search, StorageSortingWholeStorageByCriteria, StorageSortingByCity);

            sws.Materials = GetMaterials(search, StorageSortingWholeStorageByCriteria, StorageSortingByCity);

            sws.Ware = GetWare(search, StorageSortingWholeStorageByCriteria, StorageSortingByCity);
            sws.Created = GetCreated(search, StorageSortingWholeStorageByCriteria, StorageSortingByCity);
            sws.Bought = GetBought(search, StorageSortingWholeStorageByCriteria, StorageSortingByCity);

            return View(sws);
        }

        private IEnumerable<ShowAllComponentsViewModel> GetComponents([FromQuery]string search, StorageSortingWholeStorageByCriteria sortingByCr, StorageSortingByCity sortingByCity)
        {

            var allComponents = data.Components
                .Select(c => new ShowAllComponentsViewModel
                {
                    Id = c.Id,
                    City = c.City,
                    Name = c.Name,
                    Price = c.Price,
                    Comment = c.Comment,
                    Picture = c.Picture,
                    Quantity = c.Quantity,
                    BuyedTime = c.BuyedTime,
                    Designation = c.Designation,
                    Insignificant = c.Insignificant,
                    PlaceInStorage = c.PlaceInStorage,
                })
                .AsEnumerable();


            allComponents = sortingByCity switch
            {
                StorageSortingByCity.ChooseCity => allComponents.OrderBy(n =>
                n.Id),
                StorageSortingByCity.Shumen => allComponents.Where(n =>
                n.City == "Shumen"),
                StorageSortingByCity.Varna => allComponents.Where(bt => bt.City ==
                "Varna"),
                StorageSortingByCity.Sofia => allComponents.Where(d => d.City == "Sofia"),
                StorageSortingByCity.Canada => allComponents.Where(p =>
                p.City == "Canada")
            };

            allComponents = sortingByCr switch
            {
                StorageSortingWholeStorageByCriteria.ChooseCriteria => allComponents.OrderBy(n =>
                n.Id),
                StorageSortingWholeStorageByCriteria.Name => allComponents.OrderByDescending(n => 
                n.Name),
                StorageSortingWholeStorageByCriteria.TimeAscending => allComponents.OrderBy(bt =>
                bt.BuyedTime),
                StorageSortingWholeStorageByCriteria.TimeDescending => allComponents.OrderByDescending(bt =>
                bt.BuyedTime),
                StorageSortingWholeStorageByCriteria.QuantityAscending => allComponents.OrderBy(p => 
                p.Quantity),
                StorageSortingWholeStorageByCriteria.QuantityDescending => allComponents.OrderByDescending(p =>
                p.Quantity),
                StorageSortingWholeStorageByCriteria.PriceDescending => allComponents.OrderByDescending(p =>
                p.Price),
                StorageSortingWholeStorageByCriteria.PriceAscending => allComponents.OrderBy(p =>
                p.Price),
            };

            if (!string.IsNullOrEmpty(search))
            {
                allComponents = allComponents.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search) || b.Designation!.ToLower().Contains(search.ToLower()) || b.Designation.Contains(search) || b.Comment!.ToLower().Contains(search.ToLower()) || b.Comment.Contains(search));
            }

            return allComponents;
        }

        private IEnumerable<ShowAllMaterialViewModel> GetMaterials(string search, StorageSortingWholeStorageByCriteria StorageSortingWholeStorageByCriteria, 
            StorageSortingByCity sortingByCity)
        {
            var allMaterials = data.MaterialsInInko
                .Select(m => new ShowAllMaterialViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    City = m.City,
                    Price = m.Price,
                    Comment = m.Comment,
                    Picture = m.Picture,
                    Quаntity = m.Quantity,
                    TimeInInko = m.TimeInInko,
                    Designation = m.Designation,
                    Insignificant = m.Insignificant,
                    PlaceInStorage = m.PlaceInStorage,
                })
                .AsEnumerable();

            allMaterials = sortingByCity switch
            {
                StorageSortingByCity.ChooseCity => allMaterials.OrderBy(n =>
                n.Id),
                StorageSortingByCity.Shumen => allMaterials.Where(n =>
                n.City == "Shumen"),
                StorageSortingByCity.Varna => allMaterials.Where(bt => bt.City ==
                "Varna"),
                StorageSortingByCity.Sofia => allMaterials.Where(d => d.City == "Sofia"),
                StorageSortingByCity.Canada => allMaterials.Where(p =>
                p.City == "Canada")
            };

            allMaterials = StorageSortingWholeStorageByCriteria switch
            {
                StorageSortingWholeStorageByCriteria.ChooseCriteria => allMaterials.OrderBy(n =>
                n.Id),
                StorageSortingWholeStorageByCriteria.Name => allMaterials.OrderByDescending(n =>
                n.Name),
                StorageSortingWholeStorageByCriteria.TimeAscending => allMaterials.OrderBy(bt =>
                bt.TimeInInko),
                StorageSortingWholeStorageByCriteria.TimeDescending => allMaterials.OrderByDescending(bt =>
                bt.TimeInInko),
                StorageSortingWholeStorageByCriteria.QuantityAscending => allMaterials.OrderBy(p =>
                p.Quаntity),
                StorageSortingWholeStorageByCriteria.QuantityDescending => allMaterials.OrderByDescending(p =>
                p.Quаntity),
                StorageSortingWholeStorageByCriteria.PriceDescending => allMaterials.OrderByDescending(p =>
                p.Price),
                StorageSortingWholeStorageByCriteria.PriceAscending => allMaterials.OrderBy(p =>
                p.Price),
            };


            if (!string.IsNullOrEmpty(search))
            {
                allMaterials = allMaterials.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search) || b.Designation!.ToLower().Contains(search.ToLower()) ||   b.Designation.Contains(search) || b.Comment!.ToLower().Contains(search.ToLower()) || b.Comment.Contains(search));
            }

            return allMaterials;
        }

        private IEnumerable<ShowAllWareViewModel> GetWare(string search, StorageSortingWholeStorageByCriteria StorageSortingWholeStorageByCriteria, StorageSortingByCity sortingByCity)
        {
            var allWares = data.WaresInko
               .Select(w => new ShowAllWareViewModel
               {
                   Name = w.Name,
                   City = w.City,
                   Comment = w.Comment,
                   Picture = w.Picture,
                   Quantity = w.Quantity,
                   Designation = w.Designation,
                   ActiveOrOld = w.ActiveOrOld,
                   Insignificant = w.Insignificant,
                   PlaceInStorage = w.PlaceInStorage,
                   TimeActiveAndHowOld = w.TimeActiveAndHowOld,
               })
               .AsEnumerable();

            allWares = sortingByCity switch
            {
                StorageSortingByCity.ChooseCity => allWares.OrderBy(n =>
                n.Id),
                StorageSortingByCity.Shumen => allWares.Where(n =>
                n.City == "Shumen"),
                StorageSortingByCity.Varna => allWares.Where(bt => bt.City ==
                "Varna"),
                StorageSortingByCity.Sofia => allWares.Where(d => d.City == "Sofia"),
                StorageSortingByCity.Canada => allWares.Where(p =>
                p.City == "Canada")
            };

            allWares = StorageSortingWholeStorageByCriteria switch
            {
                StorageSortingWholeStorageByCriteria.ChooseCriteria => allWares.OrderBy(n =>
                n.Id),
                StorageSortingWholeStorageByCriteria.Name => allWares.OrderByDescending(n =>
                n.Name),
                StorageSortingWholeStorageByCriteria.TimeAscending => allWares.OrderBy(bt =>
                bt.TimeActiveAndHowOld),
                StorageSortingWholeStorageByCriteria.TimeDescending => allWares.OrderByDescending(bt =>
                bt.TimeActiveAndHowOld),
                StorageSortingWholeStorageByCriteria.QuantityAscending => allWares.OrderBy(p =>
                p.Quantity),
                StorageSortingWholeStorageByCriteria.QuantityDescending => allWares.OrderByDescending(p =>
                p.Quantity),
            };

            if (!string.IsNullOrEmpty(search))
            {
                allWares = allWares.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search) || b.Designation!.ToLower().Contains(search.ToLower()) || b.Designation.Contains(search) || b.Comment!.ToLower().Contains(search.ToLower()) || b.Comment.Contains(search));
            }

            return allWares;
        }

        private IEnumerable<ShowAllCreatedToolsViewModel> GetCreated(string search, StorageSortingWholeStorageByCriteria StorageSortingWholeStorageByCriteria, StorageSortingByCity sortingByCity)
        {
            var AllCreated = data.ToolCreatedByInko
            .Select(tc => new ShowAllCreatedToolsViewModel
            {
                Name = tc.Name,
                City = tc.City,
                Comment = tc.Comment,
                Picture = tc.Picture,
                Quantity = tc.Quantity,
                Designation = tc.Designation,
                CreatedFrom = tc.CreatedFrom,
                Insignificant = tc.Insignificant,
                PlaceInStorage = tc.PlaceInStorage,
                TimeWhenCreated = tc.TimeWhenCreated,
            })
             .AsEnumerable();

            AllCreated = sortingByCity switch
            {
                StorageSortingByCity.ChooseCity => AllCreated.OrderBy(n =>
                n.Id),
                StorageSortingByCity.Shumen => AllCreated.Where(n =>
                n.City == "Shumen"),
                StorageSortingByCity.Varna => AllCreated.Where(bt => bt.City ==
                "Varna"),
                StorageSortingByCity.Sofia => AllCreated.Where(d => d.City == "Sofia"),
                StorageSortingByCity.Canada => AllCreated.Where(p =>
                p.City == "Canada")
            };

            AllCreated = StorageSortingWholeStorageByCriteria switch
            {
                StorageSortingWholeStorageByCriteria.ChooseCriteria => AllCreated.OrderBy(n =>
                n.Id),
                StorageSortingWholeStorageByCriteria.Name => AllCreated.OrderByDescending(n =>
                n.Name),
                StorageSortingWholeStorageByCriteria.TimeAscending => AllCreated.OrderBy(bt =>
                bt.TimeWhenCreated),
                StorageSortingWholeStorageByCriteria.TimeDescending => AllCreated.OrderByDescending(bt =>
                bt.TimeWhenCreated),
                StorageSortingWholeStorageByCriteria.QuantityAscending => AllCreated.OrderBy(p =>
                p.Quantity),
                StorageSortingWholeStorageByCriteria.QuantityDescending => AllCreated.OrderByDescending(p =>
                p.Quantity)
            };

            if (!string.IsNullOrEmpty(search))
            {
                AllCreated = AllCreated.Where(b => b.Name!.ToLower().Contains(search.ToLower()) || b.Name.Contains(search) || b.Designation!.ToLower().Contains(search.ToLower()) || b.Designation.Contains(search) || b.Comment!.ToLower().Contains(search.ToLower()) || b.Comment.Contains(search));
            }

            return AllCreated;
        }

        private IEnumerable<ShowAllBoughtToolsViewModel> GetBought(string search, StorageSortingWholeStorageByCriteria StorageSortingWholeStorageByCriteria, StorageSortingByCity sortingByCity)
        {
            var AllBought = data.TooldBoughtByInko
            .Select(tc => new ShowAllBoughtToolsViewModel
            {
                Name = tc.Name,
                City = tc.City,
                Bought = tc.Bought,
                Comment = tc.Comment,
                Picture = tc.Picture,
                Quantity = tc.Quantity,
                BoughtFrom = tc.BoughtFrom,
                TimeBought = tc.TimeBought,
                Designation = tc.Designation,
                Insignificant = tc.Insignificant,
                PlaceInStorage = tc.PlaceInStorage,
            })
             .AsEnumerable();

            AllBought = sortingByCity switch
            {
                StorageSortingByCity.ChooseCity => AllBought.OrderBy(n =>
                n.Id),
                StorageSortingByCity.Shumen => AllBought.Where(n =>
                n.City == "Shumen"),
                StorageSortingByCity.Varna => AllBought.Where(bt => bt.City ==
                "Varna"),
                StorageSortingByCity.Sofia => AllBought.Where(d => d.City == "Sofia"),
                StorageSortingByCity.Canada => AllBought.Where(p =>
                p.City == "Canada")
            };

            AllBought = StorageSortingWholeStorageByCriteria switch
            {
                StorageSortingWholeStorageByCriteria.ChooseCriteria => AllBought.OrderBy(n =>
                n.Id),
                StorageSortingWholeStorageByCriteria.Name => AllBought.OrderByDescending(n =>
                n.Name),
                StorageSortingWholeStorageByCriteria.TimeAscending => AllBought.OrderBy(bt =>
                bt.TimeBought),
                StorageSortingWholeStorageByCriteria.TimeDescending => AllBought.OrderByDescending(bt =>
                bt.TimeBought),
                StorageSortingWholeStorageByCriteria.QuantityAscending => AllBought.OrderBy(p =>
                p.Quantity),
                StorageSortingWholeStorageByCriteria.QuantityDescending => AllBought.OrderByDescending(p =>
                p.Quantity)
            };

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
                    City = c.City,
                    Name = c.Name,
                    Price = c.Price,
                    Comment = c.Comment,
                    Picture = c.Picture,
                    Quantity = c.Quantity,
                    BuyedTime = c.BuyedTime,
                    Insignificant = c.Insignificant,
                    PlaceInStorage = c.PlaceInStorage,
                })
                .AsEnumerable();

            sws.Components = allComponents;

            var allMaterials = data.MaterialsInInko
                .Select(m => new ShowAllMaterialViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    City = m.City,
                    Price = m.Price,
                    Comment = m.Comment,
                    Picture = m.Picture,
                    Quаntity = m.Quantity,
                    TimeInInko = m.TimeInInko,
                    Insignificant = m.Insignificant,
                    PlaceInStorage = m.PlaceInStorage,
                })
                .AsEnumerable();

            sws.Materials = allMaterials;

            var allWares = data.WaresInko
               .Select(w => new ShowAllWareViewModel
               {
                   Id = w.Id,
                   Name = w.Name,
                   City = w.City,
                   Comment = w.Comment,
                   Picture = w.Picture,
                   Quantity = w.Quantity,
                   ActiveOrOld = w.ActiveOrOld,
                   Designation = w.Designation,
                   Insignificant = w.Insignificant,
                   PlaceInStorage = w.PlaceInStorage,
                   TimeActiveAndHowOld = w.TimeActiveAndHowOld,
               })
               .AsEnumerable();



            sws.Ware = allWares;

            var AllCreated = data.ToolCreatedByInko
            .Select(tc => new ShowAllCreatedToolsViewModel
            {
                Id = tc.Id,
                Name = tc.Name,
                City = tc.City,
                Comment = tc.Comment,
                Picture = tc.Picture,
                Quantity = tc.Quantity,
                CreatedFrom = tc.CreatedFrom,
                Insignificant = tc.Insignificant,
                PlaceInStorage = tc.PlaceInStorage,
                TimeWhenCreated = tc.TimeWhenCreated,
            })
             .AsEnumerable();

            sws.Created = AllCreated;


            var AllBought = data.TooldBoughtByInko
            .Select(tc => new ShowAllBoughtToolsViewModel
            {
                Id = tc.Id,
                Name = tc.Name,
                City = tc.City,
                Bought = tc.Bought,
                Comment = tc.Comment,
                Picture = tc.Picture,
                Quantity = tc.Quantity,
                BoughtFrom = tc.BoughtFrom,
                TimeBought = tc.TimeBought,
                Insignificant = tc.Insignificant,
                PlaceInStorage = tc.PlaceInStorage,
            })
             .AsEnumerable();

            sws.Bought = AllBought;

            return sws;
        }

    }
}
