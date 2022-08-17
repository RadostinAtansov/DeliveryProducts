using InkoOrders.Data;
using InkoOrders.Data.Model.Storage;
using InkoOrders.Services.IStorageServices;
using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.Implementation.Storage
{
    public class CreatedByInkoService : ICreatedByInkoService
    {
        private readonly InkoOrdersDBContext data;

        public CreatedByInkoService(InkoOrdersDBContext data)
        {
            this.data = data;
        }

        public void AddCreated(AddCreatedByInkoServiceViewModel model, string path)
        {

            var created = new ToolCreatedByInko()
            {
                Created = true,
                Picture = path,
                Name = model.Name,
                City = model.City,
                Comment = model.Comment,
                Quantity = model.Quantity,
                CreatedFrom = model.CreatedFrom,
                Designation = model.Designation,
                Insignificant = model.Insignificant,
                PlaceInStorage = model.PlaceInStorage,
                TimeWhenCreated = model.TimeWhenCreated,
            };

            data.ToolCreatedByInko.Add(created);
            data.SaveChanges();
        }

        public void Edit(EditToolCreatedServiceViewModel model)
        {
            var toolcreated = data.ToolCreatedByInko
                .Find(model.Id);

            if (model.Quantity < toolcreated.Quantity)
            {
                var quantit = toolcreated.Quantity - model.Quantity;

                var history = new HistoryStorage
                {
                    Quantity = quantit,
                    Date = DateTime.Now,
                    Name = toolcreated.Name,
                    ReasonTransaction = "Edit Created Tool down with",
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }
            else if (model.Quantity > toolcreated.Quantity)
            {
                var quantit = model.Quantity - toolcreated.Quantity;

                var history = new HistoryStorage
                {
                    Quantity = quantit,
                    Date = DateTime.Now,
                    Name = toolcreated.Name,
                    ReasonTransaction = "Edit Created Tool up with",
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }

            toolcreated.Name = model.Name;
            toolcreated.City = model.City;
            toolcreated.Picture = model.Picture;
            toolcreated.Comment = model.Comment;
            toolcreated.Quantity = model.Quantity;
            toolcreated.Designation = model.Designation;
            toolcreated.Insignificant = model.Insignificant;
            toolcreated.PlaceInStorage = model.PlaceInStorage;
            toolcreated.TimeWhenCreated = model.TimeWhenCreated;

            data.SaveChanges();
        }
    }
}
