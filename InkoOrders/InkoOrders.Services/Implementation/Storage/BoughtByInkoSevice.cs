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
                ProductName = model.ProductName,
                BoughtCompanyName = model.BoughtCompanyName,
                Quantity = model.Quantity,
                TimeWhenBoughtOnInvoice = model.TimeWhenBoughtOnInvoice,
                Comment = model.Comment,
                Picture = path,
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
                Name = tool.Name,
                Bought = true,
                Designation = tool.Designation,
                BoughtFrom = tool.BoughtFrom,
                Comment = tool.Comment,
                Picture = path,
                PlaceInStorage = tool.PlaceInStorage,
                City = tool.City,
                Insignificant = tool.Insignificant,
                Quantity = tool.Quantity,
                TimeBought = tool.TimeBought
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
                    Name = toolBought.Name,
                    Quantity = quantit,
                    ReasonTransaction = "Edit Bought Tool down with",
                    Date = DateTime.Now
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }
            else if (model.Quantity > toolBought.Quantity)
            {
                var quantit = model.Quantity - toolBought.Quantity;

                var history = new HistoryStorage
                {
                    Name = toolBought.Name,
                    Quantity = quantit,
                    ReasonTransaction = "Edit Bought Tool up with",
                    Date = DateTime.Now
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }

            toolBought.Name = model.Name;
            toolBought.Designation = model.Designation;
            toolBought.City = model.City;
            toolBought.PlaceInStorage = model.PlaceInStorage;
            toolBought.Quantity = model.Quantity;
            toolBought.Insignificant = model.Insignificant;
            toolBought.Picture = model.Picture;
            toolBought.Comment = model.Comment;

            data.SaveChanges();
        }
    }
}
