#pragma checksum "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Product/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21aac3703e64031cbdaf7ff297ccc7684ef3032e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21aac3703e64031cbdaf7ff297ccc7684ef3032e", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0d41287da552d6eb24f2f3e17c48247f5293355", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Product/Index.cshtml"
  
    string _lang = ViewBag.Lang ?? "az";

#line default
#line hidden
#nullable disable
            DefineSection("seo", async() => {
                WriteLiteral("\n");
#nullable restore
#line 7 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Product/Index.cshtml"
      await Html.RenderPartialAsync("_Seo", "Product");

#line default
#line hidden
#nullable disable
            }
            );
            DefineSection("Styles", async() => {
                WriteLiteral("\n   \n");
            }
            );
            WriteLiteral("\n<section>\n    <div class=\"mahsullar-general-main\">\n        <div class=\"container\">\n            <div class=\"col-12 col-md-11 col-lg-11 col-xl-11 mx-auto mahsullar-main\">\n                <span class=\"partner-heading\">\n                    ");
#nullable restore
#line 18 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Product/Index.cshtml"
               Write(_configuration[$"Məhsullar:{_lang}"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </span>
                <div class=""row col-12 col-md-12 col-lg-10 col-xl-8 col-xxl-5  gx-2 mx-auto mahsullar-search"">
                    <div class=""col-7 col-md-12 col-lg-9"">
                        <div class=""search-box"">
                            <input id=""filter""  type=""text"" class=""form-control""");
            BeginWriteAttribute("placeholder", " placeholder=\"", 795, "\"", 844, 1);
#nullable restore
#line 23 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Product/Index.cshtml"
WriteAttributeValue("", 809, _configuration[$"Axtarış:{_lang}"], 809, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                            <button onclick=""filterProducts()"" class=""btn""><i class=""bi bi-search""></i></button>
                        </div>
                    </div>
                    <div class=""col-5 col-md-3"">
                        <div class=""dropdown filter-search"">
                            <button class=""btn btn-filter"" type=""button"" id=""dropdownMenuButton1""
                                data-bs-toggle=""dropdown"" aria-expanded=""false"">
                                <i class=""bi bi-funnel-fill""></i>
                                <span>");
#nullable restore
#line 32 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Product/Index.cshtml"
                                 Write(_configuration[$"Filter:{_lang}"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                                <i class=\"bi bi-chevron-down\"></i>\n                            </button>\n                            <ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuButton1\">\n");
#nullable restore
#line 36 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Product/Index.cshtml"
                                 foreach (var category in Model.ProductCategories.Where(x => x.Lang.Code == _lang))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li data-filter=\"");
#nullable restore
#line 38 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Product/Index.cshtml"
                                                Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"dropdown-item\">");
#nullable restore
#line 38 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Product/Index.cshtml"
                                                                                      Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n");
#nullable restore
#line 39 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Product/Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </ul>
                        </div>
                    </div>
                </div>
                <div class=""mahsul-card-general-main"">
                    <div id=""productList"" class=""row row-cols-2 row-cols-md-2 row-cols-lg-3 row-cols-xl-3 row-cols-xxl-4 gx-5 gy-5 mahsullar-card-main"">
");
#nullable restore
#line 46 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Product/Index.cshtml"
                           await Html.RenderPartialAsync("_ProductList", Model.Products); 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                    <div style=""display: none;"" id=""loader"" class=""loader"">
                        <div class=""spinner-border text-danger"" role=""status"">
                            <span class=""visually-hidden"">Loading...</span>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</section>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/owl.carousel.min.js""></script>
    <script> 
        var skipCount = 10;
        function moreProduct()
        {
            $('#loader').show();
            $.ajax({
                    url: 'moreproduct?skipCount=' + skipCount + '&category=Mayonez',
                    type: 'GET',
                    dataType: 'html',
                    success: function (data) {
                        var tetikle = setInterval(function () {
                            $('#productList').append(data);
                            clearInterval(tetikle);
                        }, 900); 
                        skipCount += 10;
                        $('#loader').hide();
                    }
                });
        }       
        function filterProducts()
        {
            $('#loader').show();
            var filterText = document.getElementById(""filter"").value;
            var category = $('#categories').val();
            $('#productL");
                WriteLiteral(@"ist').html('');
            $.ajax({
                    url: 'productfiltered?filter=' + filterText,
                    type: 'GET',
                    dataType: 'html',
                    success: function (data) {
                        var tetikle = setInterval(function () {
                            $('#productList').append(data);
                            clearInterval(tetikle);
                        }, 900);
                        $('#loader').hide();
                    }
                });
        } 

        $(document).on('click','.dropdown-menu li',function  (e){
            $('#loader').show();
            e.preventDefault();
            let filter=$(this).attr('data-filter');
            $('#productList').html('');
            $.ajax({
                    url: 'productfiltered?category=' + filter,
                    type: 'GET',
                    dataType: 'html',
                    success: function (data) {
                        var tetikle = setInterval(function () {
       ");
                WriteLiteral("                     $(\'#productList\').append(data);\n                            clearInterval(tetikle);\n                        }, 900);\n                        $(\'#loader\').hide();\n                    }\n                });\n            }) \n    </script>\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
