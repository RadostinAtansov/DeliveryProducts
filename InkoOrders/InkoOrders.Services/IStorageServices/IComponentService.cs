using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface IComponentService
    {
        void AddComponent(AddComponentServiceViewModel component);
    }
}
