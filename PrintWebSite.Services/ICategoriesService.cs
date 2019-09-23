using PrintWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintWebSite.Services
{
    public interface ICategoriesService
    {
        List<Category> GetAllCategories();
        Category GetCategoryByName(string sanitizedCategoryName);        
    }
}
