using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PrintWebSite.Entities
{
    public class PrintWebUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }

        public ClaimsIdentity GenerateUserIdentity()
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            //var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            var userIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Email", Email));
            userIdentity.AddClaim(new Claim("Picture", this.Picture != null ? this.Picture.URL : string.Empty));

            return userIdentity;
        }

        public int? PictureID { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
