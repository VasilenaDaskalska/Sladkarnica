using System.Data;

namespace Sladkarnica.Services.Contracts
{
    public interface IAssortmentService
    {
        void AddAssortment(string assortmentNumber, string assortmentName, int gruopID, string recipe, decimal sweetsWeight, decimal price);

        bool UpdateAssortmentByID(string assortmentNumber, string assortmentName, int gruopID, string recipe, decimal sweetsWeight, decimal price);

        bool DeleteAssortmentByID(string groupId);

        DataTable GetAllAssortments();
    }
}
