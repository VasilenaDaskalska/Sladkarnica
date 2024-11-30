namespace Sladkarnica.Services.Contracts
{
    public interface IProductGroupService
    {
        void AddProductGroup(string groupName);

        bool UpdateProductGroupByID(int groupId, string newName);

        bool UpdateProductGroupByName(string groupName, string newName);

        bool DeleteProductGroupByID(int groupId);
    }
}
