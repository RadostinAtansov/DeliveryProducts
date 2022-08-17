using InkoOrders.Data;
using InkoOrders.Services.IStorageServices;
using InkoOrders.Services.Model.Storage;
using InkoOrders.Data.Model.Storage;

namespace InkoOrders.Services.Implementation.Storage
{
    public class BoughtByInkoSevice : IBoughtByInkoService
    {
        private readonly InkoOrdersDBContext data;

        public BoughtByInkoSevice(InkoOrdersDBContext data)
        {
            this.data = data;
        }

        public void AddInvoiceToToolBought(AddInvoiceToolBoughtServiceViewModel model, string path)
        {
            var toolBought = data.TooldBoughtByInko.Find(model.Id);

            if (toolBought == null)
            {
                throw new NullReferenceException("Can`t add Invoice to tool that not exist!");
            }

            var invoice = new InvoicesStorageToolBoughtByInko
            {
                Picture = path,
                Comment = model.Comment,
                Quantity = model.Quantity,
                ProductName = model.ProductName,
                BoughtCompanyName = model.BoughtCompanyName,
                TimeWhenBoughtOnInvoice = model.TimeWhenBoughtOnInvoice,
            };

            toolBought.Quantity += model.Quantity;

            toolBought.InvoicesToolsBoughtByInko.Add(invoice);
            data.SaveChanges();
        }

        public void AddTool(AddBoughtByInkoSeviceViewModel tool, string path)
        {
            var toolCheck = data.TooldBoughtByInko
                .FirstOrDefault(x => x.Name == tool.Name);

            var tul = new ToolBoughtByInko()
            {
                Bought = true,
                Picture = path,
                City = tool.City,
                Name = tool.Name,
                Comment = tool.Comment,
                Quantity = tool.Quantity,
                TimeBought = tool.TimeBought,
                BoughtFrom = tool.BoughtFrom,
                Designation = tool.Designation,
                PlaceInStorage = tool.PlaceInStorage,
                Insignificant = tool.Insignificant,
            };

            data.TooldBoughtByInko.Add(tul);
            data.SaveChanges();
        }

        public void Edit(EditToolBoughtServiceViewModel model)
        {
            var toolBought = data.TooldBoughtByInko
                 .Find(model.Id);

            if (model.Quantity < toolBought.Quantity)
            {
                var quantit = toolBought.Quantity - model.Quantity;

                var history = new HistoryStorage
                {
                    Quantity = quantit,
                    Date = DateTime.Now,
                    Name = toolBought.Name,
                    ReasonTransaction = "Edit Bought Tool down with",
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }
            else if (model.Quantity > toolBought.Quantity)
            {
                var quantit = model.Quantity - toolBought.Quantity;

                var history = new HistoryStorage
                {
                    Quantity = quantit,
                    Date = DateTime.Now,
                    Name = toolBought.Name,
                    ReasonTransaction = "Edit Bought Tool up with",
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }

            toolBought.Name = model.Name;
            toolBought.City = model.City;
            toolBought.Picture = model.Picture;
            toolBought.Comment = model.Comment;
            toolBought.Quantity = model.Quantity;
            toolBought.Designation = model.Designation;
            toolBought.Insignificant = model.Insignificant;
            toolBought.PlaceInStorage = model.PlaceInStorage;

            data.SaveChanges();
        }
    }
}
