#pragma checksum "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "afe7858a091503b3dd0360da24350564b017e04c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SSCISParams_Index), @"mvc.1.0.view", @"/Views/SSCISParams/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SSCISParams/Index.cshtml", typeof(AspNetCore.Views_SSCISParams_Index))]
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
#line 1 "D:\Skola\bakalarka\ISSSC\Views\_ViewImports.cshtml"
using ISSSC;

#line default
#line hidden
#line 2 "D:\Skola\bakalarka\ISSSC\Views\_ViewImports.cshtml"
using ISSSC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afe7858a091503b3dd0360da24350564b017e04c", @"/Views/SSCISParams/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbef95dca45eb325a7cf0be8b91e8c5908baa71d", @"/Views/_ViewImports.cshtml")]
    public class Views_SSCISParams_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ISSSC.Models.SscisParam>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
  
    ViewBag.Title = "Index";
    ViewBag.ActiveMenuItem = "menu-params";

#line default
#line hidden
            BeginContext(129, 262, true);
            WriteLiteral(@"<div class=""body-content container-fluid text-center"">
    <div class=""row content"">
        <div class=""col-sm-2 sidenav"">
        </div>

        <div class=""col-sm-8 text-left"">
            <h1>Systémové parametry</h1>
            <p>
                ");
            EndContext();
            BeginContext(392, 44, false);
#line 15 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
           Write(Html.ActionLink("Přidat parametr", "Create"));

#line default
#line hidden
            EndContext();
            BeginContext(436, 143, true);
            WriteLiteral("\r\n            </p>\r\n                <table class=\"table\">\r\n                    <tr>\r\n                        <th>\r\n                            ");
            EndContext();
            BeginContext(580, 44, false);
#line 20 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.ParamKey));

#line default
#line hidden
            EndContext();
            BeginContext(624, 91, true);
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
            EndContext();
            BeginContext(716, 46, false);
#line 23 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.ParamValue));

#line default
#line hidden
            EndContext();
            BeginContext(762, 91, true);
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
            EndContext();
            BeginContext(854, 47, false);
#line 26 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(901, 97, true);
            WriteLiteral("\r\n                        </th>\r\n                        <th></th>\r\n                    </tr>\r\n\r\n");
            EndContext();
#line 31 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
                     foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1063, 96, true);
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1160, 43, false);
#line 35 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ParamKey));

#line default
#line hidden
            EndContext();
            BeginContext(1203, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1307, 45, false);
#line 38 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ParamValue));

#line default
#line hidden
            EndContext();
            BeginContext(1352, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1456, 46, false);
#line 41 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1502, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1606, 56, false);
#line 44 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
                           Write(Html.ActionLink("Upravit", "Edit", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1662, 36, true);
            WriteLiteral(" |\r\n                                ");
            EndContext();
            BeginContext(1699, 59, false);
#line 45 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
                           Write(Html.ActionLink("Detaily", "Details", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1758, 36, true);
            WriteLiteral(" |\r\n                                ");
            EndContext();
            BeginContext(1795, 57, false);
#line 46 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
                           Write(Html.ActionLink("Smazat", "Delete", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1852, 68, true);
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 49 "D:\Skola\bakalarka\ISSSC\Views\SSCISParams\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(1943, 114, true);
            WriteLiteral("\r\n                </table>\r\n</div>\r\n        <div class=\"col-sm-2 sidenav\">\r\n        </div>\r\n        </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ISSSC.Models.SscisParam>> Html { get; private set; }
    }
}
#pragma warning restore 1591
