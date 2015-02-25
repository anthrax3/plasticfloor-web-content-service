using System;
using System.Runtime.Serialization;

namespace Plasticfloor.Services.WebContent.Interface.Models
{
    [Serializable][DataContract]
    public class PageRelatedContent : ContentElement
    {
        [DataMember]public ContentElement[] PageRelatedContentElements { get; set; }
    }
}