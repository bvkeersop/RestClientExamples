using System.Net.Http.Headers;
using System.Text.Json;

namespace RestClientExamples.Manual;

public static class ObjectExtensions
{
    public static HttpContent ToJsonHttpContent<TObject>(this TObject @object) where TObject : class
    {
        var json = JsonSerializer.Serialize(@object);
        var httpContent = new StringContent(json);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return httpContent;
    }
}
