using System.Net.Http.Json;

namespace BoringNews;

public class HackerNewsApiService
{
    private readonly HttpClient _client;

    public HackerNewsApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<int>> GetTopStoryIds(int page = 1)
    {
        var topStories = await _client.GetFromJsonAsync<IEnumerable<int>>("topstories.json");
        
        if (topStories is null)
        {
            throw new InvalidOperationException("Unable to retrieve top stories.");
        }

        const int itemsPerPage = 20;
        var result = topStories.Skip(page * itemsPerPage - itemsPerPage).Take(itemsPerPage);

        return result;
    }

    public async Task<FeedItem> GetFeedItemDetails(int itemId)
    {
        var itemDetails = await _client.GetFromJsonAsync<FeedItem>($"item/{itemId}.json");
        
        if (itemDetails is null)
        {
            throw new InvalidOperationException("Unable to item details.");
        }

        return itemDetails;
    }

    public async Task<IEnumerable<FeedItem>> GetFeedItemDetails(IEnumerable<int> itemIds)
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