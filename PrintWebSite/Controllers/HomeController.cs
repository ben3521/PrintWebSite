
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
        private readonly IProductsRepository productsRepository;
        private readonly PrintWebSiteDbContext context;
        public HomeController(PrintWebSiteDbContext context, IConfiguration configuration, IProductsRepository productsRepository)
        {
            this.configuration = configuration;
            this.productsRepository = productsRepository;
            this.context = context;
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

            CategoriesService categoriesService = new CategoriesService(context);
            ProductsViewModel model = new ProductsViewModel
            {
                Categories = categoriesService.GetAllCategories()
            };

            if (!string.IsNullOrEmpty(queryStringViewModel.Category))
            {
                var selectedCategory = categoriesService.GetCategoryByName(queryStringViewModel.Category);

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

            model.Products = productsRepository.SearchProducts(selectedCategoryIDs, model.SearchTerm, queryStringViewModel.PageNo, pageSize);
            var totalProducts = productsRepository.GetProductCount(selectedCategoryIDs, queryStringViewModel.q);

            model.Pager = new Pager(totalProducts, queryStringViewModel.PageNo, pageSize);           

            if (Request.IsAjaxRequest())
            {
                return PartialView("_FilterProducts", model);
            }
            return View(model);
            
        }
    }
}