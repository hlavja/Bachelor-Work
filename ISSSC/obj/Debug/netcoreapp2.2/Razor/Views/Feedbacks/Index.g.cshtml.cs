#pragma checksum "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Feedbacks\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8cdbc42324b9fb7e52d985a0e4821030c8dcfc82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Feedbacks_Index), @"mvc.1.0.view", @"/Views/Feedbacks/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Feedbacks/Index.cshtml", typeof(AspNetCore.Views_Feedbacks_Index))]
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
#line 1 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\_ViewImports.cshtml"
using ISSSC;

#line default
#line hidden
#line 2 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\_ViewImports.cshtml"
using ISSSC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cdbc42324b9fb7e52d985a0e4821030c8dcfc82", @"/Views/Feedbacks/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbef95dca45eb325a7cf0be8b91e8c5908baa71d", @"/Views/_ViewImports.cshtml")]
    public class Views_Feedbacks_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ISSSC.Models.Feedback>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Feedbacks\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
            BeginContext(82, 248, true);
            WriteLiteral("<div class=\"body-content container-fluid text-center\">\r\n    <div class=\"row content\">\r\n        <div class=\"col-sm-2 sidenav\">\r\n        </div>\r\n        <div class=\"col-sm-8 text-left\">\r\n            <h2>Index</h2>\r\n\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(331, 39, false);
#line 14 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Feedbacks\Index.cshtml"
           Write(Html.ActionLink("Create New", "Create"));

#line default
#line hidden
            EndContext();
            BeginContext(370, 127, true);
            WriteLiteral("\r\n            </p>\r\n            <table class=\"table\">\r\n                <tr>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(498, 40, false);
#line 19 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Feedbacks\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Text));

#line default
#line hidden
            EndContext();
            BeginContext(538, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(618, 64, false);
#line 22 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Feedbacks\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.IdParticipationNavigation.Id));

#line default
#line hidden
            EndContext();
            BeginContext(682, 85, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n\r\n");
            EndContext();
#line 27 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Feedbacks\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(832, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(917, 39, false);
#line 31 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Feedbacks\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Text));

#line default
#line hidden
            EndContext();
            BeginContext(956, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1048, 63, false);
#line 34 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Feedbacks\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.IdParticipationNavigation.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1111, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1203, 53, false);
#line 37 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Feedbacks\Index.cshtml"
                       Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1256, 32, true);
            WriteLiteral(" |\r\n                            ");
            EndContext();
            BeginContext(1289, 59, false);
#line 38 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Feedbacks\Index.cshtml"
                       Write(Html.ActionLink("Details", "Details", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1348, 32, true);
            WriteLiteral(" |\r\n                            ");
            EndContext();
            BeginContext(1381, 57, false);
#line 39 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Feedbacks\Index.cshtml"
                       Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1438, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 42 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Feedbacks\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(1517, 116, true);
            WriteLiteral("\r\n            </table>\r\n        </div>\r\n        <div class=\"col-sm-2 sidenav\">\r\n\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ISSSC.Models.Feedback>> Html { get; private set; }
    }
}
#pragma warning restore 1591
