using RestSharp;
using System.Text.Json;

RestClient client = new("https://journeyplanner.integration.sl.se/");
string key = "";

Console.WriteLine("Sök hållplats:");
string? search = Console.ReadLine()?.ToLower();

RestRequest request = new($"v1/typeahead.json?key={key}&searchString={search}");
RestResponse response = client.GetAsync(request).Result;

if (response.StatusCode != System.Net.HttpStatusCode.OK) {
    Console.WriteLine(response.ErrorMessage);
    return;
}



ResponseData responseData = JsonSerializer.Deserialize<ResponseData>(response.Content);


int idx = 0;
foreach (Station station in responseData.Stations) {
    Console.WriteLine(idx.ToString() + ". " + station.Name);
    idx++;
}

bool tryAgain = true;
while (tryAgain || idx >= responseData.Stations.Count() || idx < 0) {
    tryAgain = int.TryParse(Console.ReadLine(), out idx);
}

// Console.WriteLine(station.Name);
Console.WriteLine(responseData.Stations[idx].Name);


Console.ReadLine();