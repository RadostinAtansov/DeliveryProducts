﻿namespace InkoOrders.Services.Model.Storage
{
    public class AddBoughtByInkoSeviceViewModel
    {
        public string Name { get; set; }

        public bool Buyed { get; set; } = true;

        public string BoughtFrom { get; set; }

        public DateTime TimeBought { get; set; }

        public int Quantity { get; set; }

        public string Picture { get; set; }

        public DateTime TimeWhenCreated { get; set; }

        public bool Insignificant { get; set; }

        public string PlaceInStorageAndCity { get; set; }

        public string Comment { get; set; }
    }
}