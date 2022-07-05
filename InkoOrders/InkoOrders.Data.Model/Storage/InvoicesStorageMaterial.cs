using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkoOrders.Data.Model.Storage
{
    public class InvoicesStorageMaterial
    {
        public int Id { get; set; }

        public string BoughtCompanyName { get; set; }

        public int Qantity { get; set; }

        public string ProductName { get; set; }

        public DateTime TimeWhenBoughtOnInvoice { get; set; }

        public string Comment { get; set; }

        public string Picture { get; set; }

        public int MaterialId { get; set; }
        public MaterialsInInko Material { get; set; }
    }
}
