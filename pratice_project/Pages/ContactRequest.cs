using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace pratice_project.Pages
{
    public class ContactRequest:PageModel
    {
        public string UserId {get;set;} = "hieunp0801@gmail.com";
        private ILogger<ContactRequest> _logger;
        public ContactRequest(ILogger<ContactRequest> logger){
            _logger = logger;
            _logger.LogInformation("Init");
        }
    }
}