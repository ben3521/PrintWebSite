﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintWebSite.ViewModels
{
    public class PageViewModel
    {
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
        public string PageURL { get; set; }
        public string PageImageURL { get; set; }

        public List<string> PageCanonicalURLs { get; set; } // = new List<string>();

        public PageViewModel()
        {
            PageCanonicalURLs = new List<string>();
        }
    }

    public class CommentablePageViewModel : PageViewModel
    {
        public int EntityID { get; set; }
        public int RecordID { get; set; }

        //public List<Comment> Comments { get; set; }
    }

    /// <summary>
    /// http://jasonwatmore.com/post/2015/10/30/aspnet-mvc-pagination-example-with-logic-like-google
    /// </summary>
    public class Pager
    {
        public Pager()
        {

        }
        private readonly IConfiguration configuration;

        public Pager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Pager(int totalItems, int? page, int pageSize = 10)
        {
            if (pageSize == 0) pageSize = int.Parse(configuration.GetSection("DashboardRecordsSizePerPage").Value);

            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }

}
