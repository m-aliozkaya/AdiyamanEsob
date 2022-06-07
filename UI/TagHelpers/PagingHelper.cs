using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UI.TagHelpers;

[HtmlTargetElement("paginator", Attributes = "total-pages, current-page, link-url")]
public class PagingHelper : TagHelper
{
    private const int LinksPerPage = 5;
    private const string PageListClass = "pagination justify-content-center";
    private const string PageListItemClass = "page-item";
    private const string PageLinkClass = "page-link";
    private const string PageSelectedClass = "active";
    private const string PageDisabledClass = "disabled";

    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public string LinkUrl { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var outerDiv = new TagBuilder("div");

        if (TotalPages <= 1) return;
        int startPage;
        int endPage;
        if (TotalPages <= LinksPerPage)
        {
            startPage = 1;
            endPage = TotalPages;
        }
        else
        {
            if (CurrentPage + LinksPerPage - 1 > TotalPages)
            {
                startPage = CurrentPage - ((CurrentPage + LinksPerPage - 1)
                                           - TotalPages);
                endPage = (CurrentPage + LinksPerPage - 1) -
                          ((CurrentPage + LinksPerPage - 1) - TotalPages);
            }
            else
            {
                if (LinksPerPage != 2)
                {
                    startPage = CurrentPage - (LinksPerPage / 2);
                    if (startPage < 1)
                    {
                        startPage = 1;
                    }

                    endPage = startPage + LinksPerPage - 1;
                }
            }
        }

        var linkDiv = new TagBuilder("ul");
        linkDiv.InnerHtml.AppendHtml(GeneratePageLinks("İlk Sayfa", 1));
        for (var i = startPage; i <= endPage; i++)
        {
            linkDiv.InnerHtml.AppendHtml(GeneratePageLinks(i));
        }

        linkDiv.InnerHtml.AppendHtml(GeneratePageLinks("Son Sayfa", TotalPages));
        linkDiv.AddCssClass(PageListClass);
        outerDiv.InnerHtml.AppendHtml(linkDiv);

        output.TagName = "nav";
        output.Content.AppendHtml(outerDiv.InnerHtml);
    }

    private TagBuilder GeneratePageLinks(string buttonName, int page)
    {
        var li = new TagBuilder("li");
        li.AddCssClass(PageListItemClass);

        var a = new TagBuilder("a")
        {
            Attributes =
            {
                ["href"] = $"/{LinkUrl}/{page}"
            }
        };
        a.AddCssClass(PageLinkClass);
        a.InnerHtml.Append(buttonName);

        li.InnerHtml.AppendHtml(a);

        if (page == CurrentPage && page >= 1)
        {
            li.AddCssClass(PageDisabledClass);
        }
        
        return li;
    }
    private TagBuilder GeneratePageLinks(int page)
    {
        var li = new TagBuilder("li");
        li.AddCssClass(PageListItemClass);

        var a = new TagBuilder("a")
        {
            Attributes =
            {
                ["href"] = $"/{LinkUrl}/{page}"
            }
        };
        
        a.AddCssClass(PageLinkClass);
        a.InnerHtml.Append(page.ToString());
        
        li.InnerHtml.AppendHtml(a);

        if (page == CurrentPage)
        {
            li.AddCssClass(PageSelectedClass);
        }
        
        return li;
    }
}