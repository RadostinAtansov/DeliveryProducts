using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface IMaterialsInkoService
    {
        void AddMaterials(AddMaterialsServiceViewModel model, string path);
    }
}
