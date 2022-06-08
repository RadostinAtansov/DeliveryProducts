namespace Inko.Orders.Web.Models.Storage.Show
{
    public class ShowAllToolsViewModel
    {
        public IEnumerable<ShowAllBoughtToolsViewModel> BoughtTools { get; set; }
        public IEnumerable<ShowAllCreatedToolsViewModel> CreatedTools { get; set; }
    }
}
