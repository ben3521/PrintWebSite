using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrintWebSite.Data;
using PrintWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PrintWebSite
{
    public static class Seed
    {
        public static async Task SeedData(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            await SeedRoles(serviceProvider);
            await SeedUsers(serviceProvider);

            SeedCategories(serviceProvider);
            SeedConfigurations(serviceProvider);
        }

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            {
                //adding customs roles
                var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roleNames = { "Administrator", "Moderator", "User" };

                foreach (var roleName in roleNames)
                {
                    // creating the roles and seeding them to the database
                    var roleExist = await RoleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        await RoleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }
        }
        public static async Task SeedUsers(IServiceProvider serviceProvider)
        {
            var UserManager = serviceProvider.GetRequiredService<UserManager<PrintWebUser>>();

            PrintWebUser admin = new PrintWebUser();
            admin.FullName = "Admin";
            admin.Email = "ziyage@hotmail.com";
            admin.UserName = "admin";
            //admin.PhoneNumber = "(312)555-0690";
            //admin.Country = "Adminsburg";
            //admin.City = "Adminstria";
            //admin.Address = "404 Block D, Adm Street";
            //admin.ZipCode = "123456";
            var password = "Ld3Cm;dw!F5sX";

            var user = await UserManager.FindByEmailAsync(admin.Email);
            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(admin, password);
                if (createPowerUser.Succeeded)
                {
                    // here we assign the new user the "Admin" role 
                    await UserManager.AddToRoleAsync(admin, "Administrator");
                    await UserManager.AddToRoleAsync(admin, "Moderator");
                    await UserManager.AddToRoleAsync(admin, "User");
                }
            }
        }

        public static void SeedCategories(IServiceProvider serviceProvider)
        {
            using (var context = new PrintWebSiteDbContext(

           serviceProvider.GetRequiredService<DbContextOptions<PrintWebSiteDbContext>>()))
            {
                Category uncategorized = new Category()
                {
                    Name = "Uncategorized",
                    SanitizedName = "uncategorized",
                    Description = "Products that are not categorized. uncategorised, unclassified - not arranged in any specific grouping.",
                    DisplaySeqNo = 0,
                    ModifiedOn = DateTime.Now
                };
                context.Categories.Add(uncategorized);
                context.SaveChanges();
            }
        }

        public static void SeedConfigurations(IServiceProvider serviceProvider)
        {
            using (var context = new PrintWebSiteDbContext(

           serviceProvider.GetRequiredService<DbContextOptions<PrintWebSiteDbContext>>()))
            {
                Configuration slider1Config = new Configuration()
                {
                    Key = "Slider1",
                    Value = "site/slider/slider1.png",
                    ConfigurationType = (int)ConfigurationType.HomeSliders,
                    ModifiedOn = DateTime.Now
                };

                Configuration slider2Config = new Configuration()
                {
                    Key = "Slider2",
                    Value = "site/slider/slider2.png",
                    ConfigurationType = (int)ConfigurationType.HomeSliders,
                    ModifiedOn = DateTime.Now
                };

                Configuration slider3Config = new Configuration()
                {
                    Key = "Slider3",
                    Value = "site/slider/slider3.png",
                    ConfigurationType = (int)ConfigurationType.HomeSliders,
                    ModifiedOn = DateTime.Now
                };

                Configuration slider4Config = new Configuration()
                {
                    Key = "Slider4",
                    Value = "site/slider/slider4.png",
                    ConfigurationType = (int)ConfigurationType.HomeSliders,
                    ModifiedOn = DateTime.Now
                };

                Configuration dashboardRecordsSizePerPageConfig = new Configuration()
                {
                    Key = "DashboardRecordsSizePerPage",
                    Value = "10",
                    ConfigurationType = (int)ConfigurationType.Other,
                    ModifiedOn = DateTime.Now
                };

                Configuration frontendRecordsSizePerPageConfig = new Configuration()
                {
                    Key = "FrontendRecordsSizePerPage",
                    Value = "6",
                    ConfigurationType = (int)ConfigurationType.Other,
                    ModifiedOn = DateTime.Now
                };

                Configuration featuredRecordsSizePerPageConfig = new Configuration()
                {
                    Key = "FeaturedRecordsSizePerPage",
                    Value = "3",
                    ConfigurationType = (int)ConfigurationType.Other,
                    ModifiedOn = DateTime.Now
                };

                Configuration currencySymbolConfig = new Configuration()
                {
                    Key = "CurrencySymbol",
                    Value = "£",
                    Description = "This currency symbol is shown with prices on website and invoices.",
                    ConfigurationType = (int)ConfigurationType.Other,
                    ModifiedOn = DateTime.Now
                };

                Configuration priceCurrencyPositionConfig = new Configuration()
                {
                    Key = "PriceCurrencyPosition",
                    Value = "{price}{currency}",
                    Description = "This configuration will set price and currency relation accross the website. {price} will be replaced with the price value and {currency} will be replaced by configured currency symbol.",
                    ConfigurationType = (int)ConfigurationType.Other,
                    ModifiedOn = DateTime.Now
                };

                Configuration enableCreditCardPayment = new Configuration()
                {
                    Key = "EnableCreditCardPayment",
                    Value = "true",
                    Description = "Set value to true or 1 to enable Credit card payments or set value to 0 or false to disable credit card payments.",
                    ConfigurationType = (int)ConfigurationType.Other,
                    ModifiedOn = DateTime.Now
                };

                Configuration enableCashOnDeliveryMethod = new Configuration()
                {
                    Key = "EnableCashOnDeliveryMethod",
                    Value = "true",
                    Description = "Set value to true or 1 to enable Cash on Delivery Method or set value to 0 or false to disable Cash on Delivery Method.",
                    ConfigurationType = (int)ConfigurationType.Other,
                    ModifiedOn = DateTime.Now
                };

                Configuration flatDeliveryChargesConfig = new Configuration()
                {
                    Key = "FlatDeliveryCharges",
                    Value = "0",
                    Description = "Set the value for Delivery Charges. This is flat delivery charges rate.",
                    ConfigurationType = (int)ConfigurationType.Other,
                    ModifiedOn = DateTime.Now
                };

                context.Configurations.AddRange(new List<Configuration> { slider1Config, slider2Config, slider3Config, slider4Config, dashboardRecordsSizePerPageConfig, frontendRecordsSizePerPageConfig, featuredRecordsSizePerPageConfig, currencySymbolConfig, priceCurrencyPositionConfig, enableCreditCardPayment, enableCashOnDeliveryMethod, flatDeliveryChargesConfig });

                context.SaveChanges();
            }
        }
    }
}
