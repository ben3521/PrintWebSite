using PrintWebSite.Data;
using PrintWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintWebSite.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoriesService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<Category> GetAllCategories()
        {
            var query = _categoryRepository.Table;
            return query.ToList();
        }

        public Category GetCategoryByName(string sanitizedCategoryName)
        {
            var query = _categoryRepository.Table;
            return query.FirstOrDefault(x => x.SanitizedName.Equals(sanitizedCategoryName));
        }

        //    public List<Category> GetFeaturedCategories(int recordSize = 5)
        //    {
        //        return context.Categories.Where(x => x.isFeatured).OrderBy(x => x.DisplaySeqNo).Take(recordSize).ToList();
        //    }

        //    public List<Category> GetAllParentCategories()
        //    {
        //        return context.Categories.Where(x => !x.ParentCategoryID.HasValue).OrderBy(x => x.DisplaySeqNo).ToList();
        //    }

        //    public Category GetCategoryByID(int ID)
        //    {
        //        using (var context = new PrintWebSiteDbContext())
        //        {
        //            return context.Categories.Find(ID);
        //        }
        //    }



        //    public void SaveCategory(Category category)
        //    {
        //        context.Categories.Add(category);

        //        context.SaveChanges();
        //    }

        //    public void UpdateCategory(Category category)
        //    {
        //        //context.Entry(category).State = System.Data.Entity.EntityState.Modified;

        //        context.SaveChanges();
        //    }

        //    public bool DeleteCategory(int ID)
        //    {
        //        using (var context = new PrintWebSiteDbContext())
        //        {
        //            var category = context.Categories.Find(ID);

        //            context.Categories.Remove(category);

        //            return context.SaveChanges() > 0;
        //        }
        //    }

        //    public List<Category> SearchCategories(int? parentCategoryID, string searchTerm, int? pageNo, int pageSize)
        //    {
        //        var categories = context.Categories.AsQueryable();

        //        if (parentCategoryID.HasValue && parentCategoryID.Value > 0)
        //        {
        //            categories = categories.Where(x => x.ParentCategoryID == parentCategoryID.Value);
        //        }

        //        if (!string.IsNullOrEmpty(searchTerm))
        //        {
        //            categories = categories.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
        //        }

        //        pageNo = pageNo ?? 1;
        //        var skipCount = (pageNo.Value - 1) * pageSize;

        //        return categories.OrderBy(x => x.DisplaySeqNo).Skip(skipCount).Take(pageSize).ToList();
        //    }

        //    public int GetCategoriesCount(int? parentCategoryID, string searchTerm)
        //    {
        //        var categories = context.Categories.AsQueryable();

        //        if (parentCategoryID.HasValue && parentCategoryID.Value > 0)
        //        {
        //            categories = categories.Where(x => x.ParentCategoryID == parentCategoryID.Value);
        //        }

        //        if (!string.IsNullOrEmpty(searchTerm))
        //        {
        //            categories = categories.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
        //        }

        //        return categories.Count();
        //    }
    }

}
