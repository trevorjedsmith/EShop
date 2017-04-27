using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.Web.TheStoreCore.Entities.Core;

namespace TheStoreCore.Web.TheStoreCore.Entities.App
{
    public class Order : BaseEntity
    {
        public string Customer { get; set; }
        public decimal TotalCost { get; set; }
        public ICollection<OrderLine> Lines { get; set; }
    }
}
