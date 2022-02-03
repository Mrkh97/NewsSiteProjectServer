namespace NewsSiteServer
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; } =string.Empty;
        public string Text { get; set; }=string.Empty;  
        public string ImgSrc { get; set; }=string.Empty ;
    }
}
