#pragma checksum "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentDateResults.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ef69d5c36fcb1d83be36367f06320db0dec77b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_StudentDateResults), @"mvc.1.0.view", @"/Views/Student/StudentDateResults.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Student/StudentDateResults.cshtml", typeof(AspNetCore.Views_Student_StudentDateResults))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ef69d5c36fcb1d83be36367f06320db0dec77b5", @"/Views/Student/StudentDateResults.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"308e7e839e9e3e2e6d438a197eb9266469b2978b", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_StudentDateResults : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Core.Data.Entities.Result>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentDateResults.cshtml"
  
    ViewData["Title"] = "Õpilase harjutused ";

#line default
#line hidden
            BeginContext(102, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(107, 37, false);
#line 5 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentDateResults.cshtml"
Write(Model.FirstOrDefault()?.Exercise.Name);

#line default
#line hidden
            EndContext();
            BeginContext(144, 214, true);
            WriteLiteral("</h1>\r\n<table id=\"example\" class=\"table table-striped table-bordered nowrap\" style=\"width: 100%\">\r\n    <thead>\r\n    <tr>\r\n        <th>Katse </th>\r\n        <th>Tulemus </th>\r\n\r\n    </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 15 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentDateResults.cshtml"
      
        var i = 1;
    

#line default
#line hidden
            BeginContext(393, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 18 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentDateResults.cshtml"
     foreach (var result in Model)
    {

#line default
#line hidden
            BeginContext(436, 31, true);
            WriteLiteral("        <tr >\r\n            <td>");
            EndContext();
            BeginContext(468, 1, false);
#line 21 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentDateResults.cshtml"
           Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(469, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(493, 12, false);
#line 22 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentDateResults.cshtml"
           Write(result.Value);

#line default
#line hidden
            EndContext();
            BeginContext(505, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 24 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentDateResults.cshtml"
            i = i+1;
    }

#line default
#line hidden
            BeginContext(556, 28, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Core.Data.Entities.Result>> Html { get; private set; }
    }
}
#pragma warning restore 1591