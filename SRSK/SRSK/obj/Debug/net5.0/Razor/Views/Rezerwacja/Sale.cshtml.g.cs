#pragma checksum "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Sale.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a87d188492b9e4c9c43dc6334b1560c3c6bd7d3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rezerwacja_Sale), @"mvc.1.0.view", @"/Views/Rezerwacja/Sale.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a87d188492b9e4c9c43dc6334b1560c3c6bd7d3f", @"/Views/Rezerwacja/Sale.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c27d1df6a05635726cee0dc14d669d8a9519a93", @"/Views/_ViewImports.cshtml")]
    public class Views_Rezerwacja_Sale : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SRSK.Models.SalaModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Sale.cshtml"
  
    ViewData["Title"] = "Sale";

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
                        <h1>Wyb??r sali</h1>
                    </th>
                </tr>
                <tr>
                    <th>
                        Numer sali
                    </th>
                    <th>
                        Ilo???? miejsc
                    </th>
                    <th>
                        Pi??tro
                    </th>
                    <th>
                        Informacje
                    </th>
                    <th>
                        Wybierz sale
                    </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 35 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Sale.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"border-bottom\">\r\n                        <td class=\"col-2\">");
#nullable restore
#line 38 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Sale.cshtml"
                                     Write(Html.DisplayFor(modelItem => item.NrSali));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"col-2\">");
#nullable restore
#line 39 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Sale.cshtml"
                                     Write(Html.DisplayFor(modelItem => item.IloscMiejsc));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"col-2\">");
#nullable restore
#line 40 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Sale.cshtml"
                                     Write(Html.DisplayFor(modelItem => item.Pietro));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"col-2\">");
#nullable restore
#line 41 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Sale.cshtml"
                                     Write(Html.DisplayFor(modelItem => item.Informacje));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td class=\"col-2\">");
#nullable restore
#line 42 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Sale.cshtml"
                                     Write(Html.ActionLink("WYBIERAM", "RezerwowanieKoniec", new { IdB = item.IdBudynek, IdS = item.Id, DataOd = ViewBag.DataOd, DataDo = ViewBag.DataDo }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 44 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Rezerwacja\Sale.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</article>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SRSK.Models.SalaModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
