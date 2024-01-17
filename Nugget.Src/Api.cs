using System.Net.Http.Json;
using Models;

namespace Logic;

class Api
{
    readonly static HttpClient http = new();

    public static async Task<Root?> Query(string packageName, int resultsCount = 30)
    {
        var url = $"https://azuresearch-usnc.nuget.org/query?q={packageName}&take={resultsCount}";
        var result = http.GetFromJsonAsync<Root>(url);
        return await result;
    }
}
