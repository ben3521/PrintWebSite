using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintWebSite.Data
{
    public class PrintWebSiteDbContext : IdentityDbContext<IdentityUser>
    {
        public PrintWebSiteDbContext(DbContextOptions<PrintWebSiteDbContext> contextOptions)
            : base(contextOptions)
        {
        }
        public PrintWebSiteDbContext()
        {
        }    
    }
}
