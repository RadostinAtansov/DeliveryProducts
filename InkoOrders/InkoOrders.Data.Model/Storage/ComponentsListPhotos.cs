namespace InkoOrders.Data.Model.Storage
{
    public class ComponentsListPhotos
    {
        public int Id { get; set; }

        public string Picture { get; set; }

        public int ComponentId { get; set; }
        public Component Component { get; set; }
    }
}
