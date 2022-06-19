using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;

namespace Bool
{
    public class Sdk
    {
        static readonly string USE_BOOL_API = "https://api.usebool.com/v1/graphql";

        readonly GraphQLHttpClient _graphQLClient;

        public Sdk(string token)
        {
            _graphQLClient = new(USE_BOOL_API, new SystemTextJsonSerializer());
            _graphQLClient.HttpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);
        }

        static readonly GraphQLRequest featureFlagsRequest = new()
        {
            Query = @"
                query GetFeatureFlags {
                     Bool_FeatureFlag {
                        id
                        key
                        name
                        description
                        value
                      }
                }"
        };

        public async Task<List<FeatureFlag>> GetFeatureFlags()
        {
            var gqlresponse = await _graphQLClient.SendQueryAsync<FeatureFlagResponse>(featureFlagsRequest);
            return gqlresponse.Data.Bool_FeatureFlag;
        }
    }
}

