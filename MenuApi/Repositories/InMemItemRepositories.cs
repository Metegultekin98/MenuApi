using MenuApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MenuApi.Repositories
{
    public class InMemItemRepositories : IItemRepositories
    {
        private readonly List<Item> items = new()
        {
            new Item
            {
                Id = Guid.NewGuid(),
                Name = "Coffee",
                Price = 9,
                CreatedDate = DateTimeOffset.UtcNow,
            },
            new Item
            {
                Id = Guid.NewGuid(),
                Name = "Cake",
                Price = 18,
                CreatedDate = DateTimeOffset.UtcNow,
            },
            new Item
            {
                Id = Guid.NewGuid(),
                Name = "Coke",
                Price = 20,
                CreatedDate = DateTimeOffset.UtcNow,
            }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }
    }
}
