#pragma checksum "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6a9fb9c5b50dd5d7c7bb95615f1d2416683786e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_CMS_Views_Seo_Update), @"mvc.1.0.view", @"/Areas/CMS/Views/Seo/Update.cshtml")]
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
#line 1 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/_ViewImports.cshtml"
using MediaBalansSaville.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/_ViewImports.cshtml"
using MediaBalansSaville.WebUI.Areas.CMS.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/_ViewImports.cshtml"
using MediaBalansSaville.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/_ViewImports.cshtml"
using MediaBalansSaville.Core.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6a9fb9c5b50dd5d7c7bb95615f1d2416683786e", @"/Areas/CMS/Views/Seo/Update.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94c59595ea7a05ed7ee15fa0be54959a37c52328", @"/Areas/CMS/Views/_ViewImports.cshtml")]
    public class Areas_CMS_Views_Seo_Update : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SeoCreateVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "CMS", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Seo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("float-right btn btn-outline-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ValidationScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
  
    ViewData["Title"] = "Create";
    int count = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"row\">\n    <div class=\"col-12 my-4 mx-auto\">\n        <div class=\"card shadow mb-4\">\n            <div class=\"card-header py-4\">\n                ");
#nullable restore
#line 12 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
           Write(Model.Page);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Səhifəsinin SEO Parametrləri ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6a9fb9c5b50dd5d7c7bb95615f1d2416683786e8779", async() => {
                WriteLiteral("Geriyə get");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </div>\n            <div class=\"tab-content\" id=\"pills-tabContent\">\n                <div id=\"test\" class=\"card-body\">\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6a9fb9c5b50dd5d7c7bb95615f1d2416683786e10564", async() => {
                WriteLiteral("\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6a9fb9c5b50dd5d7c7bb95615f1d2416683786e10843", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 17 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        <div class=\"form-group\">\n                            <label class=\"control-label\">Sayfa</label>\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d6a9fb9c5b50dd5d7c7bb95615f1d2416683786e12678", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 20 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Page);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6a9fb9c5b50dd5d7c7bb95615f1d2416683786e14504", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 21 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Page);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            <span class=""text-danger""></span>
                        </div>
                        <div class=""row"">
                            <div class=""col-md-12"">
                                <div class=""card"">
                                    <div class=""card-header"">
                                        Tərcümə olunacaq dillər
                                    </div>
                                    <div class=""card-body"">
                                        <ul class=""nav nav-pills mb-3 text-center"" id=""pills-tab"" role=""tablist"">
");
#nullable restore
#line 32 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
                                              
                                                int b = 0;
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
                                             foreach (var item in await lang.GetAllLangs())
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <li style=\"width:32%\" class=\"nav-item ml-2 bg-secondary \">\n                                                    <a");
                BeginWriteAttribute("class", " class=\"", 2046, "\"", 2097, 3);
                WriteAttributeValue("", 2054, "nav-link", 2054, 8, true);
#nullable restore
#line 38 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue(" ", 2062, b==0 ? "active" : "", 2063, 23, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue(" ", 2086, "text-white", 2087, 11, true);
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 2098, "\"", 2123, 3);
                WriteAttributeValue("", 2103, "pills-", 2103, 6, true);
#nullable restore
#line 38 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 2109, item.Code, 2109, 10, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2119, "-tab", 2119, 4, true);
                EndWriteAttribute();
                WriteLiteral(" data-toggle=\"pill\"");
                BeginWriteAttribute("href", " href=\"", 2143, "\"", 2167, 2);
                WriteAttributeValue("", 2150, "#pills-", 2150, 7, true);
#nullable restore
#line 38 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 2157, item.Code, 2157, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" role=\"tab\" aria-controls=\"pills-home\" aria-selected=\"true\">");
#nullable restore
#line 38 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
                                                                                                                                                                                                                                       Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\n                                                </li>\n");
#nullable restore
#line 40 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
                                                b++;
                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                        </ul>
                                        <div class=""row justify-content-center"">
                                            <div class=""col-md-6 col-6"">
                                                <div class=""tab-content"" id=""pills-tabContent "">
");
#nullable restore
#line 46 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
                                                     foreach (var item in Model.SeoLangs.ToList())
                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                        <div");
                BeginWriteAttribute("class", " class=\"", 2906, "\"", 2979, 5);
                WriteAttributeValue("", 2914, "col-md-12", 2914, 9, true);
                WriteAttributeValue(" ", 2923, "col-12", 2924, 7, true);
                WriteAttributeValue(" ", 2930, "tab-pane", 2931, 9, true);
                WriteAttributeValue(" ", 2939, "fade", 2940, 5, true);
#nullable restore
#line 48 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue(" ", 2944, count == 0 ? "show active" : "", 2945, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 2980, "\"", 3006, 2);
                WriteAttributeValue("", 2985, "pills-", 2985, 6, true);
#nullable restore
#line 48 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 2991, item.Lang.Code, 2991, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" role=\"tabpanel\">\n                                                            <div class=\"form-group\">\n                                                                <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 3194, "\"", 3224, 3);
                WriteAttributeValue("", 3201, "SeoLangs[", 3201, 9, true);
#nullable restore
#line 50 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 3210, count, 3210, 6, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3216, "].LangId", 3216, 8, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 3225, "\"", 3245, 1);
#nullable restore
#line 50 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 3233, item.LangId, 3233, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n                                                                <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 3334, "\"", 3363, 3);
                WriteAttributeValue("", 3341, "SeoLangs[", 3341, 9, true);
#nullable restore
#line 51 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 3350, count, 3350, 6, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3356, "].SeoId", 3356, 7, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 3364, "\"", 3383, 1);
#nullable restore
#line 51 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 3372, item.SeoId, 3372, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n\n                                                                <label class=\"control-label\">Başlıq (");
#nullable restore
#line 53 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
                                                                                                Write(item.Lang.Code);

#line default
#line hidden
#nullable disable
                WriteLiteral(")</label>\n                                                                <input");
                BeginWriteAttribute("name", " name=\"", 3585, "\"", 3614, 3);
                WriteAttributeValue("", 3592, "SeoLangs[", 3592, 9, true);
#nullable restore
#line 54 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 3601, count, 3601, 6, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3607, "].Title", 3607, 7, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 3615, "\"", 3634, 1);
#nullable restore
#line 54 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 3623, item.Title, 3623, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"text\" class=\"form-control\" />\n                                                                <label class=\"control-label\">Keywords (");
#nullable restore
#line 55 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
                                                                                                  Write(item.Lang.Code);

#line default
#line hidden
#nullable disable
                WriteLiteral(")</label>\n                                                                <input");
                BeginWriteAttribute("name", " name=\"", 3870, "\"", 3898, 3);
                WriteAttributeValue("", 3877, "SeoLangs[", 3877, 9, true);
#nullable restore
#line 56 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 3886, count, 3886, 6, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3892, "].Keys", 3892, 6, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 3899, "\"", 3917, 1);
#nullable restore
#line 56 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 3907, item.Keys, 3907, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"text\" class=\"form-control\" />\n                                                                <label class=\"control-label\">Description (");
#nullable restore
#line 57 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
                                                                                                     Write(item.Lang.Code);

#line default
#line hidden
#nullable disable
                WriteLiteral(")</label>\n                                                                <input");
                BeginWriteAttribute("name", " name=\"", 4156, "\"", 4184, 3);
                WriteAttributeValue("", 4163, "SeoLangs[", 4163, 9, true);
#nullable restore
#line 58 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 4172, count, 4172, 6, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4178, "].Desc", 4178, 6, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 4185, "\"", 4203, 1);
#nullable restore
#line 58 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
WriteAttributeValue("", 4193, item.Desc, 4193, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"text\" class=\"form-control\" />\n                                                            </div>\n                                                        </div>\n");
#nullable restore
#line 61 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Seo/Update.cshtml"
                                                        count++;
                                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""form-group"">
                            <input type=""submit"" value=""Təsdiq et"" class=""btn btn-primary"" />
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                </div>\n            </div>            \n        </div>\n    </div>\n</div>\n\n<script>\n   \n</script>\n");
            DefineSection("validation", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d6a9fb9c5b50dd5d7c7bb95615f1d2416683786e31553", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_10.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ILangService lang { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SeoCreateVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
