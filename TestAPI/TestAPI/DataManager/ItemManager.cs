using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;
using TestAPI.Models.Repository;

namespace TestAPI.DataManager
{
    public class ItemManager : IDataRepository<Item>
    {
        readonly ItemContext _itemContext;
        public ItemManager(ItemContext context)
        {
            _itemContext = context;
        }
        public IEnumerable<Item> GetAll()
        {
            return _itemContext.Items.ToList();
        }
        public Item Get(int id)
        {
            return _itemContext.Items
                  .FirstOrDefault(e => e.Id == id);
        }
        public void Add(Item entity)
        {
            _itemContext.Items.Add(entity);
            _itemContext.SaveChanges();
        }
        public void Update(Item item, Item entity)
        {
            item.Description = entity.Description;
            item.IsDone = entity.IsDone;
            
            _itemContext.SaveChanges();
        }
        public void Delete(Item item)
        {
            _itemContext.Items.Remove(item);
            _itemContext.SaveChanges();
        }
    }
}
