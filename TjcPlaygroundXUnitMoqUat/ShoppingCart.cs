using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TjcPlaygroundXUnitMoqUat
{
    public record Product(int id, string name, double price);

    public interface IDbService
    {
        bool SaveItemToShoppingCart(Product? prod);
        bool RemoveItemFromShoppingCart(int? prodId);
    }


    public class ShoppingCart
    {
        private IDbService m_dbService; 

        public ShoppingCart(IDbService dbService) 
        {
            m_dbService = dbService;
        }

        public bool AddProduct(Product? product)
        {
            if (product == null)
                return false;

            if (product.id == 0)
                return false;

            m_dbService.SaveItemToShoppingCart(product);
            return true;
        }

        public bool DeleteProduct(int? id)
        {
            if (id == null) return false;

            if (id == 0) return false;

            m_dbService.RemoveItemFromShoppingCart(id);
            return true;
        }
    }
}
