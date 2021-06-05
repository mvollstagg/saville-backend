#pragma checksum "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Receipt/LoadMoreReceipt.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fea9beb42286bc1505e0beba0e8c9cb76f81e51d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Receipt_LoadMoreReceipt), @"mvc.1.0.view", @"/Views/Receipt/LoadMoreReceipt.cshtml")]
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
#line 1 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/_ViewImports.cshtml"
using MediaBalansSaville.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/_ViewImports.cshtml"
using MediaBalansSaville.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/_ViewImports.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/_ViewImports.cshtml"
using MediaBalansSaville.Services.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/_ViewImports.cshtml"
using MediaBalansSaville.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/_ViewImports.cshtml"
using MediaBalansSaville.Data.DAL;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fea9beb42286bc1505e0beba0e8c9cb76f81e51d", @"/Views/Receipt/LoadMoreReceipt.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0d41287da552d6eb24f2f3e17c48247f5293355", @"/Views/_ViewImports.cshtml")]
    public class Views_Receipt_LoadMoreReceipt : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Receipt>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Receipt", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Item", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("receptcard"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Receipt/LoadMoreReceipt.cshtml"
  
    string _lang = ViewBag.Lang ?? "az";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 8 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Receipt/LoadMoreReceipt.cshtml"
 if (Model != null)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Receipt/LoadMoreReceipt.cshtml"
     foreach (var receipt in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fea9beb42286bc1505e0beba0e8c9cb76f81e51d6017", async() => {
                WriteLiteral("\n                <div class=\"card\">\n                    <div class=\"recept-image\">\n                        <img");
                BeginWriteAttribute("src", " src=\"", 549, "\"", 639, 2);
                WriteAttributeValue("", 555, "/files/receipt/", 555, 15, true);
#nullable restore
#line 16 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Receipt/LoadMoreReceipt.cshtml"
WriteAttributeValue("", 570, receipt.ReceiptPhotos.FirstOrDefault(x => x.IsMain == true).PhotoUrl, 570, 69, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" alt=\"receptimage\">\n                    </div>\n                    <div class=\"card-body\">\n                        <h4 class=\"card-status\">");
#nullable restore
#line 19 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Receipt/LoadMoreReceipt.cshtml"
                                           Write(receipt.Category.CategoryLangs.FirstOrDefault(x => x.Lang.Code == _lang).Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\n                        <h5 class=\"card-title\">");
#nullable restore
#line 20 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Receipt/LoadMoreReceipt.cshtml"
                                          Write(receipt.ReceiptLangs.FirstOrDefault(x => x.Lang.Code == _lang).Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\n                        <span class=\"btn arrow\"><i class=\"bi bi-arrow-right\"></i></span>\n                    </div>\n                </div>\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-_lang", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Receipt/LoadMoreReceipt.cshtml"
                                                               WriteLiteral(_lang);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["_lang"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-_lang", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["_lang"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Receipt/LoadMoreReceipt.cshtml"
                                                                                          WriteLiteral(receipt.SlugUrl.ToLower());

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slugurl"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slugurl", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slugurl"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Receipt/LoadMoreReceipt.cshtml"
                                                                                                                                       WriteLiteral(receipt.UrlId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["urlid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-urlid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["urlid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n");
#nullable restore
#line 26 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Receipt/LoadMoreReceipt.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Receipt/LoadMoreReceipt.cshtml"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IConfiguration _configuration { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ApplicationDbContext context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor httpAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Receipt>> Html { get; private set; }
    }
}
#pragma warning restore 1591