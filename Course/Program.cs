var httpClient = new HttpClient();
var res = await httpClient.GetAsync("http://localhost:5197/fast?input=78");
Console.WriteLine(await res.Content.ReadAsStringAsync());