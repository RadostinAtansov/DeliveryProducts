namespace Inko.Orders.Web.Models.Storage.Show
{
    public class ShowWholeStorageViewMoedel
    {
        public IEnumerable<ShowAllComponentsViewModel> Components { get; set; }
        public IEnumerable<ShowAllMaterialViewModel> Materials { get; set; }
        public IEnumerable<ShowAllWareViewModel> Ware { get; set; }
        public IEnumerable<ShowAllCreatedToolsViewModel> Created { get; set; }
        public IEnumerable<ShowAllBoughtToolsViewModel> Bought { get; set; }
    }
}
