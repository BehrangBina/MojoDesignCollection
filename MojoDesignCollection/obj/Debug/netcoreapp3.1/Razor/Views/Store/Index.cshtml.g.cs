#pragma checksum "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85efb337d929b97bcc95a077b11e87138219d276"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Store_Index), @"mvc.1.0.view", @"/Views/Store/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85efb337d929b97bcc95a077b11e87138219d276", @"/Views/Store/Index.cshtml")]
    public class Views_Store_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MojoDesignCollection.Models.ModelView.ProductListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(" \r\n\r\n");
#nullable restore
#line 4 "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Store_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"storemain\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 12 "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml"
             foreach (var product in Model.Products)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-md-4 mdc"">
                    <div class=""card mb-4 shadow-sm"">
                        <svg class=""bd-placeholder-img card-img-top"" width=""100%"" height=""225""
                             xmlns=""http://www.w3.org/2000/svg"" preserveAspectRatio=""xMidYMid slice"" focusable=""false""
                             role=""img"" aria-label=""Placeholder: Doll"">
                            <title>Placeholder</title>
                            <rect width=""100%"" height=""100%"" fill=""#55595c""></rect>
                            <text x=""50%"" y=""50%"" fill=""#eceeef""
                                  dy="".3em"">Thumbnail</text>
                        </svg>
                        <div class=""card-body"">
                            <h4>");
#nullable restore
#line 25 "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml"
                           Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                            <p>");
#nullable restore
#line 26 "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml"
                          Write(product.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p class=\"card-text\">");
#nullable restore
#line 27 "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml"
                                            Write(product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

                            <div class=""d-flex justify-content-between align-items-center"">
                                <div class=""btn-group"">
                                    <button type=""button"" class=""btn btn-sm btn-outline-secondary"">View</button>
                                    <button type=""button"" class=""btn btn-outline-primary"">
                                        <svg width=""1em"" height=""1em"" viewBox=""0 0 16 16"" class=""bi bi-cart-plus-fill"" fill=""currentColor"" xmlns=""http://www.w3.org/2000/svg"">
                                            <path fill-rule=""evenodd"" d=""M.5 1a.5.5 0 0 0 0 1h1.11l.401 1.607 1.498 7.985A.5.5 0 0 0 4 12h1a2 2 0 1 0 0 4 2 2 0 0 0 0-4h7a2 2 0 1 0 0 4 2 2 0 0 0 0-4h1a.5.5 0 0 0 .491-.408l1.5-8A.5.5 0 0 0 14.5 3H2.89l-.405-1.621A.5.5 0 0 0 2 1H.5zM4 14a1 1 0 1 1 2 0 1 1 0 0 1-2 0zm7 0a1 1 0 1 1 2 0 1 1 0 0 1-2 0zM9 5.5a.5.5 0 0 0-1 0V7H6.5a.5.5 0 0 0 0 1H8v1.5a.5.5 0 0 0 1 0V8h1.5a.5.5 0 0 0 0-1H9V5.5z""></path>
                                   ");
            WriteLiteral("     </svg>\r\n                                    </button>\r\n                                </div>\r\n                                <small class=\"text-muted\">");
#nullable restore
#line 38 "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml"
                                                     Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 43 "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <br />\r\n        <hr />\r\n\r\n");
            WriteLiteral("        \r\n        <div class=\"d-flex justify-content-center mdc-pagination\">\r\n            <ul class=\"pagination pagination-circle pagination-md\">\r\n");
#nullable restore
#line 72 "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml"
                   var pagingInfo = Model.PagingInfo; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml"
                 for (int pn = 1; pn <= Model.PagingInfo.TotalPages; pn++)
                {
                         

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4088, "\"", 4111, 2);
            WriteAttributeValue("", 4095, "?productPage=", 4095, 13, true);
#nullable restore
#line 76 "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml"
WriteAttributeValue("", 4108, pn, 4108, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 76 "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml"
                                                                                   Write(pn);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a></li>\r\n");
#nullable restore
#line 77 "D:\Work\MojoDesignCollection\MojoDesignCollection\Views\Store\Index.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </div>\r\n        </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MojoDesignCollection.Models.ModelView.ProductListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591