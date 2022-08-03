namespace InkoOrders.Services.Model.Storage
{
    public class EditWareServiceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool ActiveOrOld { get; set; }

        public string Designation { get; set; }

        public DateTime TimeActiveAndHowOld { get; set; }

        public int Quantity { get; set; }

        public bool Insignificant { get; set; }

        public string PlaceInStorage { get; set; }

        public string City { get; set; }

        public string Picture { get; set; }

        public string Comment { get; set; }
    }
}
