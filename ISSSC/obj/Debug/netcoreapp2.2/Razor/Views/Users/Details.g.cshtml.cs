#pragma checksum "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ab978d90d77f710d59f873b795127931858f265"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Details), @"mvc.1.0.view", @"/Views/Users/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Users/Details.cshtml", typeof(AspNetCore.Views_Users_Details))]
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
#line 2 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ab978d90d77f710d59f873b795127931858f265", @"/Views/Users/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbef95dca45eb325a7cf0be8b91e8c5908baa71d", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ISSSC.Models.SscisUser>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(66, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
  
    ViewBag.Title = SSCISResources.Resources.USER_DETAIL;
    ViewBag.ActiveMenuItem = "menu-users";

#line default
#line hidden
            BeginContext(178, 389, true);
            WriteLiteral(@"<div class=""body-content container-fluid text-center"">
    <div class=""row content"">
        <div class=""col-sm-2 sidenav"">
        </div>
        <div class=""col-sm-8 text-left"">
            <h2>Detaily</h2>

            <div>
                <h4>Uživatel</h4>
                <hr />
                <dl class=""dl-horizontal"">
                    <dt>
                        ");
            EndContext();
            BeginContext(568, 30, false);
#line 20 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                   Write(SSCISResources.Resources.LOGIN);

#line default
#line hidden
            EndContext();
            BeginContext(598, 81, true);
            WriteLiteral("\r\n                    </dt>\r\n\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(680, 37, false);
#line 24 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Login));

#line default
#line hidden
            EndContext();
            BeginContext(717, 81, true);
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt>\r\n                        ");
            EndContext();
            BeginContext(799, 29, false);
#line 28 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                   Write(SSCISResources.Resources.NAME);

#line default
#line hidden
            EndContext();
            BeginContext(828, 81, true);
            WriteLiteral("\r\n                    </dt>\r\n\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(910, 41, false);
#line 32 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Firstname));

#line default
#line hidden
            EndContext();
            BeginContext(951, 81, true);
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt>\r\n                        ");
            EndContext();
            BeginContext(1033, 33, false);
#line 36 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                   Write(SSCISResources.Resources.LASTNAME);

#line default
#line hidden
            EndContext();
            BeginContext(1066, 81, true);
            WriteLiteral("\r\n                    </dt>\r\n\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(1148, 40, false);
#line 40 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Lastname));

#line default
#line hidden
            EndContext();
            BeginContext(1188, 81, true);
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt>\r\n                        ");
            EndContext();
            BeginContext(1270, 32, false);
#line 44 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                   Write(SSCISResources.Resources.CREATED);

#line default
#line hidden
            EndContext();
            BeginContext(1302, 81, true);
            WriteLiteral("\r\n                    </dt>\r\n\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(1384, 39, false);
#line 48 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Created));

#line default
#line hidden
            EndContext();
            BeginContext(1423, 81, true);
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt>\r\n                        ");
            EndContext();
            BeginContext(1505, 39, false);
#line 52 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                   Write(SSCISResources.Resources.STUDENT_NUMBER);

#line default
#line hidden
            EndContext();
            BeginContext(1544, 81, true);
            WriteLiteral("\r\n                    </dt>\r\n\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(1626, 45, false);
#line 56 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                   Write(Html.DisplayFor(model => model.StudentNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1671, 81, true);
            WriteLiteral("\r\n                    </dd>\r\n\r\n                    <dt>\r\n                        ");
            EndContext();
            BeginContext(1753, 29, false);
#line 60 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                   Write(SSCISResources.Resources.ROLE);

#line default
#line hidden
            EndContext();
            BeginContext(1782, 81, true);
            WriteLiteral("\r\n                    </dt>\r\n\r\n                    <dd>\r\n                        ");
            EndContext();
            BeginContext(1864, 53, false);
#line 64 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                   Write(Html.DisplayFor(model => model.IdRoleNavigation.Role));

#line default
#line hidden
            EndContext();
            BeginContext(1917, 91, true);
            WriteLiteral("\r\n                    </dd>\r\n\r\n                </dl>\r\n            </div>\r\n            <p>\r\n");
            EndContext();
#line 70 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                  if (ViewContext.HttpContext.Session.GetString("role") != null && ViewContext.HttpContext.Session.GetString("role").Equals(ISSSC.Class.AuthorizationRoles.Administrator))
                    {

#line default
#line hidden
            BeginContext(2219, 23, true);
            WriteLiteral("                    <p>");
            EndContext();
            BeginContext(2243, 78, false);
#line 72 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                  Write(Html.ActionLink(@SSCISResources.Resources.EDIT, "Edit", new { id = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(2321, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(2325, 56, false);
#line 72 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                                                                                                    Write(Html.ActionLink(@SSCISResources.Resources.BACK, "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(2381, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 73 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(2447, 23, true);
            WriteLiteral("                    <p>");
            EndContext();
            BeginContext(2471, 56, false);
#line 76 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                  Write(Html.ActionLink(@SSCISResources.Resources.BACK, "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(2527, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 77 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Users\Details.cshtml"
                }
                

#line default
#line hidden
            BeginContext(2571, 134, true);
            WriteLiteral("                </p>\r\n            </div>\r\n            <div class=\"col-sm-2 sidenav\">\r\n\r\n            </div>\r\n        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ISSSC.Models.SscisUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
