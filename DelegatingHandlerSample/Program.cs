// See https://aka.ms/new-console-template for more information
HttpClient client = new HttpClient(new DebugHttpMessageHandler());

client.DefaultRequestHeaders.UserAgent.ParseAdd("Duotify/1.0");

HttpResponseMessage response = await client.GetAsync("https://postman-echo.com/get");

string jsonText = await response.Content.ReadAsStringAsync();
