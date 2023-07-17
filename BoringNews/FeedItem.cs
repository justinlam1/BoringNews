using Microsoft.AspNetCore.Components;

namespace BoringNews;

public record FeedItem(
    int id,
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
    int descendants
)
{
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
};