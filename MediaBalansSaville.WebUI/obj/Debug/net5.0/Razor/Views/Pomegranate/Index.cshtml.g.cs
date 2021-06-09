#pragma checksum "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Pomegranate/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43006cb6d6ee4d8f8d1395f8ce569d7b9587e48c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pomegranate_Index), @"mvc.1.0.view", @"/Views/Pomegranate/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43006cb6d6ee4d8f8d1395f8ce569d7b9587e48c", @"/Views/Pomegranate/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0d41287da552d6eb24f2f3e17c48247f5293355", @"/Views/_ViewImports.cshtml")]
    public class Views_Pomegranate_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PomegranateSettings>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Pomegranate/Index.cshtml"
  
    string _lang = ViewBag.Lang ?? "az";

#line default
#line hidden
#nullable disable
            DefineSection("seo", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 7 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Pomegranate/Index.cshtml"
      await Html.RenderPartialAsync("_Seo", "Pomegranate");

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n<section class=\"section-1\">\r\n    <div class=\"container-xl\">\r\n        <div class=\"section-text-main\">\r\n            <p class=\"section-heading\">");
#nullable restore
#line 13 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Pomegranate/Index.cshtml"
                                  Write(Model.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == _lang).MainTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div class=\"section-text\">");
#nullable restore
#line 14 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Pomegranate/Index.cshtml"
                                 Write(Html.Raw(Model.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == _lang).MainDetails));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n\r\n</section>\r\n<section class=\"section-2\">\r\n    <div class=\"container-xl\">\r\n        <div class=\"section-text-main\">\r\n            <p class=\"section-heading\">");
#nullable restore
#line 22 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Pomegranate/Index.cshtml"
                                  Write(Model.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == _lang).RhythmTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div class=\"section-list\">\r\n                ");
#nullable restore
#line 24 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Pomegranate/Index.cshtml"
           Write(Html.Raw(Model.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == _lang).RhythmDetails));

#line default
#line hidden
#nullable disable
            WriteLiteral("           \r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<section class=\"section-3\">\r\n    <div class=\"container-xl\">\r\n        <div class=\"section-text-main\">\r\n            <p class=\"section-heading\">");
#nullable restore
#line 32 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Pomegranate/Index.cshtml"
                                  Write(Model.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == _lang).BoostTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n            <div class=\"section-list\">\r\n                ");
#nullable restore
#line 34 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Pomegranate/Index.cshtml"
           Write(Html.Raw(Model.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == _lang).BoostDetails));

#line default
#line hidden
#nullable disable
            WriteLiteral("                   \r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<section class=\"section-4\">\r\n    <div class=\"container-xl\">\r\n        <div class=\"section-text-main\">\r\n            <p class=\"section-heading\">");
#nullable restore
#line 42 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Pomegranate/Index.cshtml"
                                  Write(Model.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == _lang).HealthInsuranceTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div class=\"section-list\">\r\n                ");
#nullable restore
#line 44 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Pomegranate/Index.cshtml"
           Write(Html.Raw(Model.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == _lang).HealthInsuranceDetails));

#line default
#line hidden
#nullable disable
            WriteLiteral("                 \r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/owl.carousel.min.js""></script>
    <script> 
        $(document).ready(function(){
                $('.section-list li').prepend('<i class=""bi bi-circle-fill""></i>');    
            });
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PomegranateSettings> Html { get; private set; }
    }
}
#pragma warning restore 1591
