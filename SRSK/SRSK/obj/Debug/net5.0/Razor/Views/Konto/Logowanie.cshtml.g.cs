#pragma checksum "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Logowanie.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2e06f285dd0428789a7ebdb2765d14e05b0e796"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Konto_Logowanie), @"mvc.1.0.view", @"/Views/Konto/Logowanie.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2e06f285dd0428789a7ebdb2765d14e05b0e796", @"/Views/Konto/Logowanie.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c27d1df6a05635726cee0dc14d669d8a9519a93", @"/Views/_ViewImports.cshtml")]
    public class Views_Konto_Logowanie : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SRSK.Models.KontoModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Logowanie.cshtml"
  
    ViewData["Title"] = "Logowanie";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Logowanie.cshtml"
 using (Html.BeginForm("Logowanie", "Konto"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <article class=""container bg-light p-5 text-center"">
        <div class=""row"">
            <table class=""m-auto col-5"">
                <thead class=""border-bottom"">
                    <tr>
                        <th colspan=""2"" class=""border-bottom"">
                            <h1>Logowanie</h1>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class=""inputalert"" colspan=""2"">
                            ");
#nullable restore
#line 22 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Logowanie.cshtml"
                       Write(ViewBag.Info);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 27 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Logowanie.cshtml"
                       Write(Html.LabelFor(a => a.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 30 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Logowanie.cshtml"
                       Write(Html.TextBoxFor(a => a.Email));

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
#line 37 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Logowanie.cshtml"
                       Write(Html.LabelFor(a => a.HasloHASH));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 40 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Logowanie.cshtml"
                       Write(Html.PasswordFor(a => a.HasloHASH));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </td>
                    </tr>
                    <tr><td class=""inputalert border-bottom"" colspan=""2""> </td></tr>
                    <tr>
                        <td class=""inputalert"" colspan=""2"">
                            <br /><input type=""submit"" value=""Zaloguj si??""><br />");
#nullable restore
#line 46 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Logowanie.cshtml"
                                                                            Write(Html.ActionLink("Zarejestruj si??", "Rejestracja"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        </td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </article>\r\n");
#nullable restore
#line 53 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Logowanie.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
