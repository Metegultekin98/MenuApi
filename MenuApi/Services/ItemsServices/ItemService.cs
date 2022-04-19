using MenuApi.Data;
using MenuApi.Entities.Items;
using MenuApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApi.Services.ItemsServices
{
    public class ItemService : Repository<Items>, IItemsService
    {
        public ItemService(Context context) : base(context)
        {
        }

        public void DeleteItem(Items item)
        {
            Delete(item);
        }

        public void DeleteItemById(int itemId)
        {
            Delete(itemId);
        }

        public IList<Items> GetAllItems()
        {
            return GetAll();
        }

        public Items GetItemById(int itemId)
        {
            return GetById(itemId);
        }

        public void InsertItem(Items item)
        {
            Insert(item);
        }

        public void UpdateItem(Items item)
        {
            Update(item);
        }
    }
}
