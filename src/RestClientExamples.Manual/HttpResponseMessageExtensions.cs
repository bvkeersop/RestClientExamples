using System.Text.Json;

namespace RestClientExamples.Manual;

public static class HttpResponseMessageExtensions
{
    public static async Task<TContentType?> GetDeserializedContent<TContentType>(this HttpResponseMessage? httpResponseMessage)
    {
        if (httpResponseMessage is null)
        {
            return default;
        }

        var json = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TContentType>(json);
    }
}
