using Inko.Orders.Web.Models.Storage.Edit;
using InkoOrders.Data.Model.Storage;

namespace Inko.Orders.Web.Models.Storage.Show
{
    public class ShowWholeStorageViewMoedel
    {
        public IEnumerable<ShowAllComponentsViewModel> Components { get; set; }
        public IEnumerable<ShowAllMaterialViewModel> Materials { get; set; }
        public IEnumerable<ShowAllWareViewModel> Ware { get; set; }
        public IEnumerable<ShowAllCreatedToolsViewModel> Created { get; set; }
        public IEnumerable<ShowAllBoughtToolsViewModel> Bought { get; set; }
        //public IEnumerable<HistoryStockWriteOffViewModel> History { get; set; }
        public StorageSortingWholeStorageByCriteria StorageSortingWholeStorageByCriteria { get; set; }
        public StorageSortingByCity StorageSortingByCity { get; set; }
    }
}
