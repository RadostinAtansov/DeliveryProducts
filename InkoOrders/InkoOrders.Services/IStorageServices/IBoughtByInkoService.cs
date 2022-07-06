using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface IBoughtByInkoService
    {
        void Edit(EditToolBoughtServiceViewModel model);
        void AddTool(AddBoughtByInkoSeviceViewModel model, string path);
        void AddInvoiceToToolBought(AddInvoiceToolBoughtServiceViewModel model, string path);
    }
}
