using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace MediaBalansSaville.WebUI.Areas.CMS.Models
{
    public class MediaUpdateVM
    {
        public string TitleAZ { get; set; }
        public string TitleRU { get; set; }
        public string TitleEN { get; set; }
        public string TitleVidAZ { get; set; }
        public string TitleVidRU { get; set; }
        public string TitleVidEN { get; set; }
        public string TitlePicAZ { get; set; }
        public string TitlePicRU { get; set; }
        public string TitlePicEN { get; set; }
        public string DetailsAZ { get; set; }
        public string DetailsRU { get; set; }
        public string DetailsEN { get; set; }
        public string PhotoUrl { get; set; }
        public string Kategori { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<CategoryLang> Categories { get; set; }
        public int CategoryId { get; set; }
        public IFormFile MainPhotoFile { get; set; }
        public List<string> PhotoUrls { get; set; } = new List<string>();
        public List<IFormFile> PhotoFiles { get; set; }
        public bool IsVideo { get; set; }
        public string VideoUrl { get; set; }
        public bool IsActive { get; set; }
        public string SeoTitleAZ { get; set; }
        public string SeoKeysAZ { get; set; }
        public string SeoDescAZ { get; set; }
        public string SeoTitleRU { get; set; }
        public string SeoKeysRU { get; set; }
        public string SeoDescRU { get; set; }
        public string SeoTitleEN { get; set; }
        public string SeoKeysEN { get; set; }
        public string SeoDescEN { get; set; }
    }
}
