namespace TuyensinhVido.Models
{
    public class PagingLink
    {
        public string Text { get; set; }
        public int PageIndex { get; set; }
        public bool Enabled { get; set; }
        public bool Active { get; set; }
        public PagingLink(int pageindex, bool enabled, string text)
        {
            PageIndex = pageindex;
            Enabled = enabled;
            Text = text;
        }
    }
}
