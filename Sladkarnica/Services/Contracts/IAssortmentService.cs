namespace Sladkarnica.Services.Contracts
{
    public interface IAssortmentService
    {
        void AddAssortment(string assortmentNumber, string assortmentName, int gruopID, string recipe, decimal sweetsWeight, decimal price);
    }
}
