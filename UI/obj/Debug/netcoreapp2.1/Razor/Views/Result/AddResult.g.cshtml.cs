#pragma checksum "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\AddResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0cd179e4c9bbaaacf9e79aa8f2337d46baaf7ceb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Result_AddResult), @"mvc.1.0.view", @"/Views/Result/AddResult.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Result/AddResult.cshtml", typeof(AspNetCore.Views_Result_AddResult))]
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
#line 1 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\_ViewImports.cshtml"
using WebApplication2;

#line default
#line hidden
#line 2 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\_ViewImports.cshtml"
using WebApplication2.Models;

#line default
#line hidden
#line 3 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\_ViewImports.cshtml"
using WebApplication2.ViewModels.Exercises;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cd179e4c9bbaaacf9e79aa8f2337d46baaf7ceb", @"/Views/Result/AddResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"308e7e839e9e3e2e6d438a197eb9266469b2978b", @"/Views/_ViewImports.cshtml")]
    public class Views_Result_AddResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication2.ViewModels.Results.ResultVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddResult", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Result", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 200px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\AddResult.cshtml"
  
    ViewData["Title"] = "Õpilased";

#line default
#line hidden
            BeginContext(96, 276, true);
            WriteLiteral(@"Õpilased
<table  class=""table table-striped table-bordered nowrap"" style=""width: 100%"">
    <thead>
    <tr>
        <th>Õpilane</th>
        <th>Selle tunni tulemused</th>
        <th>Rekord</th>
        <th>Sisesta tulemus</th>
    </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 16 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\AddResult.cshtml"
     foreach (var student in Model.Students)
    {

#line default
#line hidden
            BeginContext(425, 49, true);
            WriteLiteral("        <tr>\r\n            <td >\r\n                ");
            EndContext();
            BeginContext(475, 12, false);
#line 20 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\AddResult.cshtml"
           Write(student.Name);

#line default
#line hidden
            EndContext();
            BeginContext(487, 39, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
            EndContext();
#line 23 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\AddResult.cshtml"
                 foreach (var result in student.Results)
                {

#line default
#line hidden
            BeginContext(603, 23, true);
            WriteLiteral("                    <p>");
            EndContext();
            BeginContext(627, 6, false);
#line 25 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\AddResult.cshtml"
                  Write(result);

#line default
#line hidden
            EndContext();
            BeginContext(633, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 26 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\AddResult.cshtml"
                }

#line default
#line hidden
            BeginContext(658, 114, true);
            WriteLiteral("            </td>\r\n            <td>\r\n                REKORD\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(772, 554, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6c72f000d61147398fc2dc58e807aa62", async() => {
                BeginContext(860, 68, true);
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"SelectedExerciseId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 928, "\"", 953, 1);
#line 33 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\AddResult.cshtml"
WriteAttributeValue("", 936, Model.ExerciseId, 936, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(954, 59, true);
                WriteLiteral("/>\r\n                    <input type=\"hidden\" name=\"ClassId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1013, "\"", 1035, 1);
#line 34 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\AddResult.cshtml"
WriteAttributeValue("", 1021, Model.ClassId, 1021, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1036, 61, true);
                WriteLiteral("/>\r\n                    <input type=\"hidden\" name=\"StudentId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1097, "\"", 1116, 1);
#line 35 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\AddResult.cshtml"
WriteAttributeValue("", 1105, student.Id, 1105, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1117, 202, true);
                WriteLiteral("/>\r\n                    <input type=\"number\" step=\"0.01\" name=\"result\" class=\"form-control\"/>\r\n\r\n                    <button class=\"btn btn-success\" type=\"submit\">Lisa tulemus</button>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1326, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 42 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\AddResult.cshtml"
    }

#line default
#line hidden
            BeginContext(1369, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication2.ViewModels.Results.ResultVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
