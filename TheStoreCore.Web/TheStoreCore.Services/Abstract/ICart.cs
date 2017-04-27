using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.Web.TheStoreCore.Entities.App;

namespace TheStoreCore.Web.TheStoreCore.Services.Abstract
{
    public interface ICart
    {
        void AddItem(Product product, int quantity);

        void RemoveLine(Product product);

        decimal ComputeTotalValue();

        void Clear();

        IEnumerable<CartLine> Lines { get; }
    }
}
