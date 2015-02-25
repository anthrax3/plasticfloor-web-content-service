using System;

namespace Plasticfloor.Services.WebContent.Mvc.Models
{
    public class ContentElementView
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UrlName { get; set; }
        public string Url { get { return string.Concat("/", UrlName); } }
        public DateTime PublishedDateTime { get; set; }
    }
}