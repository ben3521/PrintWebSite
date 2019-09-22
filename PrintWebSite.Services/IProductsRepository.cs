using PrintWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintWebSite.Services
{
    public interface IProductsRepository
    {
        //List<Product> GetAllProducts();
        //List<Product> SearchFeaturedProducts(int pageSize, List<int> excludeProductIDs = null);
        List<Product> SearchProducts(List<int> categoryIDs, string searchTerm, int? pageNo, int pageSize);
        int GetProductCount(List<int> categoryIDs, string searchTerm);
        //Product GetProductByID(int ID);
        //List<Product> GetProductsByIDs(List<int> IDs);
        //void SaveProduct(Product Product);
        //void UpdateProduct(Product Product);
        //bool DeleteProduct(int ID);
    }
}
