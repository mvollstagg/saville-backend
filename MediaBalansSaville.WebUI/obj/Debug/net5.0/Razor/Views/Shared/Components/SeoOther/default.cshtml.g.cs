#pragma checksum "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8a63c50cb540f00d28599cc08799d8938c9d77d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_SeoOther_default), @"mvc.1.0.view", @"/Views/Shared/Components/SeoOther/default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8a63c50cb540f00d28599cc08799d8938c9d77d", @"/Views/Shared/Components/SeoOther/default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0d41287da552d6eb24f2f3e17c48247f5293355", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_SeoOther_default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Seo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml"
  
    ViewData["Title"] = "Index";
    string _lang = "az";
    if (httpAccessor.HttpContext.Request.Cookies["lang"] != null)
    {
        _lang = httpAccessor.HttpContext.Request.Cookies["lang"];
    }
    var seo = Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml"
 if (seo != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <meta charset=\"UTF-8\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\n    <meta name=\"title\"");
            BeginWriteAttribute("content", " content=\"", 439, "\"", 515, 2);
#nullable restore
#line 16 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml"
WriteAttributeValue("", 449, seo.SeoLangs.Where(x=>x.Lang.Code==_lang).FirstOrDefault().Title, 449, 65, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 514, "", 515, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\n    <meta name=\"description\"");
            BeginWriteAttribute("content", " content=\"", 546, "\"", 620, 1);
#nullable restore
#line 17 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml"
WriteAttributeValue("", 556, seo.SeoLangs.Where(x=>x.Lang.Code==_lang).FirstOrDefault().Desc, 556, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n    <meta name=\"keywords\"");
            BeginWriteAttribute("content", " content=\"", 648, "\"", 722, 1);
#nullable restore
#line 18 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml"
WriteAttributeValue("", 658, seo.SeoLangs.Where(x=>x.Lang.Code==_lang).FirstOrDefault().Keys, 658, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n    <meta property=\"og:title\"");
            BeginWriteAttribute("content", " content=\"", 754, "\"", 829, 1);
#nullable restore
#line 19 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml"
WriteAttributeValue("", 764, seo.SeoLangs.Where(x=>x.Lang.Code==_lang).FirstOrDefault().Title, 764, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    <meta property=\"og:description\"");
            BeginWriteAttribute("content", " content=\"", 869, "\"", 943, 1);
#nullable restore
#line 20 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml"
WriteAttributeValue("", 879, seo.SeoLangs.Where(x=>x.Lang.Code==_lang).FirstOrDefault().Desc, 879, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    <meta property=\"og:site_name\" content=\"Al Market\" />\n    <meta property=\"og:locale\" content=\"en\" />\n    <meta property=\"og:type\" content=\"media\" />\n    <meta property=\"og:image\" content=\"~/favicon.ico\" />\n    <meta property=\"og:url\"");
            BeginWriteAttribute("content", " content=\"", 1184, "\"", 1240, 1);
#nullable restore
#line 25 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml"
WriteAttributeValue("", 1194, Context.Request.Host + Context.Request.Path, 1194, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    <meta name=\"twitter:title\"");
            BeginWriteAttribute("content", " content=\"", 1275, "\"", 1350, 1);
#nullable restore
#line 26 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml"
WriteAttributeValue("", 1285, seo.SeoLangs.Where(x=>x.Lang.Code==_lang).FirstOrDefault().Title, 1285, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    <meta name=\"twitter:description\"");
            BeginWriteAttribute("content", " content=\"", 1391, "\"", 1465, 1);
#nullable restore
#line 27 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml"
WriteAttributeValue("", 1401, seo.SeoLangs.Where(x=>x.Lang.Code==_lang).FirstOrDefault().Desc, 1401, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n    <meta name=\"twitter:site\" content=\"Al Market\" />\n    <meta name=\"twitter:image\" content=\"~/favicon.ico\" />\n    <title>");
#nullable restore
#line 30 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml"
      Write(seo.SeoLangs.Where(x => x.Lang.Code == _lang).FirstOrDefault().Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </title>\n");
#nullable restore
#line 31 "/Users/matthieuvollstagg/Documents/GitHub/saville-backend/MediaBalansSaville.WebUI/Views/Shared/Components/SeoOther/default.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Seo> Html { get; private set; }
    }
}
#pragma warning restore 1591
