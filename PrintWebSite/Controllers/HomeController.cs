
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PrintWebSite.Code.Extensions;
using PrintWebSite.Data;
using PrintWebSite.Services;
using PrintWebSite.Shared;
using PrintWebSite.ViewModels;
using System.Linq;

namespace PrintWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;
        public HomeController(IConfiguration configuration,
            IProductsService productsService,
            ICategoriesService categoriesService)            
        {
            this.configuration = configuration;
            _productsService = productsService;
            _categoriesService = categoriesService;
        }
        public IActionResult Index()
        {
            PageViewModel model = new PageViewModel();

            model.PageTitle = "Logo Sports Home";
            model.PageDescription = "LogoSports Online WebStore";
            //model.PageURL = Url.Home().ToSiteURL();
            //model.PageImageURL = PictureHelper.PageImageURL("products.jpg");
            ViewBag.IsHome = "Home";
            return View(model);
        }

        public IActionResult Search(QueryStringViewModel queryStringViewModel)
        {
            var pageSize = int.Parse(configuration.GetSection("FrontendRecordsSizePerPage").Value);
            
            ProductsViewModel model = new ProductsViewModel
            {
                Categories = _categoriesService.GetAllCategories()
            };

            if (!string.IsNullOrEmpty(queryStringViewModel.Category))
            {
                var selectedCategory = _categoriesService.GetCategoryByName(queryStringViewModel.Category);

                if (selectedCategory == null) return NotFound();
                else
                {
                    model.CategoryID = selectedCategory.ID;
                    model.CategoryName = selectedCategory.SanitizedName;

                    model.SearchedCategories = Methods.GetAllCategoryChildrens(selectedCategory, model.Categories);

                    model.PageTitle = string.Format("Search for {0}", selectedCategory.Name);
                    model.PageDescription = selectedCategory.Description;

                    //model.PageURL = Url.SearchProducts(selectedCategory.SanitizedName, q).ToSiteURL();
                }
            }
            else
            {
                model.PageTitle = "Search Products";
                model.PageDescription = "Search Latest Products on eCommerce";

                //model.PageURL = Url.Products().ToSiteURL();
            }

            //model.PageImageURL = PictureHelper.PageImageURL("products.jpg");

            model.SearchTerm = queryStringViewModel.q;
            //model.isPartial = isPartial;

            var selectedCategoryIDs = model.SearchedCategories?.Select(x => x.ID).ToList();            

            model.Products = _productsService.SearchProducts(selectedCategoryIDs, model.SearchTerm, queryStringViewModel.PageNo, pageSize);
            var totalProducts = _productsService.GetProductCount(selectedCategoryIDs, queryStringViewModel.q);

            model.Pager = new Pager(totalProducts, queryStringViewModel.PageNo, pageSize);           

            if (Request.IsAjaxRequest())
            {
                return PartialView("_FilterProducts", model);
            }
            return View(model);
            
        }
    }
}