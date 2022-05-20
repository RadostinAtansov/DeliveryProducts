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

        public void AddMaterials(AddMaterialsServicesViewModel material)
        {
            if (string.IsNullOrEmpty(material.Name))
            {
                throw new ArgumentException("Name can`t be empty");
            }

            var mtr = new MaterialsInInko()
            {
                Name = material.Name,
                Quаntity = material.Quаntity,
                Price = material.Price,
                Insignificant = material.Insignificant,
                Picture = material.Picture,
                PlaceInStorageAndCity = material.PlaceInStorageAndCity,
                TimeInInko = DateTime.Now,
                Comment = material.Comment,
            };

            data.MaterialsInInko.Add(mtr);
            data.SaveChanges();
        }
    }
}