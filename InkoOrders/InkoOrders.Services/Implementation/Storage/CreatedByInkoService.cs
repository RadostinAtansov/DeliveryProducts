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
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentException("Name can`n be null or empty");
            }

            var toolCheck = data.Components
                   .FirstOrDefault(x => x.Name == model.Name);

            if (toolCheck != null)
            {
                throw new ArgumentException("Can`t add same tool!");
            }

            var created = new ToolCreatedByInko()
            {
                Name = model.Name,
                Designation = model.Designation,
                Created = true,
                Picture = path,
                PlaceInStorage = model.PlaceInStorage,
                City = model.City,
                Comment = model.Comment,
                CreatedFrom = model.CreatedFrom,
                Insignificant = model.Insignificant,
                Quantity = model.Quantity,
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
                    Name = toolcreated.Name,
                    Quantity = quantit,
                    ReasonTransaction = "Edit material down with",
                    Date = DateTime.Now
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }
            else if (model.Quantity > toolcreated.Quantity)
            {
                var quantit = model.Quantity - toolcreated.Quantity;

                var history = new HistoryStorage
                {
                    Name = toolcreated.Name,
                    Quantity = quantit,
                    ReasonTransaction = "Edit material up with",
                    Date = DateTime.Now
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }

            toolcreated.Name = model.Name;
            toolcreated.TimeWhenCreated = model.TimeWhenCreated;
            toolcreated.Designation = model.Designation;
            toolcreated.City = model.City;
            toolcreated.PlaceInStorage = model.PlaceInStorage;
            toolcreated.Quantity = model.Quantity;
            toolcreated.Insignificant = model.Insignificant;
            toolcreated.Picture = model.Picture;
            toolcreated.Comment = model.Comment;

            data.SaveChanges();
        }
    }
}
