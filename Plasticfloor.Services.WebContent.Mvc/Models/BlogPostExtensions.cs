using System.Linq;

namespace Plasticfloor.Services.WebContent.Mvc.Models
{
    public static class BlogPostExtensions
    {
        //public static BlogPostHeaderView ToBlogPostHeaderView(this PageRelatedContentElementView source, string blogUrlName)
        //{
        //    return new BlogPostHeaderView
        //    {
        //        Description = source.Description,
        //        PostPublishedDate = source.PublishedDateTime,
        //        Title = source.Title,
        //        UrlName = source.UrlName
        //    };
        //}

        public static BlogPostView ToBlogPostView(this PageView source)
        {
            var view = new BlogPostView
            {
                PostBody = source.Body,
                PostMetaData = source.MetaData,
                PostPublishedDate = source.PublishedDateTime,
                PostDescription = source.Description,
                PostTitle = source.Title,
                PostUrlName = source.UrlName
            };
            if (source.RelatedContent == null) return view;
            view.BlogDescription = source.RelatedContent.Description;
            view.BlogTitle = source.RelatedContent.Title;
            view.BlogUrlName = source.RelatedContent.UrlName;
            view.Posts = source.RelatedContent.PageRelatedContentElements;
            return view;
        }
    }
}