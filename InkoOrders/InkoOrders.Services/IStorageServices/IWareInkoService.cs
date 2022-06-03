using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface IWareInkoService
    {
        void AddWare(AddWareServiceViewModel model);
        ICollection<ListAllWareServiceViewModel> ListAll();
    }
}
