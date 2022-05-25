using InkoOrders.Data;
using InkoOrders.Services.IStorageServices;
using InkoOrders.Services.Model.Storage;
using InkoOrders.Data.Model.Storage;

namespace InkoOrders.Services.Implementation.Storage
{
    public class BoughtByInkoSevice : IBoughtByInkoService
    {
        private readonly InkoOrdersDBContext data;

        public BoughtByInkoSevice(InkoOrdersDBContext data)
        {
            this.data = data;
        }


        public void AddTool(AddBoughtByInkoSeviceViewModel tool)
        {
            if (string.IsNullOrEmpty(tool.Name))
            {
                throw new ArgumentException("Name can`t be empty");
            }

            var tul = new ToolBoughtByInko()
            {
                Name = tool.Name,
                Bought = true,
                BoughtFrom = tool.BoughtFrom,
                Comment = tool.Comment,
                Picture = tool.Picture,
                PlaceInStorageAndCity = tool.PlaceInStorageAndCity,
                Insignificant = tool.Insignificant,
                Quantity = tool.Quantity,
                TimeBought = tool.TimeBought
            };

            data.TooldBoughtByInko.Add(tul);
            data.SaveChanges();
        }
    }
}
