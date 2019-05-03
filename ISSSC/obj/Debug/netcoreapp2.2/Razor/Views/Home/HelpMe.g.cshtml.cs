#pragma checksum "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9a73cbe072d9ae822b892ce048685ab72abee9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_HelpMe), @"mvc.1.0.view", @"/Views/Home/HelpMe.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/HelpMe.cshtml", typeof(AspNetCore.Views_Home_HelpMe))]
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
#line 2 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9a73cbe072d9ae822b892ce048685ab72abee9d", @"/Views/Home/HelpMe.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbef95dca45eb325a7cf0be8b91e8c5908baa71d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_HelpMe : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ISSSC.Models.Meta.MetaEvent>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
  
    ViewBag.ActiveMenuItem = "menu-helpme";

#line default
#line hidden
            BeginContext(123, 498, true);
            WriteLiteral(@"<div class=""row content"">
    <div class=""col-sm-2 sidenav"">
    </div>

    <div class=""col-sm-8 text-left"">
        <h1>Potřebuji pomoc</h1>
        <p>Přijít můžete do studovny FAV (<a href=""https://drive.google.com/open?id=1tuebFsEvUDw3HhLc6PJtB0nnRfJTe5Bt&usp=sharing"" target=""_blank"">kudy k nám</a>), kde budou probíhat konzultace podle následujícího schématu:</p>

        <div class=""well"">
            <p>
                ROZVRH PRAVIDELNÝCH HODIN
            </p>
            ");
            EndContext();
            BeginContext(622, 23, false);
#line 18 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
       Write(ViewBag.PublicTimeTable);

#line default
#line hidden
            EndContext();
            BeginContext(645, 1007, true);
            WriteLiteral(@"
        </div>
        <hr>
        <p>
            K dispozici budou pokaždé dva tutoři (studenti vyššího ročníku FAV) a jeden pedagog z katedry zaštiťující příslušnou oblast (podrobný rozpis). Diskutovat je možné jakákoli témata z následujících předmětů:

            <ul>
                <li><strong>matematika</strong> - KKMA/M1, KMA/M2, KMA/MA1, KMA/MA1, KMA/M1S, KMA/M2S, KMA/MA1E, KMA/M2E, KMA/ZM1, KMA/ZM2 (po dohodě také KMA/LAA)</li>

                <li><strong>programování</strong> - KIV/PPA1, KIV/PPA2 a KIV/UPG</li>

                <li><strong>mechanika</strong></li>
            </ul>

            Pomoc/konzultace je poskytována bezplatně, účast je interně evidována pro potřeby support centra, evidence však není poskytována vyučujícím předmětů a nemá žádný vliv na hodnocení v daných předmětech.
        </p>
        <hr />
        <h3>Pokud se Vám žádná z vypsaných pravidelných lekcí nehodí, je zde možnost domluvit si extra hodinu.</h3>
        <div class=""well"">
");
            EndContext();
#line 37 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
              if (ViewContext.HttpContext.Session.GetString("role") != null && (ViewContext.HttpContext.Session.GetString("role").Equals(ISSSC.Class.AuthorizationRoles.Administrator) || ViewContext.HttpContext.Session.GetString("role").Equals(ISSSC.Class.AuthorizationRoles.Tutor) || ViewContext.HttpContext.Session.GetString("role").Equals(ISSSC.Class.AuthorizationRoles.User)))
                {

                    

#line default
#line hidden
#line 40 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                     using (Html.BeginForm())
                    {
                        

#line default
#line hidden
            BeginContext(2149, 23, false);
#line 42 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(2176, 171, true);
            WriteLiteral("                        <div class=\"form-horizontal\">\r\n                            <h4>Vypsání lekce</h4>\r\n                            <hr />\r\n                            ");
            EndContext();
            BeginContext(2348, 64, false);
#line 47 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                       Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(2412, 88, true);
            WriteLiteral("\r\n                            <div class=\"form-group\">\r\n                                ");
            EndContext();
            BeginContext(2501, 102, false);
#line 49 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                           Write(Html.LabelFor(model => model.Date, "Datum", htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(2603, 95, true);
            WriteLiteral("\r\n                                <div class=\"col-md-10\">\r\n                                    ");
            EndContext();
            BeginContext(2699, 93, false);
#line 51 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                               Write(Html.EditorFor(model => model.Date, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(2792, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(2831, 82, false);
#line 52 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                               Write(Html.ValidationMessageFor(model => model.Date, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(2913, 166, true);
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n\r\n                            <div class=\"form-group\">\r\n                                ");
            EndContext();
            BeginContext(3080, 139, false);
#line 57 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                           Write(Html.LabelFor(model => model.Event.TimeFrom, SSCISResources.Resources.TIME_FROM, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(3219, 95, true);
            WriteLiteral("\r\n                                <div class=\"col-md-10\">\r\n                                    ");
            EndContext();
            BeginContext(3315, 97, false);
#line 59 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                               Write(Html.EditorFor(model => model.TimeFrom, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(3412, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(3451, 86, false);
#line 60 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                               Write(Html.ValidationMessageFor(model => model.TimeFrom, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(3537, 166, true);
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n\r\n                            <div class=\"form-group\">\r\n                                ");
            EndContext();
            BeginContext(3704, 138, false);
#line 65 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                           Write(Html.LabelFor(model => model.Event.IdSubject, SSCISResources.Resources.SUBJECT, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(3842, 95, true);
            WriteLiteral("\r\n                                <div class=\"col-md-10\">\r\n                                    ");
            EndContext();
            BeginContext(3938, 85, false);
#line 67 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                               Write(Html.DropDownList("SubjectID", null, htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(4023, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(4062, 87, false);
#line 68 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                               Write(Html.ValidationMessageFor(model => model.SubjectID, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(4149, 428, true);
            WriteLiteral(@"
                                </div>
                            </div>
                            <div class=""form-group"">
                                <div class=""col-md-offset-2 col-md-10"">
                                    <input type=""submit"" value=""Zažádat o extra lekci"" class=""btn btn-default"" />
                                </div>
                            </div>
                        </div>
");
            EndContext();
#line 77 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                    }

#line default
#line hidden
#line 77 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                     




                }
                else
                {

#line default
#line hidden
            BeginContext(4668, 120, true);
            WriteLiteral("                    <p>\r\n                        PRO ZOBRAZENÍ FORMULÁŘE SE PROSÍM PŘIHLAŠTE\r\n                    </p>\r\n");
            EndContext();
#line 88 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
                }
            

#line default
#line hidden
            BeginContext(4822, 30, true);
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n");
            EndContext();
#line 93 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
      if (ViewContext.HttpContext.Session.GetString("role") != null && (ViewContext.HttpContext.Session.GetString("role").Equals(ISSSC.Class.AuthorizationRoles.Tutor) || ViewContext.HttpContext.Session.GetString("role").Equals(ISSSC.Class.AuthorizationRoles.Tutor)))
        {

#line default
#line hidden
            BeginContext(5131, 107, true);
            WriteLiteral("            <div class=\"col-sm-2 sidenav rozvrh\">\r\n                <div class=\"well\">\r\n                    ");
            EndContext();
            BeginContext(5239, 25, false);
#line 97 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
               Write(ViewBag.PersonalTimeTable);

#line default
#line hidden
            EndContext();
            BeginContext(5264, 46, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 100 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(5346, 64, true);
            WriteLiteral("            <div class=\"col-sm-2 sidenav\">\r\n            </div>\r\n");
            EndContext();
#line 105 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\HelpMe.cshtml"
        }
    

#line default
#line hidden
            BeginContext(5428, 18, true);
            WriteLiteral("</div>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ISSSC.Models.Meta.MetaEvent> Html { get; private set; }
    }
}
#pragma warning restore 1591
