#pragma checksum "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ab7ed9f978be258f2443b51a7702de3ab6a23c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Konto_Edytuj), @"mvc.1.0.view", @"/Views/Konto/Edytuj.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab7ed9f978be258f2443b51a7702de3ab6a23c4", @"/Views/Konto/Edytuj.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c27d1df6a05635726cee0dc14d669d8a9519a93", @"/Views/_ViewImports.cshtml")]
    public class Views_Konto_Edytuj : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SRSK.Models.KontoModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
  
    ViewData["Title"] = "Edytuj";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
 using (Html.BeginForm("Edytuj", "Konto"))
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
                            <h1>Edytowanie danych</h1>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr><td class=""inputalert"" colspan=""2""></td></tr>
                    <tr>
                        <td>
                            ");
#nullable restore
#line 23 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
                       Write(Html.LabelFor(a => a.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 26 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
                       Write(Html.TextBoxFor(a => a.Email, new { @readonly = "" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </td>
                    </tr>
                    <tr><td class=""inputalert border-bottom"" colspan=""2""></td></tr>
                    <tr>
                        <td class=""inputalert"" colspan=""2"">
                            ");
#nullable restore
#line 32 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
                       Write(Html.ValidationMessageFor(a => a.Imie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 37 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
                       Write(Html.LabelFor(a => a.Imie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 40 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
                       Write(Html.TextBoxFor(a => a.Imie));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </td>
                    </tr>
                    <tr><td class=""inputalert border-bottom"" colspan=""2""></td></tr>
                    <tr>
                        <td class=""inputalert"" colspan=""2"">
                            ");
#nullable restore
#line 46 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
                       Write(Html.ValidationMessageFor(a => a.Nazwisko));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 51 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
                       Write(Html.LabelFor(a => a.Nazwisko));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 54 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
                       Write(Html.TextBoxFor(a => a.Nazwisko));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </td>
                    </tr>
                    <tr><td class=""inputalert border-bottom"" colspan=""2""></td></tr>
                    <tr>
                        <td class=""inputalert"" colspan=""2"">
                            ");
#nullable restore
#line 60 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
                       Write(Html.ValidationMessageFor(a => a.Telefon));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 65 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
                       Write(Html.LabelFor(a => a.Telefon));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 68 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
                       Write(Html.TextBoxFor(a => a.Telefon));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </td>
                    </tr>
                    <tr>
                        <td class=""inputalert border-bottom"" colspan=""2"">
                        </td>
                    </tr>
                    <tr>
                        <td class=""inputalert"" colspan=""2"">
                            <br /><input type=""submit"" value=""Zapisz""><br />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        ");
#nullable restore
#line 83 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
   Write(Html.TextBoxFor(a => a.HasloHASH, new { @style = "display: none"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </article>\r\n");
#nullable restore
#line 85 "C:\Users\Dawid\source\repos\23.12.2021\SRSK\SRSK\Views\Konto\Edytuj.cshtml"
   }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
