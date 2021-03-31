using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Models
{
    public class ItemContext :DbContext
    {
        public ItemContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
    }
}

