using InkoOrders.Data;
using InkoOrders.Services.IStorageServices;
using InkoOrders.Services.Model.Storage;
using InkoOrders.Data.Model.Storage;

namespace InkoOrders.Services.Implementation
{
    public class MaterialsInkoService : IMaterialsInkoService
    {

        private readonly InkoOrdersDBContext data;

        public MaterialsInkoService(InkoOrdersDBContext data)
        {
            this.data = data;
        }

        public void AddInvoiceToMaterial(AddInvoiceMaterialServiceViewModel model, string path)
        {
            var material = data.MaterialsInInko.Find(model.Id);

            if (material == null)
            {
                throw new NullReferenceException("Can`t add Invoice to material that not exist!");
            }

            var invoice = new InvoicesStorageMaterial
            {
                Picture = path,
                Comment = model.Comment,
                Qantity = model.Qantity,
                ProductName = model.ProductName,
                BoughtCompanyName = model.BoughtCompanyName,
                TimeWhenBoughtOnInvoice = model.TimeWhenBoughtOnInvoice,
            };

            material.Quantity += model.Qantity;

            material.InvoicesMaterial.Add(invoice);
            data.SaveChanges();
        }

        public void AddMaterials(AddMaterialsServiceViewModel material, string path)
        {
            var mtr = new MaterialsInInko()
            {
                Picture = path,
                Name = material.Name,
                City = material.City,
                Price = material.Price,
                TimeInInko = DateTime.Now,
                Comment = material.Comment,
                Quantity = material.Quantity,
                Designation = material.Designation,
                Insignificant = material.Insignificant,
                PlaceInStorage = material.PlaceInStorage,
            };

            data.MaterialsInInko.Add(mtr);
            data.SaveChanges();
        }

        public void Edit(EditMaterialServiceViewModel model)
        {
            var material = data.MaterialsInInko
                 .Find(model.Id);

            if (model.Quantity < material.Quantity)
            {
                var quantit = material.Quantity - model.Quantity;

                var history = new HistoryStorage
                {
                    Quantity = quantit,
                    Date = DateTime.Now,
                    Name = material.Name,
                    ReasonTransaction = "Edit Material down with",
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }
            else if (model.Quantity > material.Quantity)
            {
                var quantit = model.Quantity - material.Quantity;

                var history = new HistoryStorage
                {
                    Quantity = quantit,
                    Date = DateTime.Now,
                    Name = material.Name,
                    ReasonTransaction = "Edit Material up with",
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }

            material.Name = model.Name;
            material.City = model.City;
            material.Price = model.Price;
            material.Picture = model.Picture;
            material.Comment = model.Comment;
            material.Quantity = model.Quantity;
            material.Designation = model.Designation;
            material.PlaceInStorage = model.PlaceInStorage;
            material.Insignificant = model.Insignificant;

            data.SaveChanges();
        }
    }
}