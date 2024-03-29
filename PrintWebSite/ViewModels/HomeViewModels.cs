﻿using PrintWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintWebSite.ViewModels
{
    public class ProductsViewModel : PageViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<Category> SearchedCategories { get; set; }

        public string SearchTerm { get; set; }

        public bool isPartial { get; set; }

        public Pager Pager { get; set; }
        public int PageNo { get; set; }
    }

    public class CartProductsViewModel
    {
        public List<int> ProductIDs { get; set; }
        public List<Product> Products { get; set; }
    }

    public class FilterProductsViewModel
    {
        public List<Product> Products { get; set; }
        public Pager Pager { get; set; }
        public int? SortBy { get; set; }
        public int? CategoryID { get; set; }
        public string SearchTerm { get; set; }
    }


    public class QueryStringViewModel
    {
        public string Category { get; set; }
        public string q { get; set; }
        public int? PageNo { get; set; }

        //string category, string q, int? pageNo, bool isPartial = false
    }
}
