using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface ICreatedByInkoService
    {
        void AddCreated(AddCreatedByInkoServiceViewModel model, string path);
    }
}
