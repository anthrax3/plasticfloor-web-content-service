using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Plasticfloor.Services.WebContent.Interface.Models
{
    [DataContract]
    public class PageRequest
    {
        [DataMember]
        public string UrlName { get; set; }

        [DataMember]
        public string RelativeContentUrlPrefix { get; set; }
    }

    [DataContract]
    public class FragmentRequest
    {
        [DataMember]
        public string UrlName { get; set; }

        [DataMember]
        public string RelativeContentUrlPrefix { get; set; }
    }
}
