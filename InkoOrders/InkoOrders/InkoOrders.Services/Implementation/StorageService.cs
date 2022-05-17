using InkoOrders.Data;
using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.Implementation
{
    public class StorageService : IStorageService
    {
        private readonly InkoOrdersDBContext data;

        public StorageService(InkoOrdersDBContext data)
        {
            this.data = data;
        }

        public void AddComponent(ComponentViewModel component)
        {
            throw new NotImplementedException();
        }
    }
}
