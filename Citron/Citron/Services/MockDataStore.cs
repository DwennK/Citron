using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Citron.Models;

namespace Citron.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        readonly List<Item> maListe;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };

            maListe = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Ragondin item", Description="This is an Ragondin description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Ragondin item", Description="This is an Ragondin description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Ragondin item", Description="This is an Ragondin description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Ragondin item", Description="This is an Ragondin description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Ragondin item", Description="This is an Ragondin description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Ragondin item", Description="This is an Ragondin description." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            maListe.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = maListe.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            maListe.Remove(oldItem);
            maListe.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = maListe.Where((Item arg) => arg.Id == id).FirstOrDefault();
            maListe.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(maListe.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(maListe);
        }
    }
}