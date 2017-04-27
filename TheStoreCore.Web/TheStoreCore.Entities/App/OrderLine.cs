using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.Web.TheStoreCore.Entities.Core;

namespace TheStoreCore.Web.TheStoreCore.Entities.App
{
    public class OrderLine : BaseEntity
    {
        public int Count { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
