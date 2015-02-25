using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Plasticfloor.Services.WebContent.Interface.Models;

namespace Plasticfloor.Services.WebContent.Mvc.Models
{
    public static class WebContentServiceExtensions
    {
        public static ContentMetaDataView ToViewModel(this ContentMetaData source)
        {
            return new ContentMetaDataView
            {
                Tags = source.Tags
            };
        }

        public static PageRelatedContentView ToViewModel(this PageRelatedContent source)
        {
            return PopulateContentElementView(source, new PageRelatedContentView
            {
                PageRelatedContentElements =
                    source.PageRelatedContentElements.Select(e=>e.ToContentElementView()).ToArray()
            });
        }

        public static PageView ToViewModel(this Page source)
        {
            var page = PopulateContentElementView(source, new PageView
            {
                Body = source.Body
            });
            if (source.MetaData != null) page.MetaData = source.MetaData.ToViewModel();
            if (source.RelatedContent != null) page.RelatedContent = source.RelatedContent.ToViewModel();
            return page;
        }

        public static ContentFragmentView ToViewModel(this ContentFragment source)
        {
            var fragment = PopulateContentElementView(source, new ContentFragmentView()
            {
                Body = source.Body
            });
            return fragment;
        }

        public static ContentElementView ToContentElementView(this ContentElement source)
        {
            return new ContentElementView
            {
                Description = source.Description,
                PublishedDateTime = source.PublishedDateTime,
                Title = source.Title,
                UrlName = source.UrlName
            };
        }

        public static TElementView PopulateContentElementView<TElementView>(ContentElement source, TElementView target) where TElementView : ContentElementView
        {
            target.Description = source.Description;
            target.PublishedDateTime = source.PublishedDateTime;
            target.Title = source.Title;
            target.UrlName = source.UrlName;
            return target;
        }

        public static PageContentTypes ToPageContentTypes(
            this Services.WebContent.Interface.Models.PageContentTypes source)
        {
            switch (source)
            {
                case Services.WebContent.Interface.Models.PageContentTypes.Blog:
                    {
                        return PageContentTypes.BlogPost;
                    }
                case Services.WebContent.Interface.Models.PageContentTypes.NotFound:
                    {
                        return PageContentTypes.NotFound;
                    }
                default:
                    {
                        return PageContentTypes.Page;
                    }
            }
        }
    }
}
