using MenuApi.Entities.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuApi.Services
{
    public interface IItemsService
    {
        List<Items> GetAll();
        Task<IList<Items>> GetAllAsync();
        Items GetBookById(int Id);
        void DeleteItem(Items item);
        void UpdateItem(Items item);
        void InsertItem(Items item);
    }
}
