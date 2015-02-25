using System.Net.Http;
using System.Threading.Tasks;

namespace Plasticfloor.Services.WebContent
{
    public abstract class ApiGetRequestBase<TInput, TContent>  : IContentProvider<TInput, TContent>
    {
        protected string Url { get; private set; }

        protected ApiGetRequestBase(string apiUrl, string action)
        {
            Url = string.Concat(apiUrl.OneTrailingSlash(), action, "/");
        }

        public TContent GetContent(TInput input)
        {
            var client = new HttpClient();
            var task = client.GetAsync(
                string.Concat(Url, FormatInput(input)));
            var result = task.ContinueWith(
                t => t.Result.Content.ReadAsAsync<TContent>())
                .Unwrap().Result;
            return result;
        }

        protected abstract string FormatInput(TInput input);

        protected virtual string GetUrl()
        {
            return Url;
        }
    }
}