#pragma checksum "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c142d26164e70a8727c0163ad9b53c61ae8d5285"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(razorweb.Pages.Shared.Pages_Shared__Paging), @"mvc.1.0.view", @"/Pages/Shared/_Paging.cshtml")]
namespace razorweb.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\_ViewImports.cshtml"
using razorweb;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c142d26164e70a8727c0163ad9b53c61ae8d5285", @"/Pages/Shared/_Paging.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"040acca3ec23ee606eaf94011da5c45b77c35024", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__Paging : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<razorweb.Helpers.PaginateModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
  
    int currentPage  = Model.currentPage;
    int countPages   = Model.countPages;
    var generateUrl  = Model.generateUrl;
    
    if (currentPage > countPages) 
      currentPage = countPages;

    if (countPages <= 1) return;
    

    int? preview = null;
    int? next = null;

    if (currentPage > 1)
        preview = currentPage - 1;

    if (currentPage < countPages)
        next = currentPage + 1;

    // Các trang hiện thị trong điều hướng
    List<int> pagesRanges = new List<int>();    

        
    int delta      = 5;             // Số trang mở rộng về mỗi bên trang hiện tại     
    int remain     = delta * 2;     // Số trang hai bên trang hiện tại

    pagesRanges.Add(currentPage);
    // Các trang phát triển về hai bên trang hiện tại
    for (int i = 1; i <= delta; i++)
    {
        if (currentPage + i  <= countPages) {
            pagesRanges.Add(currentPage + i); 
            remain --;
        }
               
        if (currentPage - i >= 1) {
            pagesRanges.Insert(0, currentPage - i);
            remain --;
        }
            
    }    
    // Xử lý thêm vào các trang cho đủ remain 
    //(xảy ra ở đầu mút của khoảng trang không đủ trang chèn  vào)
    if (remain > 0) {
        if (pagesRanges[0] == 1) {
            for (int i = 1; i <= remain; i++)
            {
                if (pagesRanges.Last() + 1 <= countPages) {
                    pagesRanges.Add(pagesRanges.Last() + 1);
                }
            }
        }
        else {
            for (int i = 1; i <= remain; i++)
            {
                if (pagesRanges.First() - 1 > 1) {
                    pagesRanges.Insert(0, pagesRanges.First() - 1);
                }
            }
        }
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<ul class=\"pagination\">\r\n    <!-- Previous page link -->\r\n");
#nullable restore
#line 78 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
     if (preview != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">\r\n            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2216, "\"", 2244, 1);
#nullable restore
#line 81 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
WriteAttributeValue("", 2223, generateUrl(preview), 2223, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Trang trước</a>\r\n        </li>\r\n");
#nullable restore
#line 83 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item disabled\">\r\n            <a class=\"page-link\" href=\"#\" tabindex=\"-1\" aria-disabled=\"true\">Trang trước</a>\r\n        </li>\r\n");
#nullable restore
#line 89 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("      \r\n    <!-- Numbered page links -->\r\n");
#nullable restore
#line 92 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
     foreach (var pageitem in pagesRanges)
    {
        if (pageitem != currentPage) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\">\r\n                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2664, "\"", 2693, 1);
#nullable restore
#line 96 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
WriteAttributeValue("", 2671, generateUrl(pageitem), 2671, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
#nullable restore
#line 97 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
               Write(pageitem);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </a>\r\n            </li>\r\n");
#nullable restore
#line 100 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
        }   
        else 
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item active\" aria-current=\"page\">\r\n                <a class=\"page-link\" href=\"#\">");
#nullable restore
#line 104 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
                                         Write(pageitem);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"sr-only\">(current)</span></a>\r\n            </li>\r\n");
#nullable restore
#line 106 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <!-- Next page link -->\r\n");
#nullable restore
#line 111 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
     if (next != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">\r\n            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3137, "\"", 3162, 1);
#nullable restore
#line 114 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
WriteAttributeValue("", 3144, generateUrl(next), 3144, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Trang sau</a>\r\n        </li>\r\n");
#nullable restore
#line 116 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
    }
    else 
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item disabled\">\r\n            <a class=\"page-link\" href=\"#\" tabindex=\"-1\" aria-disabled=\"true\">Trang sau</a>\r\n        </li>\r\n");
#nullable restore
#line 122 "C:\Users\Admin\Desktop\New folder\Learn-ASP-NET\razorweb\Pages\Shared\_Paging.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<razorweb.Helpers.PaginateModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
