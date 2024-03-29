#pragma checksum "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "400cc29bcdd6235c58855a7d78915b6285a7a89e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Index), @"mvc.1.0.view", @"/Views/Customer/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"400cc29bcdd6235c58855a7d78915b6285a7a89e", @"/Views/Customer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e406348c67424a619f0f82e2e91e8cf6778a325", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CustomerListModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
  
    ViewData["Title"] = "Customer Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>");
#nullable restore
#line 7 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n\n");
#nullable restore
#line 9 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
Write(Html.ActionLink("Yeni Müşteri Ekle", "Create", "customer"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 10 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
 if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p class=\"alert alert-success\" id=\"successMessage\">");
#nullable restore
#line 12 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
                                                  Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 13 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
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
                <th>FirstName</th>
                <th>LastName</th>
                <th>PhoneNumber</th>
                <th>Email</th>
                <th>City</th>
                <th>Güncelle</th>
                <th>Sil</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 30 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
             foreach (var c in Model.Customers)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>");
#nullable restore
#line 33 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
                   Write(c.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 34 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
                   Write(c.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 35 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
                   Write(c.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 36 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
                   Write(c.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 37 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
                   Write(c.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 38 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
                   Write(c.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td class=\"test\"><button");
            BeginWriteAttribute("id", " id=\"", 1037, "\"", 1063, 2);
            WriteAttributeValue("", 1042, "customer_update_", 1042, 16, true);
#nullable restore
#line 39 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
WriteAttributeValue("", 1058, c.Id, 1058, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 39 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
                                                                            Write(c.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" type=\"button\" class=\"btn btn-primary btn-sm customer-update\">Güncelle</button></td>\n                    <td><button");
            BeginWriteAttribute("id", " id=\"", 1196, "\"", 1222, 2);
            WriteAttributeValue("", 1201, "customer_delete_", 1201, 16, true);
#nullable restore
#line 40 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
WriteAttributeValue("", 1217, c.Id, 1217, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-id=\"");
#nullable restore
#line 40 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
                                                               Write(c.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" type=\"button\" class=\"btn btn-primary btn-sm customer-delete\">Sil</button></td>\n                </tr>\n");
#nullable restore
#line 42 "/Users/fatihuysal/Projects/TFS/dotnet-webapi-multitenancy-token-based-auth/WebUI/Views/Customer/Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>\n\n</div>\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">$(document).ready(function () {
            $("".customer-update"").click(function (e) {
                e.preventDefault();
                var customerId = $(this).data('id');
                document.location = ""/Customer/Update/"" + customerId;
            });

            $("".customer-delete"").click(function (e) {
                e.preventDefault();
                var customerId = $(this).data('id');
                if (confirm('Silmek istediğineze emin misiniz?')) {
                    var model = { id: customerId };
                    $.ajax({
                        type: ""POST"",
                        url: '/Customer/Delete',
                        //contentType: ""application/json; charset=utf-8"",
                        data: { id: customerId },
                        success: function (data) {
                            $(""#customer_delete_"" + customerId).closest('tr').remove();
                        },
                        error: function (data) {
      ");
                WriteLiteral("                      alert(\"işlem hata \")\n                        }\n                    })\n                }\n            });\n\n        });</script>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CustomerListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
