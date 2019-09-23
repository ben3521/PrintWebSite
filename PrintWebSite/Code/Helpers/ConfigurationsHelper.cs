using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintWebSite.Code.Helpers
{
    public class ConfigurationsHelper
    {
        private readonly IConfiguration _configuration;
        public ConfigurationsHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public string GetConfigurationByKey(string key)
        //{
        //    return _configuration.GetValue<string>("CurrencySymbol"); 
        //}                    
        
        //private string GetConfigValue(string key)
        //{
        //    try
        //    {
        //        return _configuration.GetValue<string>(key); 
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //}
        //public string ApplicationName { get { return GetConfigValue("ApplicationName"); } }
        //public string Address { get { return GetConfigValue("Address"); } }
        //public string PhoneNumber { get { return GetConfigValue("PhoneNumber"); } }
        //public string MobileNumber { get { return GetConfigValue("MobileNumber"); } }
        //public string FacebookURL { get { return GetConfigValue("FacebookURL"); } }
        //public string TwitterUsername { get { return GetConfigValue("TwitterUsername"); } }
        //public string TwitterURL { get { return GetConfigValue("TwitterURL"); } }
        //public string WhatsAppNumber { get { return GetConfigValue("WhatsAppNumber"); } }
        //public string InstagramURL { get { return GetConfigValue("InstagramURL"); } }
        //public string YouTubeURL { get { return GetConfigValue("YouTubeURL"); } }
        //public string LinkedInURL { get { return GetConfigValue("LinkedInURL"); } }


        //public int DashboardRecordsSizePerPage()
        //{
        //    var value = _configuration.GetValue<string>("DashboardRecordsSizePerPage");
        //    if (!_DashboardRecordsSizePerPage.HasValue)
        //    {
        //        //var config = ConfigurationsService.Instance.GetConfigurationByKey("DashboardRecordsSizePerPage");
        //        var config = _configuration.GetValue<string>("DashboardRecordsSizePerPage");

        //        if (config != null)
        //        {
        //            _DashboardRecordsSizePerPage = int.Parse(config);
        //        }
        //        else _DashboardRecordsSizePerPage = 0;
        //    }

        //    return _DashboardRecordsSizePerPage.Value;
        //}

        //private static int? _DashboardRecordsSizePerPage { get; set; }
        //public int DashboardRecordsSizePerPage
        //{
        //    get
        //    {
        //        if (!_DashboardRecordsSizePerPage.HasValue)
        //        {
        //            //var config = ConfigurationsService.Instance.GetConfigurationByKey("DashboardRecordsSizePerPage");
        //            var config = _configuration.GetValue<string>("DashboardRecordsSizePerPage");                    

        //            if (config != null)
        //            {
        //                _DashboardRecordsSizePerPage = int.Parse(config);
        //            }
        //            else _DashboardRecordsSizePerPage = 0;
        //        }

        //        return _DashboardRecordsSizePerPage.Value;
        //    }
        //}

        private static int? _FeaturedRecordsSizePerPage { get; set; }
        public int FeaturedRecordsSizePerPage
        {
            get
            {
                if (!_FeaturedRecordsSizePerPage.HasValue)
                {
                    //var config = ConfigurationsService.Instance.GetConfigurationByKey("FeaturedRecordsSizePerPage");
                    var config = _configuration.GetValue<string>("FeaturedRecordsSizePerPage");

                    if (config != null)
                    {
                        _FeaturedRecordsSizePerPage = int.Parse(config);
                    }
                    else _FeaturedRecordsSizePerPage = 0;
                }

                return _FeaturedRecordsSizePerPage.Value;
            }
        }

        private static int? _FrontendRecordsSizePerPage { get; set; }
        public int FrontendRecordsSizePerPage
        {
            get
            {
                if (!_FrontendRecordsSizePerPage.HasValue)
                {
                    //var config = ConfigurationsService.Instance.GetConfigurationByKey("FrontendRecordsSizePerPage");
                    var config = _configuration.GetValue<string>("FrontendRecordsSizePerPage");

                    if (config != null)
                    {
                        _FrontendRecordsSizePerPage = int.Parse(config);
                    }
                    else _FrontendRecordsSizePerPage = 0;
                }

                return _FrontendRecordsSizePerPage.Value;
            }
        }

        private static string _CurrencySymbol { get; set; }
        public string CurrencySymbol
        {
            get
            {
                if (string.IsNullOrEmpty(_CurrencySymbol))
                {
                    //var config = ConfigurationsService.Instance.GetConfigurationByKey("CurrencySymbol");
                    var config = _configuration.GetValue<string>("CurrencySymbol");

                    if (config != null)
                    {
                        _CurrencySymbol = config;
                    }
                    else _CurrencySymbol = "$"; //Default CurrencySymbol is set to US $. 
                }

                return _CurrencySymbol;
            }
        }

        //private static string _PriceCurrencyPosition { get; set; }
        //public static string PriceCurrencyPosition
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(_PriceCurrencyPosition))
        //        {
        //            var config = ConfigurationsService.Instance.GetConfigurationByKey("PriceCurrencyPosition");

        //            if (config != null)
        //            {
        //                _PriceCurrencyPosition = config.Value;
        //            }
        //            else _PriceCurrencyPosition = "{currency}{price}";
        //        }

        //        return _PriceCurrencyPosition;
        //    }
        //}

        //private static bool? _EnableCreditCardPayment { get; set; }
        //public static bool EnableCreditCardPayment
        //{
        //    get
        //    {
        //        if (!_EnableCreditCardPayment.HasValue)
        //        {
        //            var config = ConfigurationsService.Instance.GetConfigurationByKey("EnableCreditCardPayment");

        //            if (config != null)
        //            {
        //                _EnableCreditCardPayment = bool.Parse(config.Value);
        //            }
        //            else _EnableCreditCardPayment = true;
        //        }

        //        return _EnableCreditCardPayment.Value;
        //    }
        //}

        //private static bool? _EnableCashOnDeliveryMethod { get; set; }
        //public static bool EnableCashOnDeliveryMethod
        //{
        //    get
        //    {
        //        if (!_EnableCashOnDeliveryMethod.HasValue)
        //        {
        //            var config = ConfigurationsService.Instance.GetConfigurationByKey("EnableCashOnDeliveryMethod");

        //            if (config != null)
        //            {
        //                _EnableCashOnDeliveryMethod = bool.Parse(config.Value);
        //            }
        //            else _EnableCashOnDeliveryMethod = true;
        //        }

        //        return _EnableCashOnDeliveryMethod.Value;
        //    }
        //}

        //private static decimal? _FlatDeliveryCharges { get; set; }
        //public static decimal FlatDeliveryCharges
        //{
        //    get
        //    {
        //        if (!_FlatDeliveryCharges.HasValue)
        //        {
        //            var config = ConfigurationsService.Instance.GetConfigurationByKey("FlatDeliveryCharges");

        //            if (config != null)
        //            {
        //                _FlatDeliveryCharges = decimal.Parse(config.Value);
        //            }
        //            else _FlatDeliveryCharges = 0;
        //        }

        //        return _FlatDeliveryCharges.Value;
        //    }
        //}
        //public static decimal Discount
        //{
        //    get
        //    {
        //        return 0;
        //    }
        //}
    }
}
