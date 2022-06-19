using Bool;

namespace ExampleNS
{
    class ExampleApp
    {
        static async Task Main(string[] args)
        {
            var TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6InNkay00OTVhNmYxYS00NTkwLTRkNGEtOWFiZi1mNmQ5Y2Q5NWI4NGIiLCJpYXQiOjE2NTU2MzczMzIuMzI3LCJodHRwczovL2hhc3VyYS5pby9qd3QvY2xhaW1zIjp7IngtaGFzdXJhLWFsbG93ZWQtcm9sZXMiOlsib3BlblNESyJdLCJ4LWhhc3VyYS1kZWZhdWx0LXJvbGUiOiJvcGVuU0RLIiwieC1oYXN1cmEtcm9sZSI6Im9wZW5TREsiLCJ4LWhhc3VyYS1jbGllbnQtaWQiOiI0OTVhNmYxYS00NTkwLTRkNGEtOWFiZi1mNmQ5Y2Q5NWI4NGIiLCJ4LWhhc3VyYS1hcHBsaWNhdGlvbi1pZCI6IjA0YzQ5YWFlLWE3YjAtNDMyMi1hZWI3LTMzMTg3MWMxZDYxNSJ9fQ.wx-OWifPtBULMnPEXE8FB5tqYrPXS9xTgygwo7GraSs";

            Sdk boolsdk = new(TOKEN);

            var flags = await boolsdk.GetFeatureFlags();

            Console.WriteLine("Feature Flags: ");
            foreach (var flag in flags)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine($"Id: {flag.Id}");
                Console.WriteLine($"Name: {flag.Name}");
                Console.WriteLine($"Key: {flag.Key}");
                Console.WriteLine($"Desc: {flag.Description}");
                Console.WriteLine($"Value: {flag.Value}");
                Console.WriteLine("--------------------");
            }
        }
    }
}