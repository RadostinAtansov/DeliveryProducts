﻿namespace InkoOrders.Data.Model
{
    public class ClientsOrders
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
