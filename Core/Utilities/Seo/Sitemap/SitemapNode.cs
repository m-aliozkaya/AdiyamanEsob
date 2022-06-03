namespace Core.Utilities.Seo.Sitemap
{
    public class SitemapNode
    {
        public string Url { get; set; }
        public DateTime? Modified { get; set; }
        public ChangeFrequency? ChangeFrequency { get; set; }
        public double? Priority { get; set; }
    }
}
