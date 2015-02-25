using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Plasticfloor.Services.WebContent.Interface.Models;

namespace Plasticfloor.Services.WebContent.Interface
{
    [ServiceContract]
    public interface IPageService
    {
        [OperationContract]
        Page GetPage(PageRequest request);
    }

    [ServiceContract]
    public interface IContentFragmentService
    {
        [OperationContract]
        ContentFragment GetFragment(FragmentRequest request);
    }
}
