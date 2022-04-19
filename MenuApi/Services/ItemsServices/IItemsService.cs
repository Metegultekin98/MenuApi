using MenuApi.Entities.Items;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApi.Services.ItemsServices
{
    public  interface IItemsService
    {
        IList<Items> GetAllItems();
        Items GetItemById(int itemId);
        void DeleteItem(Items item);
        void DeleteItemById(int itemId);
        void UpdateItem(Items item);
        void InsertItem(Items item);
    }
}
