using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using razorweb.Models;

namespace razorweb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyBlogContext _myBlogContext;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,MyBlogContext myBlogContext)
        {
            _logger = logger;
            _myBlogContext = myBlogContext;
        }

        public void OnGet()
        {
            List<Article> articles = (from a in _myBlogContext.articles
                                    orderby a.PublishDate descending 
                                    select a).ToList();
            ViewData["posts"] = articles; 
        }
    }
}
