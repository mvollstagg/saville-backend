#pragma checksum "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "978f8025e5d3418983bc49782cb96800a9a23358"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_CMS_Views_Product_Index), @"mvc.1.0.view", @"/Areas/CMS/Views/Product/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"978f8025e5d3418983bc49782cb96800a9a23358", @"/Areas/CMS/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94c59595ea7a05ed7ee15fa0be54959a37c52328", @"/Areas/CMS/Views/_ViewImports.cshtml")]
    public class Areas_CMS_Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "CMS", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 50px;height: 50px;object-fit: cover;border-radius: 10px;filter: drop-shadow(20px);filter: drop-shadow(3px 3px 4px #000);display: block;margin-left: auto;margin-right: auto;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn text-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-12 my-4 mx-auto"">
        <div class=""card shadow mb-4"">
            <div class=""card-header"">
                Məhsullar bölümü
            </div>
            <div class=""card-body"">
                <div class=""d-flex justify-content-end my-3"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "978f8025e5d3418983bc49782cb96800a9a233587516", async() => {
                WriteLiteral("<i class=\"fas fa-fw fa-plus\"></i>Əlavə et");
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
            WriteLiteral(@"
                </div>
                <div class=""table-responsive"">
                    <table class=""table table-striped table-bordered dataTable"" id=""tablom"">
                        <thead>
                            <tr>
                                <th>Ad (AZ)</th>
                                <th>Şəkil (əsas)</th>
                                <th>Kateqoriya</th>
                                <th>Tarix</th>
                                <th>Slug Url</th>
                                <th>Url Id</th>
                                <th>Status</th>
                                <th>Əməliyyatlar</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 32 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                             if (Model == null || Model.Count() == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\n                                    <td colspan=\"12\" class=\"text-center\">\n                                        Siyahı boşdur\n                                    </td>\n                                </tr>\n");
#nullable restore
#line 39 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                            }
                            else
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                                 foreach (var product in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr data-id=\"\">\n                                        <td>\n                                            ");
#nullable restore
#line 46 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                                        Write(product.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Name.Length > 30 ? product.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Name.Substring(0, 30) : product.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "978f8025e5d3418983bc49782cb96800a9a2335811953", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2327, "~/files/product/", 2327, 16, true);
#nullable restore
#line 49 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
AddHtmlAttributeValue("", 2343, product.ProductPhotos.FirstOrDefault(x => x.IsCover == true).PhotoUrl, 2343, 70, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
#nullable restore
#line 52 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                                       Write(product.Category.CategoryLangs.FirstOrDefault(x => x.Lang.Code == "az").Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
#nullable restore
#line 55 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                                       Write(product.RecordedAtDate.ToString("dd/MM/yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
#nullable restore
#line 58 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                                       Write(product.SlugUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
#nullable restore
#line 61 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                                       Write(product.UrlId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
#nullable restore
#line 64 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                                        Write(product.IsActive ? "aktiv" : "deaktiv");

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "978f8025e5d3418983bc49782cb96800a9a2335815991", async() => {
                WriteLiteral("<i class=\"fas fa-fw fa-pencil-alt\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 67 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                                                                                                             WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "978f8025e5d3418983bc49782cb96800a9a2335818784", async() => {
                WriteLiteral("<i class=\"fas fa-fw fa-trash-alt\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                                                                                                             WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                            <a target=\"_blank\" class=\"btn text-success\"");
            BeginWriteAttribute("href", " href=\"", 4071, "\"", 4123, 4);
            WriteAttributeValue("", 4078, "/az/məhsullar/", 4078, 14, true);
#nullable restore
#line 69 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
WriteAttributeValue("", 4092, product.SlugUrl, 4092, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4108, "-", 4108, 1, true);
#nullable restore
#line 69 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
WriteAttributeValue("", 4109, product.UrlId, 4109, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-fw fa-eye\"></i></a>\n                                        </td>\n                                    </tr>\n");
#nullable restore
#line 72 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Areas/CMS/Views/Product/Index.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\n                    </table>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $('#tablom').DataTable({
            language: {
                info: ""_TOTAL_ kayıttan _START_ - _END_ kayıt gösteriliyor."",
                infoEmpty:      ""Gösterilecek hiç kayıt yok."",
                loadingRecords: ""Kayıtlar yükleniyor."",
                zeroRecords: ""Tablo boş"",
                search: ""Arama:"",
                infoFiltered:   ""(toplam _MAX_ kayıttan filtrelenenler)"",
                buttons: {
                    copyTitle: ""Panoya kopyalandı."",
                    copySuccess:""Panoya %d satır kopyalandı"",
                    copy: ""Kopyala"",
                    print: ""Yazdır"",
                },

                paginate: {
                    first: ""İlk"",
                    previous: ""Önceki"",
                    next: ""Sonraki"",
                    last: ""Son""
                },
                responsive: true
            }
        });
        
        $(document).on(""change"", "".custom-select"", function () {
            var count = $(this).val();
        ");
                WriteLiteral("    $.ajax({\n                type: \"GET\",\n                url: \"/cms/meqale?count=\" + count,\n            });\n        })\n    </script>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
