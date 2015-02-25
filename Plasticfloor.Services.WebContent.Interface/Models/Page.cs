using System;
using System.Runtime.Serialization;

namespace Plasticfloor.Services.WebContent.Interface.Models
{
    [Serializable][DataContract]
    public class Page : ContentElement
    {
        [DataMember]
        private readonly EnumValue<PageContentTypes> _contentType = new EnumValue<PageContentTypes>();
        
        [IgnoreDataMember]
        public PageContentTypes ContentType
        {
            get { return _contentType.Value; }
            set { _contentType.Value = value; }
        }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public PageRelatedContent RelatedContent { get; set; }
        [DataMember]
        public ContentMetaData MetaData { get; set; }
    }

    [Serializable]
    [DataContract]
    public class ContentFragment : ContentElement
    {
         [DataMember]
        public string Body { get; set; }       
    }
}