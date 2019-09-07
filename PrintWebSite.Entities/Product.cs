using System;
using System.Collections.Generic;
using System.Text;

namespace PrintWebSite.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool isFeatured { get; set; }
        public int ThumbnailPictureID { get; set; }

        public virtual List<ProductPicture> ProductPictures { get; set; }
    }
}
