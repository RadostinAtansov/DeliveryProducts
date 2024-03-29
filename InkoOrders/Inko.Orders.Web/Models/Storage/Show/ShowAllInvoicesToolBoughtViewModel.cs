﻿namespace Inko.Orders.Web.Models.Storage.Show
{
    public class ShowAllInvoicesToolBoughtViewModel
    {
        public int Id { get; set; }

        public string BoughtCompanyName { get; set; }

        public int Quantity { get; set; }

        public string ProductName { get; set; }

        public DateTime TimeWhenBoughtOnInvoice { get; set; }

        public string Comment { get; set; }

        public string Picture { get; set; }
    }
}
