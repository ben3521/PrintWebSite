using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using System.Web;

namespace PrintWebSite.Code.Helpers
{
    public static class URLHelper
    {
        public static string Home(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Home");

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }

        public static string Register(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Register");

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }

        public static string Login(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Login");

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }
        public static string Logoff(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Logoff");

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }

        public static string SearchProducts(this UrlHelper helper, string category = "", string q = "", int? pageNo = 0)
        {
            string routeURL = string.Empty;

            var routeValues = new RouteValueDictionary();

            routeValues.Add("category", category);

            if (!string.IsNullOrEmpty(q))
            {
                routeValues.Add("q", q);
            }

            if (pageNo.HasValue && pageNo.Value > 1)
            {
                routeValues.Add("pageNo", pageNo.Value);
            }

            routeURL = helper.RouteUrl("SearchProducts", routeValues);

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }

        public static string ProductDetails(this UrlHelper helper, string category, int ID)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("ProductDetails", new
            {
                category = category,
                ID = ID
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }

        public static string Profile(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Profile");

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }

        public static string UserOrders(this UrlHelper helper, string userEmail = "", int? orderID = 0, int? orderStatus = 0, int? pageNo = 0)
        {
            string routeURL = string.Empty;

            var routeValues = new RouteValueDictionary();

            if (!string.IsNullOrEmpty(userEmail))
            {
                routeValues.Add("userEmail", userEmail);
            }

            if (orderID.HasValue && orderID.Value > 0)
            {
                routeValues.Add("orderID", orderID.Value);
            }

            if (orderStatus.HasValue && orderStatus.Value > 0)
            {
                routeValues.Add("orderStatus", orderStatus.Value);
            }

            if (pageNo.HasValue && pageNo.Value > 1)
            {
                routeValues.Add("pageNo", pageNo.Value);
            }

            routeURL = helper.RouteUrl("UserOrders", routeValues);

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }

        public static string CartProducts(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("CartProducts");

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }

        public static string CartItems(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("CartItems");

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }

        public static string Checkout(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Checkout");

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }

        public static string PlaceOrder(this UrlHelper helper, bool isCashOnDelivery = false)
        {
            string routeURL = string.Empty;

            if (isCashOnDelivery)
            {
                routeURL = helper.RouteUrl("PlaceOrderViaCashOnDelivery");
            }
            else
            {
                routeURL = helper.RouteUrl("PlaceOrder");
            }

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }

        public static string OrderTrack(this UrlHelper helper, string orderID = "", bool orderPlaced = false)
        {
            string routeURL = string.Empty;

            var routeValues = new RouteValueDictionary();

            if (!string.IsNullOrEmpty(orderID))
            {
                routeValues.Add("orderID", orderID);
            }

            if (orderPlaced)
            {
                routeValues.Add("orderPlaced", orderPlaced);
            }

            routeURL = helper.RouteUrl("OrderTrack", routeValues);

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }

        public static string PrintInvoice(this UrlHelper helper, int orderID)
        {
            string routeURL = string.Empty;

            var routeValues = new RouteValueDictionary();

            routeValues.Add("orderID", orderID);

            routeURL = helper.RouteUrl("PrintInvoice", routeValues);

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);
            return routeURL.ToLower();
        }
    }
}
