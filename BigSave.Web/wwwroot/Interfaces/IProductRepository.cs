using BigSave.Core.Entities;
using BigSave.Service.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigSave.Service.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductList();
        List<Product> GetProductByName(string productName);
        Product GetProductById(int productId);
        List<Product> GetProductInCategory(int categoryId);
        List<Product> GetProductInMerchant(int merchantId);
    }
}
