using System;
using System.Runtime.Serialization;

namespace Plasticfloor.Services.WebContent.Interface.Models
{
    [Serializable][DataContract]
    public class ContentElement
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string UrlName { get; set; }
        public string Url { get { return string.Concat("/", UrlName); } }
        [DataMember]
        public DateTime PublishedDateTime { get; set; }
    }
}