using System;
using System.Collections.Generic;
using System.Text;

namespace PrintWebSite.Entities
{
    public class Category : BaseEntity
    {
        public int? ParentCategoryID { get; set; }
        public virtual Category ParentCategory { get; set; }

        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public bool isFeatured { get; set; }
        public string SanitizedName { get; set; }

        public int DisplaySeqNo { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
