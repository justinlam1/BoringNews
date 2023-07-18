using Microsoft.AspNetCore.Components;

namespace BoringNews;

public class FeedItem
{
    public FeedItem(int id,
        bool? deleted,
        string type,
        string by,
        int time,
        string text,
        bool dead,
        int parent,
        int poll,
        int[]? kids,
        string? url,
        int score,
        string title,
        int[] parts,
        int descendants)
    {
        this.id = id;
        this.deleted = deleted;
        this.type = type;
        this.by = by;
        this.time = time;
        this.text = text;
        this.dead = dead;
        this.parent = parent;
        this.poll = poll;
        this.kids = kids;
        this.url = url;
        this.score = score;
        this.title = title;
        this.parts = parts;
        this.descendants = descendants;
    }

    public MarkupString RenderText => (MarkupString)text;
    public Uri? Link
    {
        get
        {
            if (url != null)
            {
                return new(url);
            }
            else
            {
                return null;
            }
        }
    }

    public int id { get; init; }
    public bool? deleted { get; init; }
    public string type { get; init; }
    public string by { get; init; }
    public int time { get; init; }
    public string text { get; init; }
    public bool dead { get; init; }
    public int parent { get; init; }
    public int poll { get; init; }
    public int[]? kids { get; init; }
    public string? url { get; init; }
    public int score { get; init; }
    public string title { get; init; }
    public int[] parts { get; init; }
    public int descendants { get; init; }

    public HashSet<FeedItem> SubItems { get; set; }
    public bool IsExpanded { get; set; }
};