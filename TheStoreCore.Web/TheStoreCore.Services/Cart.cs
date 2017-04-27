using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStoreCore.Web.TheStoreCore.Entities.App;
using TheStoreCore.Web.TheStoreCore.Repositories.Abstract;
using TheStoreCore.Web.TheStoreCore.Services.Abstract;

namespace TheStoreCore.Web.TheStoreCore.Services
{
    public class Cart 
    {

        private List<CartLine> lineCollection = new List<CartLine>();

        public string CartID { get; set; }

        public IEnumerable<CartLine> Lines => lineCollection;

        public void AddItem(Product product, int quantity)
        {
            var line = lineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public int CartCount()
        {
            return lineCollection.Sum(e => e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public decimal ComputeTotalValue()
        {
            var sum = lineCollection.Sum(e => e.Product.Price * e.Quantity);
            return sum;
        }

        public void RemoveLine(Product product)
        {

            var line = lineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();
         
            if(line.Quantity > 1)
            {
                line.Quantity--;
            }
            else
            {
                lineCollection.RemoveAll(l => l.Product.Id == product.Id);
            }

           
        }
    }
}
