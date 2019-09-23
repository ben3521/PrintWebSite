using PrintWebSite.Data;
using PrintWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintWebSite.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> _productRepository;
        public ProductsService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public int GetProductCount(List<int> categoryIDs, string searchTerm)
        {
            var query = _productRepository.Table;            

            if (categoryIDs != null && categoryIDs.Count > 0)
            {
                query = query.Where(x => categoryIDs.Contains(x.CategoryID));
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return query.Count();
        }

        public List<Product> SearchProducts(List<int> categoryIDs, string searchTerm, int? pageNo, int pageSize)
        {
            var query = _productRepository.Table; 

            if (categoryIDs != null && categoryIDs.Count > 0)
            {
                query = query.Where(x => categoryIDs.Contains(x.CategoryID));
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;

            var skipCount = (pageNo.Value - 1) * pageSize;

            return query.OrderByDescending(x => x.ModifiedOn).Skip(skipCount).Take(pageSize).ToList();
        }


    }
}

