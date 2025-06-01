using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class ApiBenchmark
{
    private HttpClient _client;

    [GlobalSetup]
    public void Setup()
    {
        _client = new HttpClient { BaseAddress = new Uri("https://localhost:7069/api/") };
    }

    [Benchmark]
    public async Task SequentialGetRecipes()
    {
        for (int i = 0; i < 500; i++)
        {
            var response = await _client.GetAsync("recipes");
            response.EnsureSuccessStatusCode();
        }
    }
}
