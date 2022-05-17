using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services
{
    public interface IStorageService
    {
        void AddComponent(ComponentViewModel component);
    }
}
