#pragma checksum "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4dcd7d47057214c10021f55fdecdb2510d9baa98"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_StudentResult), @"mvc.1.0.view", @"/Views/Student/StudentResult.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Student/StudentResult.cshtml", typeof(AspNetCore.Views_Student_StudentResult))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4dcd7d47057214c10021f55fdecdb2510d9baa98", @"/Views/Student/StudentResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"308e7e839e9e3e2e6d438a197eb9266469b2978b", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_StudentResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication2.ViewModels.Students.StudentExerciseVm>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentResult.cshtml"
  
    ViewData["Title"] = "Õpilase harjutused ";

#line default
#line hidden
            BeginContext(117, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(122, 18, false);
#line 5 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentResult.cshtml"
Write(Model.ExerciseName);

#line default
#line hidden
            EndContext();
            BeginContext(140, 357, true);
            WriteLiteral(@"</h1>
<div id=""container"" style=""min-width: 310px; height: 400px; margin: 0 auto""></div>
<table id=""example"" class=""table table-striped table-bordered nowrap"" style=""width: 100%"">
    <thead>
    <tr>
        <th>Kuupäev </th>
        <th>Parim tulemus</th>
        <th>Klass</th>
        <th>Kõik katsed</th>
    </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 17 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentResult.cshtml"
     foreach (var result in Model.StudentResults.OrderByDescending(x => x.Date))
    {

#line default
#line hidden
            BeginContext(586, 11, true);
            WriteLiteral("        <tr");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 597, "\"", 674, 1);
#line 19 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentResult.cshtml"
WriteAttributeValue(" ", 605, Model.BiggestValue.Value != result.Value ? null : "table-success", 606, 68, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(675, 19, true);
            WriteLiteral(">\r\n            <td>");
            EndContext();
            BeginContext(695, 32, false);
#line 20 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentResult.cshtml"
           Write(result.Date.ToString("dd.MM.yy"));

#line default
#line hidden
            EndContext();
            BeginContext(727, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(751, 12, false);
#line 21 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentResult.cshtml"
           Write(result.Value);

#line default
#line hidden
            EndContext();
            BeginContext(763, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(787, 16, false);
#line 22 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentResult.cshtml"
           Write(result.ClassName);

#line default
#line hidden
            EndContext();
            BeginContext(803, 64, true);
            WriteLiteral("</td>\r\n            <td>\r\n                <a class=\"btn btn-info\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 867, "\"", 1007, 1);
#line 24 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentResult.cshtml"
WriteAttributeValue("", 874, Url.Action("StudentDateResults", "Student", new {Date = @result.Date, exerciseId = @Model.ExerciseId, studentId = @Model.StudentId}), 874, 133, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1008, 46, true);
            WriteLiteral(">Vaata</a>\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 27 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentResult.cshtml"
    }

#line default
#line hidden
            BeginContext(1061, 158, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<script>\r\n    $(function() {\r\n        console.log( \"ready!\" );\r\n        $.getJSON(\"/Student/GetData\", {\r\n                studentId:\"");
            EndContext();
            BeginContext(1220, 15, false);
#line 35 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentResult.cshtml"
                      Write(Model.StudentId);

#line default
#line hidden
            EndContext();
            BeginContext(1235, 32, true);
            WriteLiteral("\",\r\n                exerciseId:\"");
            EndContext();
            BeginContext(1268, 16, false);
#line 36 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\Student\StudentResult.cshtml"
                       Write(Model.ExerciseId);

#line default
#line hidden
            EndContext();
            BeginContext(1284, 1470, true);
            WriteLiteral(@"""
            },
            function(data) {
                var chart =  Highcharts.chart('container',
                    {
                        chart: {
                            type: 'line'
                        },
                        title: {
                            text: data.exerciseName
                        },
                        subtitle: {
                            text: ''
                        },
                        xAxis: {
                            categories: data.dates
                        },
                        yAxis: {
                            title: {
                                text: data.unit
                            }
                        },
                        plotOptions: {
                            line: {
                                dataLabels: {
                                    enabled: true
                                },
                                enableMouseTracking: true
      ");
            WriteLiteral(@"                      }
                        }
                    });
                for (var i = 0; i < data.tulemused.names.length; i++) {
                    chart.addSeries({                        
                        name: data.tulemused.names[i],
                        data: data.tulemused.values[i]
                    },false);
                }
                chart.redraw(); 
            });

    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication2.ViewModels.Students.StudentExerciseVm> Html { get; private set; }
    }
}
#pragma warning restore 1591