﻿namespace Me.Web.Mvc.Infrastructure.Mapping.Resolvers
{
    #region using

    using System.Web.Mvc;

    using MarkdownSharp;

    #endregion

    public class MarkdownResolver
    {
        public static MvcHtmlString Resolve(string inputBody)
        {
            var html = FormatMarkdown(inputBody);
            html = SanitizeHtml.Sanitize(html);
            return MvcHtmlString.Create(html);
        }

        public static string FormatMarkdown(string content)
        {
            var md = new Markdown(new MarkdownOptions
            {
                AutoHyperlink = true,
                AutoNewLines = true,
                EncodeProblemUrlCharacters = true,
                LinkEmails = false,
                StrictBoldItalic = true,
            });

            return md.Transform(content);
        }
    }
}
