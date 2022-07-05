using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkoOrders.Services.Model.Storage
{
    public class EditMaterialServiceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Quantity { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string PlaceInStorage { get; set; }

        public string City { get; set; }

        public DateTime TimeInInko { get; set; }

        public bool Insignificant { get; set; }

        public string Comment { get; set; }
    }
}
