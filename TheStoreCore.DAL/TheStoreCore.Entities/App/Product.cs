using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.DAL.TheStoreCore.Entities.Core;

namespace TheStoreCore.DAL.TheStoreCore.Entities.App
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
