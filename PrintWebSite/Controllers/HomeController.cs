
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PrintWebSite.Services;
using PrintWebSite.ViewModels;

namespace PrintWebSite.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            PageViewModel model = new PageViewModel();

            model.PageTitle = "Logo Sports Home";
            model.PageDescription = "LogoSports Online WebStore";
            //model.PageURL = Url.Home().ToSiteURL();
            //model.PageImageURL = PictureHelper.PageImageURL("products.jpg");

            return View(model);
        }
    }
}