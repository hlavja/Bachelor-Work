#pragma checksum "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c49d0e17b9a97d085f33891948f5938e1d74ab56"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 2 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c49d0e17b9a97d085f33891948f5938e1d74ab56", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbef95dca45eb325a7cf0be8b91e8c5908baa71d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ISSSC.Models.SscisContent>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\Index.cshtml"
  
    ViewBag.ActiveMenuItem = "menu-index";

#line default
#line hidden
            BeginContext(120, 258, true);
            WriteLiteral(@"

<div class=""row content"">
    <div class=""col-sm-2 sidenav"">
    </div>

    <div class=""col-sm-8 text-left"">
        <h1>Vítejte na stránkách Student Support Centre (SSC)</h1>
        <hr />
        <div class=""well"">
            <h3>Aktualita: ");
            EndContext();
            BeginContext(379, 30, false);
#line 16 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\Index.cshtml"
                      Write(Html.DisplayFor(m => m.Header));

#line default
#line hidden
            EndContext();
            BeginContext(409, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(411, 31, false);
#line 16 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\Index.cshtml"
                                                      Write(Html.DisplayFor(m => m.Created));

#line default
#line hidden
            EndContext();
            BeginContext(442, 40, true);
            WriteLiteral("</h3>\r\n            <p>\r\n                ");
            EndContext();
            BeginContext(483, 35, false);
#line 18 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\Index.cshtml"
           Write(Html.DisplayFor(m => m.TextContent));

#line default
#line hidden
            EndContext();
            BeginContext(518, 170, true);
            WriteLiteral("\r\n            </p>\r\n        </div>\r\n        <hr />\r\n        <div class=\"well\">\r\n            <p>\r\n                ROZVRH PRAVIDELNÝCH HODIN\r\n            </p>\r\n            ");
            EndContext();
            BeginContext(689, 23, false);
#line 26 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\Index.cshtml"
       Write(ViewBag.PublicTimeTable);

#line default
#line hidden
            EndContext();
            BeginContext(712, 1157, true);
            WriteLiteral(@"
        </div>
        <p>
            <strong>Student Support Centre (SSC)</strong> je společná aktivita kateder <a href=""http://www.fav.zcu.cz/"" target=""_blank"">Fakulty aplikovaných věd Západočeské univerzity v Plzni</a>.
            <br /> <br />
            Projekt startuje ve zkouškovém období zimního semestru 2017/2018. Cílem je podpora studentů prvního ročníku, kteří mohou mít problémy s úvodními matematickými a
            informatickými předměty. Podpory se studentům dostane od kolegů ve vyšších ročnících pod dohledem pedagogických pracovníků zúčastněných kateder.
            Každý den v týdnu mohou studenti přijít do <a href=""https://goo.gl/r9ozbP"" target=""_blank"">studovny FAV</a>, kde získají bezplatnou pomoc se základními předměty:
            <ul>
                <li><strong>matematika</strong> - KMA/M1, KMA/M2, KMA/MA1, KMA/MA1, KMA/M1S, KMA/M2S, KMA/MA1E, KMA/M2E, KMA/ZM1, KMA/ZM2 (po dohodě také KMA/LAA)</li>

                <li><strong>programování</strong> - KIV/PPA1, KIV/PPA2 a");
            WriteLiteral(" KIV/UPG</li>\r\n\r\n                <li><strong>mechanika</strong></li>\r\n            </ul>\r\n        </p>\r\n        <hr>\r\n\r\n    </div>\r\n\r\n");
            EndContext();
#line 46 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\Index.cshtml"
      if (ViewContext.HttpContext.Session.GetString("role") != null && (ViewContext.HttpContext.Session.GetString("role").Equals(ISSSC.Class.AuthorizationRoles.User) || ViewContext.HttpContext.Session.GetString("role").Equals(ISSSC.Class.AuthorizationRoles.Tutor)))
        {

#line default
#line hidden
            BeginContext(2147, 378, true);
            WriteLiteral(@"            <div class=""col-sm-2 sidenav rozvrh"">
                <div class=""well"">
                    <p>
                        USER - rozvrh extra lekcí na které se přihlásil
                        <br />
                        TUTOR - rozvrh lekcí co bude vyučovat (pravidelné a nepravidelné)
                    </p>
                </div>
            </div>
");
            EndContext();
#line 57 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\Index.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(2561, 64, true);
            WriteLiteral("            <div class=\"col-sm-2 sidenav\">\r\n            </div>\r\n");
            EndContext();
#line 62 "E:\School\Bakalarka\Bakalářka final\Projekt ISSSC\ISSSC\ISSSC\Views\Home\Index.cshtml"
        }
    

#line default
#line hidden
            BeginContext(2643, 16, true);
            WriteLiteral("\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ISSSC.Models.SscisContent> Html { get; private set; }
    }
}
#pragma warning restore 1591
