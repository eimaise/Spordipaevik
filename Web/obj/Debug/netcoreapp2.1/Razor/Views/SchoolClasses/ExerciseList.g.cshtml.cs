#pragma checksum "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ExerciseList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db6b07303fb39abe5992b99059b3558b5e9499aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SchoolClasses_ExerciseList), @"mvc.1.0.view", @"/Views/SchoolClasses/ExerciseList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SchoolClasses/ExerciseList.cshtml", typeof(AspNetCore.Views_SchoolClasses_ExerciseList))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db6b07303fb39abe5992b99059b3558b5e9499aa", @"/Views/SchoolClasses/ExerciseList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"308e7e839e9e3e2e6d438a197eb9266469b2978b", @"/Views/_ViewImports.cshtml")]
    public class Views_SchoolClasses_ExerciseList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication2.Controllers.ClassResultVm>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ExerciseList.cshtml"
  
    ViewData["Title"] = "Harjutused";

#line default
#line hidden
            BeginContext(96, 19, true);
            WriteLiteral("\r\nVali harjutus :\r\n");
            EndContext();
#line 7 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ExerciseList.cshtml"
 foreach (var exercise in Model.Exercises)
{

#line default
#line hidden
            BeginContext(295, 109, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col\">\r\n            <a style=\"margin-top: 10px\"class=\"btn btn-info\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 404, "\"", 497, 1);
#line 14 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ExerciseList.cshtml"
WriteAttributeValue("", 411, Url.Action("ClassResults", new {exerciseId = @exercise.Id, ClassId = @Model.ClassId}), 411, 86, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(498, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(500, 13, false);
#line 14 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ExerciseList.cshtml"
                                                                                                                                                     Write(exercise.Name);

#line default
#line hidden
            EndContext();
            BeginContext(513, 34, true);
            WriteLiteral("</a>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 17 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ExerciseList.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication2.Controllers.ClassResultVm> Html { get; private set; }
    }
}
#pragma warning restore 1591