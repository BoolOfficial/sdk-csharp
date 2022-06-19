using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;

namespace Bool
{
    public class Sdk
    {
        static readonly string TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6InNkay00OTVhNmYxYS00NTkwLTRkNGEtOWFiZi1mNmQ5Y2Q5NWI4NGIiLCJpYXQiOjE2NTU2MzczMzIuMzI3LCJodHRwczovL2hhc3VyYS5pby9qd3QvY2xhaW1zIjp7IngtaGFzdXJhLWFsbG93ZWQtcm9sZXMiOlsib3BlblNESyJdLCJ4LWhhc3VyYS1kZWZhdWx0LXJvbGUiOiJvcGVuU0RLIiwieC1oYXN1cmEtcm9sZSI6Im9wZW5TREsiLCJ4LWhhc3VyYS1jbGllbnQtaWQiOiI0OTVhNmYxYS00NTkwLTRkNGEtOWFiZi1mNmQ5Y2Q5NWI4NGIiLCJ4LWhhc3VyYS1hcHBsaWNhdGlvbi1pZCI6IjA0YzQ5YWFlLWE3YjAtNDMyMi1hZWI3LTMzMTg3MWMxZDYxNSJ9fQ.wx-OWifPtBULMnPEXE8FB5tqYrPXS9xTgygwo7GraSs";
        static readonly string USE_BOOL_API = "https://api.usebool.com/v1/graphql";

        static readonly GraphQLHttpClient graphQLClient = new GraphQLHttpClient(USE_BOOL_API, new SystemTextJsonSerializer());

        public static async Task<List<FeatureFlag>> GetFeatureFlags()
        {
            graphQLClient.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TOKEN);

            var featureFlagsRequest = new GraphQLRequest
            {
                Query = @"
                query GetFeatureFlags {
                     Bool_FeatureFlag {
                        key
                        value
                        name
                      }
                }"
            };

           var gqlresponse = await graphQLClient.SendQueryAsync<List<FeatureFlag>>(featureFlagsRequest);

            return gqlresponse.Data;
        }
    }
}

