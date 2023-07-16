using System.Net.Http.Json;

namespace BoringNews;

public class HackerNewsApiService
{
    private readonly HttpClient _client;

    public HackerNewsApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IList<int>> GetTopStoryIds()
    {
        var topStories = await _client.GetFromJsonAsync<IList<int>>("topstories.json");
        
        if (topStories is null)
        {
            throw new InvalidOperationException("Unable to retrieve top stories.");
        }

        return topStories;
    }

    private async Task<FeedItem> GetFeedItemDetails(int itemId)
    {
        var itemDetails = await _client.GetFromJsonAsync<FeedItem>($"item/{itemId}.json");
        
        if (itemDetails is null)
        {
            throw new InvalidOperationException("Unable to item details.");
        }

        return itemDetails;
    }

    public async Task<IList<FeedItem>> GetFeedItemDetails(IEnumerable<int> itemIds)
    {
        var itemDetailsList = new List<FeedItem>();
        foreach (var itemId in itemIds)
        {
            var itemDetail = await GetFeedItemDetails(itemId);
            itemDetailsList.Add(itemDetail);
        }

        return itemDetailsList;
    }
}

public record FeedItem(
    int id,
    bool deleted,
    string type,
    string by,
    int time,
    string text,
    bool dead,
    int parent,
    int poll,
    int[] kids,
    string url,
    int score,
    string title,
    int[] parts,
    int descendants
);

