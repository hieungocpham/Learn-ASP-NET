using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razorweb.Models;

namespace razorweb.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly razorweb.Models.MyBlogContext _context;
        public const int ITEMS_PER_PAGE = 2;
        // Binding currentPage voi ?pages = currentPage
        [BindProperty(SupportsGet = true, Name = "pages")]
        public int currentPage {get;set;}
        public int countPages {get;set;} 

        public IndexModel(razorweb.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            int totalArticle = await _context.articles.CountAsync();
            countPages = (int) Math.Ceiling((double)totalArticle/ITEMS_PER_PAGE);
            if(currentPage < 1){
                currentPage = 1;
            }
            Console.WriteLine(countPages +" "+ currentPage);
            var qr = (from a in _context.articles 
                        orderby a.PublishDate descending
                        select a)
                        .Skip((currentPage-1)*ITEMS_PER_PAGE)
                        .Take(ITEMS_PER_PAGE)
                        ;
                        
            Article = await qr.ToListAsync();
        }
    }
}
