namespace Sladkarnica.Services.Contracts
{
    public interface IClientService
    {
        bool DeleteClientByID(int clientID);

        void AddClient(string name, string adress, string phoneNumber);

        bool UpdateClientByID(int clientID, string name, string adress, string phoneNumber);
    }
}
