using Bool;

namespace TestClient
{
    class TestApp
    {
        static async Task Main(string[] args)
        {
            var response = await Sdk.GetFeatureFlags();

            foreach (var flag in response)
                Console.WriteLine(flag.Name);
        }
    }
}