using System;

namespace Plasticfloor.Services.WebContent.Mvc.Models
{
    public class BlogPostView
    {
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public string BlogUrlName { get; set; }
        public string PostTitle { get; set;}
        public string PostDescription { get; set; }
        public string PostUrlName { get; set; }
        public DateTime PostPublishedDate { get; set; }
        public string PostBody { get; set; }
        public ContentMetaDataView PostMetaData { get; set; }
        public ContentElementView[] Posts { get; set; }
    }
}