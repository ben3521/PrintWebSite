using PrintWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintWebSite.Services
{
    public interface IProductsService
    {
        List<Product> SearchProducts(List<int> categoryIDs, string searchTerm, int? pageNo, int pageSize);
        int GetProductCount(List<int> categoryIDs, string searchTerm);
    }
}
