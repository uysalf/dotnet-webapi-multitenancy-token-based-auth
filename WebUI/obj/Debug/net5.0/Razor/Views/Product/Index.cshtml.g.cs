#pragma checksum "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c89a0728e7013ddeca98922dda84af64662084c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#nullable restore
#line 1 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/_ViewImports.cshtml"
using WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/_ViewImports.cshtml"
using WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c89a0728e7013ddeca98922dda84af64662084c", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e406348c67424a619f0f82e2e91e8cf6778a325", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
  
    ViewData["Title"] = "Product Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>");
#nullable restore
#line 7 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n\n");
#nullable restore
#line 9 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
Write(Html.ActionLink("Yeni Ürün Ekle", "Create", "Product"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
#nullable restore
#line 11 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
 if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"alert alert-success\" id=\"successMessage\">");
#nullable restore
#line 13 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
                                                  Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 14 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""container"">
    <table class=""table"">
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Price</th>
                <th>Description</th>
                <th>Güncelle</th>
                <th>Sil</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 30 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
             foreach (var p in Model.Products)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>");
#nullable restore
#line 33 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
                   Write(p.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 34 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
                   Write(p.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 35 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
                   Write(p.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 36 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
                   Write(p.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td class=\"test\"><button");
            BeginWriteAttribute("id", " id=\"", 880, "\"", 905, 2);
            WriteAttributeValue("", 885, "product_update_", 885, 15, true);
#nullable restore
#line 37 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
WriteAttributeValue("", 900, p.Id, 900, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 37 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
                                                                           Write(p.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" type=\"button\" class=\"btn btn-primary btn-sm product-update\">Güncelle</button></td>\n                    <td><button");
            BeginWriteAttribute("id", " id=\"", 1037, "\"", 1062, 2);
            WriteAttributeValue("", 1042, "product_delete_", 1042, 15, true);
#nullable restore
#line 38 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
WriteAttributeValue("", 1057, p.Id, 1057, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 38 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
                                                              Write(p.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" type=\"button\" class=\"btn btn-primary btn-sm product-delete\">Sil</button></td>\n                </tr>\n");
#nullable restore
#line 40 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Product/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>\n\n</div>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">$(document).ready(function () {
            $("".product-update"").click(function (e) {
                e.preventDefault();
                var productId = $(this).data('id');
                document.location = ""/Product/Update/"" + productId;
            });

            $("".product-delete"").click(function (e) {
                e.preventDefault();
                var productId = $(this).data('id');
                if (confirm('Silmek istediğineze emin misiniz?')) {
                    var model = { id: productId };
                    $.ajax({
                        type: ""POST"",
                        url: '/Product/Delete',
                        //contentType: ""application/json; charset=utf-8"",
                        data: { id: productId },
                        success: function (data) {
                            $(""#product_delete_"" + productId).closest('tr').remove();
                        },
                        error: function (data) {
                 ");
                WriteLiteral("           alert(\"işlem hata \")\n                        }\n                    })\n                }\n            });\n\n        });</script>\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
