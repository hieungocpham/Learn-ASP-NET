using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace pratice_project.Pages
{
    public class ContactRequest:PageModel
    {
        [BindProperty]
        [DisplayName("id cua user")]
        [Range(10,1000,ErrorMessage= "Nhap sai")]
        [Required]
        public int UserId {get;set;}
        [BindProperty]
        public string Email {get;set;}
        [BindProperty]
        public string Username {get;set;}
        private ILogger<ContactRequest> _logger;
        public ContactRequest(ILogger<ContactRequest> logger){
            _logger = logger;
            _logger.LogInformation("Init");
        }
    }
}