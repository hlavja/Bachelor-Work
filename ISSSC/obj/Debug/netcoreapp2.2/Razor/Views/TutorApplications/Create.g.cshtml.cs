#pragma checksum "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1c96d5c4319062cbb6ae2c13f1a54d485c0831c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TutorApplications_Create), @"mvc.1.0.view", @"/Views/TutorApplications/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/TutorApplications/Create.cshtml", typeof(AspNetCore.Views_TutorApplications_Create))]
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
#line 2 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1c96d5c4319062cbb6ae2c13f1a54d485c0831c", @"/Views/TutorApplications/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbef95dca45eb325a7cf0be8b91e8c5908baa71d", @"/Views/_ViewImports.cshtml")]
    public class Views_TutorApplications_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ISSSC.Models.Meta.MetaTutorApplication>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(82, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
  
    ViewBag.Title = SSCISResources.Resources.TUTOR_APPLICATION;
    ViewBag.ActiveMenuItem = "menu-tutor";

#line default
#line hidden
            BeginContext(200, 750, true);
            WriteLiteral(@"
<div class=""body-content container-fluid text-center"">
    <div class=""row content"">
        <div class=""col-sm-2 sidenav"">
        </div>

        <div class=""col-sm-8 text-left"">
            <h1>Chci pomáhat</h1>
            <p>Hledáme tutory, tj. studenty/studentky 3.- 5. ročníku FAV, kteří by si chtěli přivydělat poskytováním konzultací mladším spolužákům. <strong>Nabízíme 190,- Kč na hodinu, požadujeme dobré znalosti alespoň některého z doučovaných předmětů</strong> tj. na úrovni známky výborně nebo alespoň velmi dobře.</p>
            <hr>
            <p>Máte-li zájem, vyplňte prosím formulář níže.</p>
            <div class=""well"">
                <div class=""container"">
                    <h2>Žádost o tutorství</h2>
");
            EndContext();
#line 22 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                     using (Html.BeginForm())
                    {
                        

#line default
#line hidden
            BeginContext(1045, 23, false);
#line 24 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
#line 24 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                                                ;

#line default
#line hidden
            BeginContext(1071, 82, true);
            WriteLiteral("                        <div style=\"display: none;\">\r\n                            ");
            EndContext();
            BeginContext(1154, 34, false);
#line 26 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                       Write(Html.EditorFor(m => m.SubjectData));

#line default
#line hidden
            EndContext();
            BeginContext(1188, 121, true);
            WriteLiteral(";\r\n                        </div>\r\n                        <div id=\"display-subject\">\r\n\r\n                            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1309, "\"", 1355, 2);
            WriteAttributeValue("", 1317, "row", 1317, 3, true);
#line 30 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
WriteAttributeValue(" ", 1320, string.Format("subject-row{0}",0), 1321, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1356, 97, true);
            WriteLiteral(">\r\n                                <div class=\"form-group\">\r\n                                    ");
            EndContext();
            BeginContext(1454, 165, false);
#line 32 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                               Write(Html.LabelFor(model => model.ApplicationSubjects.ElementAt(0).IdSubject, SSCISResources.Resources.SUBJECT, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1619, 103, true);
            WriteLiteral("\r\n                                    <div class=\"col-md-10\">\r\n                                        ");
            EndContext();
            BeginContext(1723, 93, false);
#line 34 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                                   Write(Html.DropDownList("SubjectID", null, htmlAttributes: new { @class = "form-control subject" }));

#line default
#line hidden
            EndContext();
            BeginContext(1816, 180, true);
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                                <div class=\"form-group\">\r\n                                    ");
            EndContext();
            BeginContext(1997, 161, false);
#line 38 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                               Write(Html.LabelFor(model => model.ApplicationSubjects.ElementAt(0).Degree, SSCISResources.Resources.DEGREE, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(2158, 171, true);
            WriteLiteral("\r\n                                    <div class=\"col-md-10\">\r\n                                        <div class=\"checkbox\">\r\n                                            ");
            EndContext();
            BeginContext(2330, 89, false);
#line 41 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                                       Write(Html.DropDownList("Degree", null, htmlAttributes: new { @class = "form-control degree" }));

#line default
#line hidden
            EndContext();
            BeginContext(2419, 266, true);
            WriteLiteral(@"
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div id=""hide-subject"" class=""hide"">
");
            EndContext();
#line 49 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                             for (int i = 1; i < Model.ApplicationSubjects.Count; i++)
                            {

#line default
#line hidden
            BeginContext(2804, 36, true);
            WriteLiteral("                                <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 2840, "\"", 2886, 2);
            WriteAttributeValue("", 2848, "row", 2848, 3, true);
#line 51 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
WriteAttributeValue(" ", 2851, string.Format("subject-row{0}",i), 2852, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2887, 105, true);
            WriteLiteral(">\r\n                                    <div class=\"form-group\">\r\n                                        ");
            EndContext();
            BeginContext(2993, 165, false);
#line 53 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                                   Write(Html.LabelFor(model => model.ApplicationSubjects.ElementAt(i).IdSubject, SSCISResources.Resources.SUBJECT, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(3158, 111, true);
            WriteLiteral("\r\n                                        <div class=\"col-md-10\">\r\n                                            ");
            EndContext();
            BeginContext(3270, 93, false);
#line 55 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                                       Write(Html.DropDownList("SubjectID", null, htmlAttributes: new { @class = "form-control subject" }));

#line default
#line hidden
            EndContext();
            BeginContext(3363, 196, true);
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                    <div class=\"form-group\">\r\n                                        ");
            EndContext();
            BeginContext(3560, 161, false);
#line 59 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                                   Write(Html.LabelFor(model => model.ApplicationSubjects.ElementAt(i).Degree, SSCISResources.Resources.DEGREE, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(3721, 183, true);
            WriteLiteral("\r\n                                        <div class=\"col-md-10\">\r\n                                            <div class=\"checkbox\">\r\n                                                ");
            EndContext();
            BeginContext(3905, 89, false);
#line 62 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                                           Write(Html.DropDownList("Degree", null, htmlAttributes: new { @class = "form-control degree" }));

#line default
#line hidden
            EndContext();
            BeginContext(3994, 186, true);
            WriteLiteral("\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
            EndContext();
#line 67 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                            }

#line default
#line hidden
            BeginContext(4211, 135, true);
            WriteLiteral("                            <input type=\"number\" id=\"subjects_count\" name=\"subjects_count\" value=\"0\">\r\n                        </div>\r\n");
            EndContext();
            BeginContext(4348, 59, true);
            WriteLiteral("                        <a href=\"#\" onclick=\"addSubject()\">");
            EndContext();
            BeginContext(4408, 36, false);
#line 71 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                                                      Write(SSCISResources.Resources.ADD_SUBJECT);

#line default
#line hidden
            EndContext();
            BeginContext(4444, 298, true);
            WriteLiteral(@"</a>
                        <br />
                        <br />
                        <div class=""form-group submit"" style=""vertical-align: bottom"">
                            <button id=""submit-btn"" type=""submit"" class=""btn btn-default"">Odeslat</button>
                        </div>
");
            EndContext();
#line 77 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
                    }

#line default
#line hidden
            BeginContext(4765, 248, true);
            WriteLiteral("                </div>\r\n            </div>\r\n            <p>Máte-li další dotazy, ozvěte se prosím Světlaně Tomiczkové na e-mail <a href=\"mailto:svetlana@kma.zcu.cz\">svetlana@kma.zcu.cz</a>, případně přijďte osobně do UC 258.</p>\r\n        </div>\r\n\r\n");
            EndContext();
#line 83 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
          if (ViewContext.HttpContext.Session.GetString("role") != null && (ViewContext.HttpContext.Session.GetString("role").Equals(ISSSC.Class.AuthorizationRoles.User) || ViewContext.HttpContext.Session.GetString("role").Equals(ISSSC.Class.AuthorizationRoles.Tutor)))
            {

#line default
#line hidden
            BeginContext(5299, 414, true);
            WriteLiteral(@"                <div class=""col-sm-2 sidenav rozvrh"">
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
#line 94 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(5761, 72, true);
            WriteLiteral("                <div class=\"col-sm-2 sidenav\">\r\n                </div>\r\n");
            EndContext();
#line 99 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
            }
        

#line default
#line hidden
            BeginContext(5859, 69, true);
            WriteLiteral("\r\n\r\n    </div>\r\n\r\n\r\n\r\n    <script>\r\n    var i = 1;\r\n    var scount = ");
            EndContext();
            BeginContext(5929, 31, false);
#line 109 "D:\Skola\bakalarka\ISSSC\Views\TutorApplications\Create.cshtml"
            Write(Model.ApplicationSubjects.Count);

#line default
#line hidden
            EndContext();
            BeginContext(5960, 244, true);
            WriteLiteral(";\r\n\r\n    function addSubject() {\r\n        if (i < scount) {\r\n            $(\".subject-row\"+i).appendTo(\"#display-subject\");\r\n            $(\'#subjects_count\')[0].value++;\r\n            i++;\r\n        }\r\n    }\r\n\r\n    addSubject();\r\n\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ISSSC.Models.Meta.MetaTutorApplication> Html { get; private set; }
    }
}
#pragma warning restore 1591
