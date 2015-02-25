namespace Plasticfloor.Services.WebContent
{
    public static class Extensions
    {
        public static string OneTrailingSlash(this string source)
        {
            return source.TrimEnd(new[] { '/' }) + "/";
        }
    }
}