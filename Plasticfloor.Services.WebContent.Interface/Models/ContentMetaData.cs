using System;
using System.Runtime.Serialization;

namespace Plasticfloor.Services.WebContent.Interface.Models
{
    [Serializable][DataContract]
    public class ContentMetaData
    {
        [DataMember]public string[] Tags { get; set; }
    }
}