using System;

namespace Sladkarnica.Services.Contracts
{
    public interface IOrdersService
    {
        void AddOrder(DateTime date, string assortmentID, bool isReady, int quantity);

        bool DeleteOrderByID(int groupId);

        void UpdateOrderByID(int orderID, DateTime date, string assortmentID, bool isReady, int quantity);
    }
}
