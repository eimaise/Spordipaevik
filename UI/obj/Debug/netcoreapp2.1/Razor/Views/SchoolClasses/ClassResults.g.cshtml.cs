#pragma checksum "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ClassResults.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "046bf97b1de40961607347f75a2a083c49e98b81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SchoolClasses_ClassResults), @"mvc.1.0.view", @"/Views/SchoolClasses/ClassResults.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SchoolClasses/ClassResults.cshtml", typeof(AspNetCore.Views_SchoolClasses_ClassResults))]
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
#line 1 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ClassResults.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"046bf97b1de40961607347f75a2a083c49e98b81", @"/Views/SchoolClasses/ClassResults.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"308e7e839e9e3e2e6d438a197eb9266469b2978b", @"/Views/_ViewImports.cshtml")]
    public class Views_SchoolClasses_ClassResults : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication2.Controllers.ClassResultVm>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(88, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ClassResults.cshtml"
  
    ViewData["Title"] = "Harjutused";

#line default
#line hidden
            BeginContext(136, 88, true);
            WriteLiteral("\r\n<div id=\"container\" style=\"min-width: 310px; height: 400px; margin: 0 auto\"></div>\r\n\r\n");
            EndContext();
            BeginContext(314, 195, true);
            WriteLiteral("<table  class=\"table table-striped table-bordered nowrap\" style=\"width: 100%\">\r\n    <thead>\r\n    <tr>\r\n        <th>Kuupäev</th>\r\n        <th>Tulemused</th>\r\n    </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 19 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ClassResults.cshtml"
     foreach (var date in Model.Dates)
    {

#line default
#line hidden
            BeginContext(556, 51, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                <p>");
            EndContext();
            BeginContext(608, 29, false);
#line 23 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ClassResults.cshtml"
              Write(date.Date.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(637, 87, true);
            WriteLiteral("</p>\r\n\r\n            </td>\r\n            <td>\r\n                <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 724, "\"", 848, 1);
#line 27 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ClassResults.cshtml"
WriteAttributeValue("", 731, Url.Action("ResultInDay", new {date = @date.Date, exerciseId = @Model.SelectedExerciseId, ClassId = @Model.ClassId}), 731, 117, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(849, 49, true);
            WriteLiteral(">Vaata </a>\r\n\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 31 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ClassResults.cshtml"
    }

#line default
#line hidden
            BeginContext(905, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
            BeginContext(1212, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(2509, 139, true);
            WriteLiteral("<script>\r\n    $(function() {\r\n        console.log( \"ready!\" );\r\n        $.getJSON(\"/SchoolClasses/GetData\", {\r\n                exerciseId:\"");
            EndContext();
            BeginContext(2649, 24, false);
#line 76 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ClassResults.cshtml"
                       Write(Model.SelectedExerciseId);

#line default
#line hidden
            EndContext();
            BeginContext(2673, 29, true);
            WriteLiteral("\",\r\n                classId:\"");
            EndContext();
            BeginContext(2703, 13, false);
#line 77 "C:\Users\MartinSaar\RiderProjects\WebApplication2\UI\Views\SchoolClasses\ClassResults.cshtml"
                    Write(Model.ClassId);

#line default
#line hidden
            EndContext();
            BeginContext(2716, 1470, true);
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
            WriteLiteral(@"                  }
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
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication2.Controllers.ClassResultVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
