using MenuApi.Entities;
using System;
using System.Collections.Generic;

namespace MenuApi.Repositories
{
    public interface IItemRepositories
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}