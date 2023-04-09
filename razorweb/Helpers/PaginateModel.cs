using System;

namespace razorweb.Helpers
{
    public class PaginateModel
    {
        public int currentPage {get;set;}
        public int countPages {get;set;} 
        public Func<int?,string> generateUrl {get;set;}
    }
}