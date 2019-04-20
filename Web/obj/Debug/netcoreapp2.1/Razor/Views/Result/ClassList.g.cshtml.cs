#pragma checksum "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "092067ee1b8e942c7c48a166ad2a9c54a0519d0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Result_ClassList), @"mvc.1.0.view", @"/Views/Result/ClassList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Result/ClassList.cshtml", typeof(AspNetCore.Views_Result_ClassList))]
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
#line 1 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml"
using Core.Data.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"092067ee1b8e942c7c48a166ad2a9c54a0519d0b", @"/Views/Result/ClassList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"308e7e839e9e3e2e6d438a197eb9266469b2978b", @"/Views/_ViewImports.cshtml")]
    public class Views_Result_ClassList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication2.ViewModels.Results.ResultVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddResult", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Result", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml"
  
    ViewData["Title"] = "Õpilased";

#line default
#line hidden
            BeginContext(123, 268, true);
            WriteLiteral(@"<div class=""row-12"">
    <h2 class=""text-center"">Vali klass</h2>
</div>
<table  class=""table table-striped table-bordered nowrap"" style=""width: 100%"">
    <thead>
    <tr>
        <th>Poisid</th>
        <th>Tüdrukud</th>
    </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 17 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml"
     foreach (var exercise in Model.Classes)
    {
                 var manId = (int) Gender.Man;
                var womanId = (int) Gender.Woman;

#line default
#line hidden
            BeginContext(543, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(591, 458, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2cb3b59966ea46ccba0f741bfb84e344", async() => {
                BeginContext(657, 68, true);
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"SelectedExerciseId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 725, "\"", 750, 1);
#line 24 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml"
WriteAttributeValue("", 733, Model.ExerciseId, 733, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(751, 59, true);
                WriteLiteral("/>\r\n                    <input type=\"hidden\" name=\"ClassId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 810, "\"", 830, 1);
#line 25 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml"
WriteAttributeValue("", 818, exercise.Id, 818, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(831, 58, true);
                WriteLiteral("/>\r\n                    <input type=\"hidden\" name=\"gender\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 889, "\"", 903, 1);
#line 26 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml"
WriteAttributeValue("", 897, manId, 897, 6, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(904, 97, true);
                WriteLiteral("/>\r\n\r\n                    <button style=\"margin-top: 10px\" class=\"btn btn-primary\" type=\"submit\">");
                EndContext();
                BeginContext(1002, 13, false);
#line 28 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml"
                                                                                      Write(exercise.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1015, 27, true);
                WriteLiteral("</button>\r\n                ");
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1049, 57, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n\r\n                ");
            EndContext();
            BeginContext(1106, 458, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12e754b188d74925b2bb13640627f1e7", async() => {
                BeginContext(1172, 68, true);
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"SelectedExerciseId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1240, "\"", 1265, 1);
#line 34 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml"
WriteAttributeValue("", 1248, Model.ExerciseId, 1248, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1266, 59, true);
                WriteLiteral("/>\r\n                    <input type=\"hidden\" name=\"ClassId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1325, "\"", 1345, 1);
#line 35 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml"
WriteAttributeValue("", 1333, exercise.Id, 1333, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1346, 58, true);
                WriteLiteral("/>\r\n                    <input type=\"hidden\" name=\"gender\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1404, "\"", 1420, 1);
#line 36 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml"
WriteAttributeValue("", 1412, womanId, 1412, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1421, 94, true);
                WriteLiteral("/>\r\n                    <button style=\"margin-top: 10px\"class=\"btn btn-primary\" type=\"submit\">");
                EndContext();
                BeginContext(1516, 13, false);
#line 37 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml"
                                                                                     Write(exercise.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1529, 28, true);
                WriteLiteral(" </button>\r\n                ");
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1564, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 41 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Result\ClassList.cshtml"
    }

#line default
#line hidden
            BeginContext(1607, 24, true);
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