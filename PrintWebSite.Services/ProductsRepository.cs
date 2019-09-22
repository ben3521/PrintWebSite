using PrintWebSite.Data;
using PrintWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintWebSite.Services
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly PrintWebSiteDbContext context;

        public ProductsRepository(PrintWebSiteDbContext context)
        {
            this.context = context;
        }

        //    public List<Product> GetAllProducts()
        //    {
        //        return context.Products.ToList();
        //    }

        //    public List<Product> SearchFeaturedProducts(int pageSize, List<int> excludeProductIDs = null)
        //    {
        //        excludeProductIDs = excludeProductIDs ?? new List<int>();

        //        return context.Products.Where(a => a.isFeatured && !excludeProductIDs.Contains(a.ID)).OrderByDescending(x => x.ID).Take(pageSize).ToList();
        //    }

        public List<Product> SearchProducts(List<int> categoryIDs, string searchTerm, int? pageNo, int pageSize)
        {
            var Products = context.Products.AsQueryable();

            if (categoryIDs != null && categoryIDs.Count > 0)
            {
                Products = Products.Where(x => categoryIDs.Contains(x.CategoryID));
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Products = Products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;

            var skipCount = (pageNo.Value - 1) * pageSize;

            return Products.OrderByDescending(x => x.ModifiedOn).Skip(skipCount).Take(pageSize).ToList();
        }

        public int GetProductCount(List<int> categoryIDs, string searchTerm)
        {
            var Products = context.Products.AsQueryable();

            if (categoryIDs != null && categoryIDs.Count > 0)
            {
                Products = Products.Where(x => categoryIDs.Contains(x.CategoryID));
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Products = Products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return Products.Count();
        }

        //    public Product GetProductByID(int ID)
        //    {
        //        return context.Products.Find(ID);
        //    }

        //    public List<Product> GetProductsByIDs(List<int> IDs)
        //    {
        //        return IDs.Select(id => context.Products.Find(id)).OrderBy(x => x.ID).ToList();
        //    }

        //    public void SaveProduct(Product Product)
        //    {
        //        context.Products.Add(Product);

        //        context.SaveChanges();
        //    }


        //    public void UpdateProduct(Product Product)
        //    {
        //        var exitingProduct = context.Products.Find(Product.ID);

        //        context.ProductPictures.RemoveRange(exitingProduct.ProductPictures);

        //        context.Entry(exitingProduct).CurrentValues.SetValues(Product);

        //        context.ProductPictures.AddRange(Product.ProductPictures);

        //        context.SaveChanges();
        //    }

        //    public bool DeleteProduct(int ID)
        //    {
        //        var product = context.Products.Find(ID);

        //        context.Products.Remove(product);

        //        return context.SaveChanges() > 0;
        //    }
    }

}
