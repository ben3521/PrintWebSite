using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintWebSite
{
    public static class RouteConfig
    {
        /// <summary>
        /// Adds a route to the route builder with the specified name, template, and default values
        /// </summary>
        /// <param name="routeBuilder">The route builder to add the route to</param>
        /// <param name="name">The name of the route</param>
        /// <param name="template">The URL pattern of the route</param>
        /// <param name="defaults">An object that contains default values for route parameters. 
        /// The object's properties represent the names and values of the default values</param>
        /// <returns>Route builder</returns>
        public static IRouteBuilder MapLocalizedRoute(this IRouteBuilder routeBuilder, string name, string template, object defaults)
        {
            return
            routeBuilder.MapRoute(
               name: name,
               template: template,
               defaults: defaults);
        }

        public static IRouteBuilder Use(IRouteBuilder routeBuilder)
        {
            //areas
            routeBuilder.MapRoute(name: "areaRoute", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute(
                name: "default",
                template: "{controller}/{action}/{id?}",
                defaults: new { area = "", controller = "Home", action = "Index" });

            //home page
            routeBuilder.MapLocalizedRoute("Homepage", "",
                new { controller = "Home", action = "Index" });

            //login
            routeBuilder.MapLocalizedRoute("Login", "login/",
                new { controller = "Customer", action = "Login" });

            //register
            routeBuilder.MapLocalizedRoute("Register", "register/",
                new { controller = "Customer", action = "Register" });

            //logout
            routeBuilder.MapLocalizedRoute("Logout", "logout/",
                new { controller = "Customer", action = "Logout" });

            //shopping cart
            routeBuilder.MapLocalizedRoute("ShoppingCart", "cart/",
                new { controller = "ShoppingCart", action = "Cart" });

            //estimate shipping
            routeBuilder.MapLocalizedRoute("EstimateShipping", "cart/estimateshipping",
                new { controller = "ShoppingCart", action = "GetEstimateShipping" });

            //customer account links
            routeBuilder.MapLocalizedRoute("CustomerInfo", "customer/info",
                new { controller = "Customer", action = "Info" });

            routeBuilder.MapLocalizedRoute("CustomerAddresses", "customer/addresses",
                new { controller = "Customer", action = "Addresses" });

            routeBuilder.MapLocalizedRoute("CustomerOrders", "order/history",
                new { controller = "Order", action = "CustomerOrders" });

            //contact us
            routeBuilder.MapLocalizedRoute("ContactUs", "contactus",
                new { controller = "Common", action = "ContactUs" });

            //sitemap
            routeBuilder.MapLocalizedRoute("Sitemap", "sitemap",
                new { controller = "Common", action = "Sitemap" });

            //product search *****************************
            routeBuilder.MapLocalizedRoute("ProductSearch", "search/",
                new { controller = "Home", action = "Search" });

            routeBuilder.MapLocalizedRoute("ProductSearchAutoComplete", "catalog/searchtermautocomplete",
                new { controller = "Catalog", action = "SearchTermAutoComplete" });
           
            //product tags
            routeBuilder.MapLocalizedRoute("ProductTagsAll", "producttag/all/",
                new { controller = "Catalog", action = "ProductTagsAll" });

            //add product to cart (without any attributes and options). used on catalog pages.
            routeBuilder.MapLocalizedRoute("AddProductToCart-Catalog", "addproducttocart/catalog/{productId:min(0)}/{shoppingCartTypeId:min(0)}/{quantity:min(0)}",
                new { controller = "ShoppingCart", action = "AddProductToCart_Catalog" });

            //add product to cart (with attributes and options). used on the product details pages.
            routeBuilder.MapLocalizedRoute("AddProductToCart-Details", "addproducttocart/details/{productId:min(0)}/{shoppingCartTypeId:min(0)}",
                new { controller = "ShoppingCart", action = "AddProductToCart_Details" });

            //checkout pages
            routeBuilder.MapLocalizedRoute("Checkout", "checkout/",
                new { controller = "Checkout", action = "Index" });

            routeBuilder.MapLocalizedRoute("CheckoutOnePage", "onepagecheckout/",
                new { controller = "Checkout", action = "OnePageCheckout" });

            routeBuilder.MapLocalizedRoute("CheckoutShippingAddress", "checkout/shippingaddress",
                new { controller = "Checkout", action = "ShippingAddress" });

            routeBuilder.MapLocalizedRoute("CheckoutSelectShippingAddress", "checkout/selectshippingaddress",
                new { controller = "Checkout", action = "SelectShippingAddress" });

            routeBuilder.MapLocalizedRoute("CheckoutBillingAddress", "checkout/billingaddress",
                new { controller = "Checkout", action = "BillingAddress" });

            routeBuilder.MapLocalizedRoute("CheckoutSelectBillingAddress", "checkout/selectbillingaddress",
                new { controller = "Checkout", action = "SelectBillingAddress" });

            routeBuilder.MapLocalizedRoute("CheckoutShippingMethod", "checkout/shippingmethod",
                new { controller = "Checkout", action = "ShippingMethod" });

            routeBuilder.MapLocalizedRoute("CheckoutPaymentMethod", "checkout/paymentmethod",
                new { controller = "Checkout", action = "PaymentMethod" });

            routeBuilder.MapLocalizedRoute("CheckoutPaymentInfo", "checkout/paymentinfo",
                new { controller = "Checkout", action = "PaymentInfo" });

            routeBuilder.MapLocalizedRoute("CheckoutConfirm", "checkout/confirm",
                new { controller = "Checkout", action = "Confirm" });

            routeBuilder.MapLocalizedRoute("CheckoutCompleted", "checkout/completed/{orderId:int}",
                new { controller = "Checkout", action = "Completed" });

            //subscribe newsletters
            routeBuilder.MapLocalizedRoute("SubscribeNewsletter", "subscribenewsletter",
                new { controller = "Newsletter", action = "SubscribeNewsletter" });

            //email wishlist
            routeBuilder.MapLocalizedRoute("EmailWishlist", "emailwishlist",
                new { controller = "ShoppingCart", action = "EmailWishlist" });

            //login page for checkout as guest
            routeBuilder.MapLocalizedRoute("LoginCheckoutAsGuest", "login/checkoutasguest",
                new { controller = "Customer", action = "Login", checkoutAsGuest = true });

            //register result page
            routeBuilder.MapLocalizedRoute("RegisterResult", "registerresult/{resultId:min(0)}",
                new { controller = "Customer", action = "RegisterResult" });

            //check username availability
            routeBuilder.MapLocalizedRoute("CheckUsernameAvailability", "customer/checkusernameavailability",
                new { controller = "Customer", action = "CheckUsernameAvailability" });

            //passwordrecovery
            routeBuilder.MapLocalizedRoute("PasswordRecovery", "passwordrecovery",
                new { controller = "Customer", action = "PasswordRecovery" });

            //password recovery confirmation
            routeBuilder.MapLocalizedRoute("PasswordRecoveryConfirm", "passwordrecovery/confirm",
                new { controller = "Customer", action = "PasswordRecoveryConfirm" });            

            //customer account links
            routeBuilder.MapLocalizedRoute("CustomerReturnRequests", "returnrequest/history",
                new { controller = "ReturnRequest", action = "CustomerReturnRequests" });             

            routeBuilder.MapLocalizedRoute("CustomerChangePassword", "customer/changepassword",
                new { controller = "Customer", action = "ChangePassword" });

            routeBuilder.MapLocalizedRoute("CustomerAvatar", "customer/avatar",
                new { controller = "Customer", action = "Avatar" });

            routeBuilder.MapLocalizedRoute("AccountActivation", "customer/activation",
                new { controller = "Customer", action = "AccountActivation" });

            routeBuilder.MapLocalizedRoute("EmailRevalidation", "customer/revalidateemail",
                new { controller = "Customer", action = "EmailRevalidation" });

            routeBuilder.MapLocalizedRoute("CustomerAddressEdit", "customer/addressedit/{addressId:min(0)}",
                new { controller = "Customer", action = "AddressEdit" });

            routeBuilder.MapLocalizedRoute("CustomerAddressAdd", "customer/addressadd",
                new { controller = "Customer", action = "AddressAdd" });

            //customer profile page
            routeBuilder.MapLocalizedRoute("CustomerProfile", "profile/{id:min(0)}",
                new { controller = "Profile", action = "Index" });

            routeBuilder.MapLocalizedRoute("CustomerProfilePaged", "profile/{id:min(0)}/page/{pageNumber:min(0)}",
                new { controller = "Profile", action = "Index" });

            //orders
            routeBuilder.MapLocalizedRoute("OrderDetails", "orderdetails/{orderId:min(0)}",
                new { controller = "Order", action = "Details" });

            routeBuilder.MapLocalizedRoute("ShipmentDetails", "orderdetails/shipment/{shipmentId}",
                new { controller = "Order", action = "ShipmentDetails" });

            routeBuilder.MapLocalizedRoute("ReturnRequest", "returnrequest/{orderId:min(0)}",
                new { controller = "ReturnRequest", action = "ReturnRequest" });

            routeBuilder.MapLocalizedRoute("ReOrder", "reorder/{orderId:min(0)}",
                new { controller = "Order", action = "ReOrder" });

            routeBuilder.MapLocalizedRoute("GetOrderPdfInvoice", "orderdetails/pdf/{orderId}",
                new { controller = "Order", action = "GetPdfInvoice" });

            routeBuilder.MapLocalizedRoute("PrintOrderDetails", "orderdetails/print/{orderId}",
                new { controller = "Order", action = "PrintOrderDetails" });

            //order downloads
            routeBuilder.MapRoute("GetDownload", "download/getdownload/{orderItemId:guid}/{agree?}",
                new { controller = "Download", action = "GetDownload" });

            routeBuilder.MapRoute("GetLicense", "download/getlicense/{orderItemId:guid}/",
                new { controller = "Download", action = "GetLicense" });

            routeBuilder.MapLocalizedRoute("DownloadUserAgreement", "customer/useragreement/{orderItemId:guid}",
                new { controller = "Customer", action = "UserAgreement" });

            routeBuilder.MapRoute("GetOrderNoteFile", "download/ordernotefile/{ordernoteid:min(0)}",
                new { controller = "Download", action = "GetOrderNoteFile" });  

            //EU Cookie law accept button handler (AJAX link)
            routeBuilder.MapRoute("EuCookieLawAccept", "eucookielawaccept",
                new { controller = "Common", action = "EuCookieLawAccept" });
           
            //product attributes with "upload file" type
            routeBuilder.MapLocalizedRoute("UploadFileProductAttribute", "uploadfileproductattribute/{attributeId:min(0)}",
                new { controller = "ShoppingCart", action = "UploadFileProductAttribute" });

            //checkout attributes with "upload file" type
            routeBuilder.MapLocalizedRoute("UploadFileCheckoutAttribute", "uploadfilecheckoutattribute/{attributeId:min(0)}",
                new { controller = "ShoppingCart", action = "UploadFileCheckoutAttribute" });

            //return request with "upload file" support
            routeBuilder.MapLocalizedRoute("UploadFileReturnRequest", "uploadfilereturnrequest",
                new { controller = "ReturnRequest", action = "UploadFileReturnRequest" });            
        
            //sitemap (XML)
            routeBuilder.MapLocalizedRoute("sitemap.xml", "sitemap.xml",
                new { controller = "Common", action = "SitemapXml" });

            routeBuilder.MapLocalizedRoute("sitemap-indexed.xml", "sitemap-{Id:min(0)}.xml",
                new { controller = "Common", action = "SitemapXml" });
          
            //error page
            routeBuilder.MapLocalizedRoute("Error", "error",
                new { controller = "Common", action = "Error" });

            //page not found
            routeBuilder.MapLocalizedRoute("PageNotFound", "page-not-found",
                new { controller = "Common", action = "PageNotFound" });

            return routeBuilder;
        }
    }
}
