using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface IBoughtByInkoService
    {
        void AddTool(AddBoughtByInkoSeviceViewModel model);
    }
}
