namespace InkoOrders.Data.Model.ClientToDelivery
{
    public enum OrderStatus
    {
        Accepted = 0,
        ReviewTransaction = 1,
        WaitingForParts = 2,
        Making = 3,
        Finished = 4,
        Sended = 5,
    }
}
