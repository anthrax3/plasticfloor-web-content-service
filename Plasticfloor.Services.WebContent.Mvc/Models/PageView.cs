using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Plasticfloor.Services.WebContent.Mvc.Models
{
    public class PageView : ContentElementView
    {
        public string Body { get; set; }
        public PageRelatedContentView RelatedContent { get; set; }
        public ContentMetaDataView MetaData { get; set; }
    }

    public class PageContentView
    {
        public PageContentTypes ContentType { get; set; }
        public PageView Page { get; set; }
    }

    public class ContentFragmentView : ContentElementView
    {
        public string Body { get; set; }        
    }
}
