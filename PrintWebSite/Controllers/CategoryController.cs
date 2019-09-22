using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PrintWebSite.Data;
using PrintWebSite.Services;
using PrintWebSite.Shared;
using PrintWebSite.ViewModels;

namespace PrintWebSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly PrintWebSiteDbContext context;

        public CategoryController(PrintWebSiteDbContext context, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.context = context;
        }

        //public IActionResult Search(string category, string q, int? pageNo, bool isPartial = false)
        //{
        //    var pageSize = int.Parse(configuration.GetSection("FrontendRecordsSizePerPage").Value);

        //    CategoriesService categoriesService = new CategoriesService(context);
        //    ProductsViewModel model = new ProductsViewModel
        //    {
        //        Categories = categoriesService.GetAllCategories()
        //    };

        //    if (!string.IsNullOrEmpty(category))
        //    {
        //        var selectedCategory = categoriesService.GetCategoryByName(category);

        //        if (selectedCategory == null) return NotFound();
        //        else
        //        {
        //            model.CategoryID = selectedCategory.ID;
        //            model.CategoryName = selectedCategory.SanitizedName;

        //            model.SearchedCategories = Methods.GetAllCategoryChildrens(selectedCategory, model.Categories);

        //            model.PageTitle = string.Format("Search for {0}", selectedCategory.Name);
        //            model.PageDescription = selectedCategory.Description;

        //            //model.PageURL = Url.SearchProducts(selectedCategory.SanitizedName, q).ToSiteURL();
        //        }
        //    }
        //    else
        //    {
        //        model.PageTitle = "Search Products";
        //        model.PageDescription = "Search Latest Products on eCommerce";

        //        //model.PageURL = Url.Products().ToSiteURL();
        //    }

        //    //model.PageImageURL = PictureHelper.PageImageURL("products.jpg");

        //    model.SearchTerm = q;
        //    model.isPartial = isPartial;

        //    var selectedCategoryIDs = model.SearchedCategories?.Select(x => x.ID).ToList();

        //    ProductsService productService = new ProductsService(context);

        //    model.Products = productService.SearchProducts(selectedCategoryIDs, model.SearchTerm, pageNo, pageSize);
        //    var totalProducts = productService.GetProductCount(selectedCategoryIDs, q);

        //    model.Pager = new Pager(totalProducts, pageNo, pageSize);

        //    if (model.isPartial)
        //    {
        //        return PartialView(model);
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //}
    }
}