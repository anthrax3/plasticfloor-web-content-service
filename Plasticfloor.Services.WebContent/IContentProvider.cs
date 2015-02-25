namespace Plasticfloor.Services.WebContent
{
    public interface IContentProvider<in TInput, out TContent>
    {
        TContent GetContent(TInput input);
    }
}