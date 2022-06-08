using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inko.Orders.Web.Models.Storage.Add
{
    public class AddWareInkoViewModel
    {
        public string Name { get; set; }

        public bool ActiveOrOld { get; set; }

        public DateTime TimeActiveAndHowOld { get; set; }

        public int Quantity { get; set; }

        public bool Insignificant { get; set; }

        public string Comment { get; set; }

        public string PlaceInStorageAndCity { get; set; }

        public IFormFile Picture { get; set; }
    }
}
