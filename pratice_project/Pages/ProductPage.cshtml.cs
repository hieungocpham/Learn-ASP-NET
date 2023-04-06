using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using pratice_project.Models;
using pratice_project.Services;

namespace MyApp.Namespace
{
    public class ProductPageModel : PageModel
    {
        public string message {get;set;}
        ILogger<ProductPageModel> _logger;
        public readonly ProductService _productService;
        public ProductPageModel(ILogger<ProductPageModel> logger,ProductService productService){
            _logger = logger;
            _productService = productService;
            _logger.LogInformation("Init");
        }
        public Product product {get;set;}
        public void OnGet()
        {
            if(Request.RouteValues["id"] != null){
                int id = int.Parse( Request.RouteValues["id"].ToString() );
                message = id.ToString();
                product = _productService.Find(id);
            }
            else {
                message = "Danh sach san pham";
            }
        }
        public IActionResult OnGetDelete(int? id){
            _productService.Delete(id.Value);
            return RedirectToPage("ProductPage");
        }
    }
}
