#pragma checksum "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "475bf5d21108a92b8f9f382b1d40e7a8fafc9389"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Konto_Informacje), @"mvc.1.0.view", @"/Views/Konto/Informacje.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"475bf5d21108a92b8f9f382b1d40e7a8fafc9389", @"/Views/Konto/Informacje.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c27d1df6a05635726cee0dc14d669d8a9519a93", @"/Views/_ViewImports.cshtml")]
    public class Views_Konto_Informacje : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SRSK.Models.KontoModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
  
    ViewData["Title"] = "Informacje";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<article class=""container bg-light p-5 text-center"">
    <div class=""row"">
        <table class=""m-auto col-5"">
            <thead class=""border-bottom"">
                <tr>
                    <th colspan=""2"" class=""border-bottom"">
                        <h1>Twoje konto</h1>
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class=""inputalert"" colspan=""2"">
                        ");
#nullable restore
#line 20 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(ViewBag.Info);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 25 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(Html.LabelFor(a => a.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 28 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(Model.Email.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </td>
                </tr>
                <tr><td class=""inputalert border-bottom"" colspan=""2""></td></tr>
                <tr><td class=""inputalert"" colspan=""2""></td></tr>
                <tr>
                    <td>
                        ");
#nullable restore
#line 35 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(Html.LabelFor(a => a.Imie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 38 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(Model.Imie.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </td>
                </tr>
                <tr><td class=""inputalert border-bottom"" colspan=""2""></td></tr>
                <tr><td class=""inputalert"" colspan=""2""></td></tr>
                <tr>
                    <td>
                        ");
#nullable restore
#line 45 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(Html.LabelFor(a => a.Nazwisko));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 48 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(Model.Nazwisko.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </td>
                </tr>
                <tr><td class=""inputalert border-bottom"" colspan=""2""></td></tr>
                <tr><td class=""inputalert"" colspan=""2""></td></tr>
                <tr>
                    <td>
                        ");
#nullable restore
#line 55 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(Html.LabelFor(a => a.Telefon));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 58 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(Model.Telefon.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n                <tr><td class=\"inputalert border-bottom\" colspan=\"2\"></td></tr>\r\n                <tr>\r\n                    <td class=\"inputalert\" colspan=\"2\">\r\n                        <br />");
#nullable restore
#line 64 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                         Write(Html.ActionLink("Wyloguj się", "LogOut"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
#nullable restore
#line 64 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                                                                     Write(Html.ActionLink("Edytuj Dane", "Edytuj"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        <a href=\"../Pracownik/Index\">");
#nullable restore
#line 65 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                                                Write(ViewBag.pracownik);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class=""row"">
        <table class=""m-auto col-12"">
            <thead class=""border-bottom"">
                <tr><td class=""inputalert"" colspan=""5""></td></tr>
                <tr>
                    <td colspan=""5"">
                        <h2>Twoje rezerwacje</h2>
                    </td>
                </tr>
                <tr><td class=""inputalert border-bottom"" colspan=""5""></td></tr>
                <tr>
                    <th class=""col-2"">
                        Budynek
                    </th>
                    <th class=""col-2"">
                        Sala
                    </th>
                    <th class=""col-3"">
                        Od
                    </th>
                    <th class=""col-3"">
                        Do
                    </th>
                    <th class=""col-2"">
                        Usuwanie
                   ");
            WriteLiteral(" </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 100 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
            foreach (var item in ViewBag.mojerezerwacje)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"border-bottom\">\r\n                    <td>\r\n                        ");
#nullable restore
#line 104 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(item.Budynek);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 107 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(item.Sala);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 110 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(item.DataOd);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 113 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(item.DataDo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 116 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
                   Write(Html.ActionLink("Usuń", "Usun", "Rezerwacja", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 119 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Informacje.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SRSK.Models.KontoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
