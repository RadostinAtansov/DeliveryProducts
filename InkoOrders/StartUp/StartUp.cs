using InkoOrders.Data;

var data = new InkoOrdersDBContext();

data.Clients.Select(s => s);