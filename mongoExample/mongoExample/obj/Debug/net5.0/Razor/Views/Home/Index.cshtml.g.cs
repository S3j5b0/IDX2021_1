#pragma checksum "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6cc2e982eb21776407d98e201d2c5d73f40cb7c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/_ViewImports.cshtml"
using mongoExample;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
using mongoExample.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cc2e982eb21776407d98e201d2c5d73f40cb7c1", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f6dbabb94c71eb13bb668dacbc0177e73d1974d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<User,List<User>>>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("  <link rel=\"stylesheet\" href=\"../../wwwroot/css/askStyles.css\">\n<link rel=\"stylesheet\" href=\"../../wwwroot/css/bootstrap.min.css\">\n");
#nullable restore
#line 5 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
  
    var loggedInUser = Model.Item1;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container text-center\">\n    <div class=\"row\">\n        <div class=\"col-sm-3 well\">\n            <div class=\"well\">\n                <p>\n                    <a>");
#nullable restore
#line 13 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                  Write(loggedInUser.status);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                </p>
            </div>

            <div class=""alert alert-success fade in"">
                <a href=""#"" class=""close"" data-dismiss=""alert"" aria-label=""close"">×</a>

                Did you save some cash? Buy a tree!
            </div>
            <table>
");
#nullable restore
#line 23 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                 if (Context.Request.Cookies["mode"] == "env")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\n                        <td>spent this week</td>\n                        <td>");
#nullable restore
#line 27 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                       Write(loggedInUser.EconomicModel.WeeklyPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    </tr>\n                    <tr>\n                        <td>Saved from last week</td>\n                        <td>");
#nullable restore
#line 31 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                       Write(loggedInUser.EconomicModel.savedFromLastWeek);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    </tr>\n                    <tr>\n                        <td>Yearly spending</td>\n                        <td>");
#nullable restore
#line 35 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                       Write(loggedInUser.EconomicModel.yearlySpending);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    </tr>\n");
#nullable restore
#line 37 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                }
                else if (Context.Request.Cookies["mode"] == "monetary" || Context.Request.Cookies["mode"] == null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\n                        <td>used this week</td>\n                        <td>");
#nullable restore
#line 42 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                       Write(loggedInUser.EnviormentalStats.WeeklyKWHUsage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    </tr>\n                    <tr>\n                        <td>Saved from last week</td>\n                        <td>");
#nullable restore
#line 46 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                       Write(loggedInUser.EnviormentalStats.savedFromLastWeek);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    </tr>\n                    <tr>\n                        <td>Yearly usage</td>\n                        <td>");
#nullable restore
#line 50 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                       Write(loggedInUser.EnviormentalStats.yearlySpending);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    </tr>\n");
#nullable restore
#line 52 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </table>
        </div>
        <div class=""col-sm-7"">



<div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""panel panel-default text-left"">
                        <div class=""panel-body"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cc2e982eb21776407d98e201d2c5d73f40cb7c17638", async() => {
                WriteLiteral(@"
                                <textarea class=""greyback"" id=""w3review"" name=""status"" rows=""4"" cols=""50"" placeholder=""Update your status...""></textarea>
                                <br><br>
                                <input class=""input"" type=""submit"" value=""Submit"">
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 63 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
AddHtmlAttributeValue("", 2308, Url.Action("updateStatus", "Home"), 2308, 35, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                        </div>\n                    </div>\n                </div>\n            </div>\n");
#nullable restore
#line 72 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
 foreach (User user in @Model.Item2)
{



#line default
#line hidden
#nullable disable
            WriteLiteral("  <div class=\"row\">\n    <div class=\"col-sm-3\">\n      <div");
            BeginWriteAttribute("class", " class=\"", 2858, "\"", 2882, 2);
            WriteAttributeValue("", 2866, "well", 2866, 4, true);
#nullable restore
#line 78 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
WriteAttributeValue(" ", 2870, user.Color, 2871, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n        <p>");
#nullable restore
#line 79 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
      Write(user.name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\n      </div>\n    </div>\n    <div class=\"col-sm-9\">\n      <div class=\"well neutral\">\n        <p> ");
#nullable restore
#line 84 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
       Write(user.status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        <div class=\"bottom-left-text\">\n");
#nullable restore
#line 86 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
           if (Context.Request.Cookies["mode"] == "env"){

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"label label-default\"> Weekly usage: ");
#nullable restore
#line 87 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                                                        Write(user.EnviormentalStats?.WeeklyKWHUsage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n            <span class=\"label label-primary\">KHW Saved compared to last week: ");
#nullable restore
#line 88 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                                                                          Write(user.EnviormentalStats?.savedFromLastWeek);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n            <span class=\"label label-success\"> Yearly KHW usage: ");
#nullable restore
#line 89 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                                                            Write(user.EnviormentalStats?.yearlySpending);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n");
#nullable restore
#line 90 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
          }
          else if (Context.Request.Cookies["mode"] == "monetary" || Context.Request.Cookies["mode"]  == null )
          {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"label label-default\"> Weekly price: ");
#nullable restore
#line 93 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                                                        Write(user.EconomicModel.WeeklyPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n            <span class=\"label label-primary\">Saved compared to last week: ");
#nullable restore
#line 94 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                                                                      Write(user.EconomicModel.savedFromLastWeek);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n            <span class=\"label label-success\"> Yearly spending: ");
#nullable restore
#line 95 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
                                                           Write(user.EconomicModel.yearlySpending);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n");
#nullable restore
#line 96 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
          }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n      </div>\n    </div>\n  </div>\n");
#nullable restore
#line 101 "/home/ask/Git/IDX2021_1/mongoExample/mongoExample/Views/Home/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<User,List<User>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
