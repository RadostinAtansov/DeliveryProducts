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

        public void AddMaterials(AddMaterialsServiceViewModel material, string path)
        {
            if (string.IsNullOrEmpty(material.Name))
            {
                throw new ArgumentException("Name can`t be empty");
            }

            var mtr = new MaterialsInInko()
            {
                Name = material.Name,
                Price = material.Price,
                TimeInInko = DateTime.Now,
                Picture = path,
                Comment = material.Comment,
                Quаntity = material.Quаntity,
                Insignificant = material.Insignificant,
                PlaceInStorageAndCity = material.PlaceInStorageAndCity,
            };

            data.MaterialsInInko.Add(mtr);
            data.SaveChanges();
        }
    }
}