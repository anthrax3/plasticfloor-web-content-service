using System.Runtime.Serialization;

namespace Plasticfloor.Services.WebContent.Interface.Models
{
    [DataContract]
    public class BlogPostRequest
    {
        [DataMember]
        public string BlogName { get; set; }
        [DataMember]
        public string BlogPostName { get; set; }
    }
}