#pragma checksum "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Budynki.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa3d65051922c563d049cb6f419be83a3dbcd604"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rezerwacja_Budynki), @"mvc.1.0.view", @"/Views/Rezerwacja/Budynki.cshtml")]
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
#line 1 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\_ViewImports.cshtml"
using SRSK;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\_ViewImports.cshtml"
using SRSK.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa3d65051922c563d049cb6f419be83a3dbcd604", @"/Views/Rezerwacja/Budynki.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c27d1df6a05635726cee0dc14d669d8a9519a93", @"/Views/_ViewImports.cshtml")]
    public class Views_Rezerwacja_Budynki : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SRSK.Models.BudynekWybor>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Budynki.cshtml"
  
    ViewData["Title"] = "Budynki";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<article class=""container bg-light p-5 text-center"">
    <div class=""row"">
        <table class=""m-auto col-12"">
            <thead class=""border-bottom"">
                <tr>
                    <th colspan=""5"" class=""border-bottom"">
                        <h1>Wybór budynku</h1>
                    </th>
                </tr>
                <tr>
                    <th>
                        Symbol
                    </th>
                    <th>
                        Miasto
                    </th>
                    <th>
                        Adres
                    </th>
                    <th>
                        Informacje
                    </th>
                    <th>
                        Dostępność sal
                    </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 35 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Budynki.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"border-bottom\">\r\n                        <td class=\"col-2\">");
#nullable restore
#line 38 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Budynki.cshtml"
                                     Write(Html.DisplayFor(modelItem => item.Symbol));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"col-2\">");
#nullable restore
#line 39 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Budynki.cshtml"
                                     Write(Html.DisplayFor(modelItem => item.Miasto));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"col-2\">");
#nullable restore
#line 40 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Budynki.cshtml"
                                     Write(Html.DisplayFor(modelItem => item.Adres));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"col-2\">");
#nullable restore
#line 41 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Budynki.cshtml"
                                     Write(Html.DisplayFor(modelItem => item.Informacje));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"col-2\">");
#nullable restore
#line 42 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Budynki.cshtml"
                                     Write(Html.ActionLink("(" + @item.IloscSal.ToString() + ") WYBIERAM", "Sale", new { IdB = item.Id, DataOd = ViewBag.DataOd, DataDo = ViewBag.DataDo }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 44 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Budynki.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</article>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SRSK.Models.BudynekWybor>> Html { get; private set; }
    }
}
#pragma warning restore 1591