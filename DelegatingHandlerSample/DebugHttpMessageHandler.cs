public class DebugHttpMessageHandler : DelegatingHandler
{
  public DebugHttpMessageHandler() : base(new HttpClientHandler())
  {
  }

  public DebugHttpMessageHandler(HttpMessageHandler handler) : base(handler)
  {
  }

  protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
  {
    // Log request method and URL
    Console.WriteLine("Request: {0} {1}", request.Method, request.RequestUri);

    // Log headers
    foreach (var header in request.Headers)
    {
      Console.WriteLine("Default Headers: {0}: {1}", header.Key, string.Join(", ", header.Value));
    }

    if (request.Content != null)
    {
      foreach (var header in request.Content.Headers)
      {
        Console.WriteLine("Content Headers: {0}: {1}", header.Key, string.Join(", ", header.Value));
      }

      // Show request payload
      string payload = await request.Content.ReadAsStringAsync();
      Console.WriteLine("Payload: {0}", payload);
    }

    Console.WriteLine();

    // Send the request and get the response
    HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

    // Log response status
    Console.WriteLine("Response: {0} ({1})", response.StatusCode, ((int)response.StatusCode));

    // Log headers
    foreach (var header in response.Headers)
    {
      Console.WriteLine("Headers: {0}: {1}", header.Key, string.Join(", ", header.Value));
    }

    string jsonText = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Response Body:\n{0}", jsonText);

    return response;
  }
}
