﻿using MenuApi.Entities;
using System;
using System.Collections.Generic;

namespace MenuApi.Repositories
{
    public class SqlItemsRepository : IItemRepositories
    {
        public SqlItemsRepository()
        {

        }

        public void CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}