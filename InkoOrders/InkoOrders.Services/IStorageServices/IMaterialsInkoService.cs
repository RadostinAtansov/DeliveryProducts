using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.IStorageServices
{
    public interface IMaterialsInkoService
    {
        void AddInvoiceToMaterial(AddInvoiceMaterialServiceViewModel model, string path);
        void AddMaterials(AddMaterialsServiceViewModel model, string path);
        void Edit(EditMaterialServiceViewModel model);
    }
}
