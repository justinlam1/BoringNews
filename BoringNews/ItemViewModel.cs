using Microsoft.AspNetCore.Components;

namespace BoringNews;

public class ItemViewModel
{
    public int Id { get; set; }
    public string By { get; set; }
    public int Time { get; set; }
    public MarkupString Text { get; set; }
    public List<int> Kids { get; set; }
    public List<ItemViewModel> SubItems { get; set; }
    public int Score { get; set; }
    public string Title { get; set; }
    public Uri Link { get; set; }
}