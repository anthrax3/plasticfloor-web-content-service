using System.Runtime.Serialization;

namespace Plasticfloor.Services.WebContent.Interface.Models
{
    [DataContract]
    public enum PageContentTypes
    {
        [EnumMember]Default = 0,
        [EnumMember]Blog = 1,
        [EnumMember]NotFound = 1000
    }
}