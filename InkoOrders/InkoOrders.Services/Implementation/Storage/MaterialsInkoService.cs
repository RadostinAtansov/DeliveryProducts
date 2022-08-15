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
                ProductName = model.ProductName,
                BoughtCompanyName = model.BoughtCompanyName,
                Qantity = model.Qantity,
                TimeWhenBoughtOnInvoice = model.TimeWhenBoughtOnInvoice,
                Comment = model.Comment,
                Picture = path,
            };

            material.Quantity += model.Qantity;

            material.InvoicesMaterial.Add(invoice);
            data.SaveChanges();
        }

        public void AddMaterials(AddMaterialsServiceViewModel material, string path)
        {
            if (string.IsNullOrEmpty(material.Name))
            {
                throw new ArgumentException("Name can`t be empty");
            }

            var materialCheck = data.MaterialsInInko
                   .FirstOrDefault(x => x.Name == material.Name);

            if (materialCheck != null)
            {
                throw new ArgumentException("Can`t add same material!");
            }

            var mtr = new MaterialsInInko()
            {
                Name = material.Name,
                Designation = material.Designation,
                Price = material.Price,
                TimeInInko = DateTime.Now,
                Picture = path,
                Comment = material.Comment,
                Quantity = material.Quantity,
                Insignificant = material.Insignificant,
                PlaceInStorage = material.PlaceInStorage,
                City = material.City,
            };

            data.MaterialsInInko.Add(mtr);
            data.SaveChanges();
        }

        public void Edit(EditMaterialServiceViewModel model)
        {
            var material = data.MaterialsInInko
                 .Find(model.Id);

            if (string.IsNullOrWhiteSpace(material.Designation))
            {
                throw new NullReferenceException("Designation can`t be null");
            }

            if (model.Quantity < material.Quantity)
            {
                var quantit = material.Quantity - model.Quantity;

                var history = new HistoryStorage
                {
                    Name = material.Name,
                    Quantity = quantit,
                    ReasonTransaction = "Edit material down with",
                    Date = DateTime.Now
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }
            else if (model.Quantity > material.Quantity)
            {
                var quantit = model.Quantity - material.Quantity;

                var history = new HistoryStorage
                {
                    Name = material.Name,
                    Quantity = quantit,
                    ReasonTransaction = "Edit material up with",
                    Date = DateTime.Now
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }

            material.Name = model.Name;
            material.City = model.City;
            material.Designation = model.Designation;
            material.PlaceInStorage = model.PlaceInStorage;
            material.Price = model.Price;
            material.Quantity = model.Quantity;
            material.Insignificant = model.Insignificant;
            material.Picture = model.Picture;
            material.Comment = model.Comment;

            data.SaveChanges();
        }
    }
}