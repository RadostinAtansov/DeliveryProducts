using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface ICreatedByInkoService
    {
        void Edit(EditToolCreatedServiceViewModel model);
        void AddCreated(AddCreatedByInkoServiceViewModel model, string path);
    }
}
