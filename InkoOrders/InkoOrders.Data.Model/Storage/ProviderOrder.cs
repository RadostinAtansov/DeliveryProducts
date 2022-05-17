namespace InkoOrders.Data.Model.Storage
{
    public class ProviderOrder
    {
        public int Id { get; set; }

        /// <summary>
        /// 
        /// Identifier
        ///
        /// се съставя на следния принцип:“ 210900-3“ , първите две числа(21) показват годината на заявката, следващите две(09) показват месеца а(00) ден от месеца.Ако не се въвежда ден или е неизвестен се вписва „00“. (-3) показва поредността за поръчки за един и същи ден.
        /// </summary>
        public string Identifier { get; set; }

        public string ProviderName { get; set; }

        public string OrderDescription { get; set; }

        public int Quantity { get; set; }

        public string URL { get; set; }

        public DateTime OrderedDate { get; set; }

        public int HowManyProductsOrderedByPosition { get; set; }

        public DateTime Arrived { get; set; }

        public decimal? Price { get; set; }

        public string ArrivedQuantityAndProductsFromOrder { get; set; }

        public OrderStatusProvider Status { get; set; }

        public DateTime ChangeStatusChangeDatetime { get; set; }
    }
}
