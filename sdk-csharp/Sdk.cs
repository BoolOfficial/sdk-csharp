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
                     Bool_FeatureFlag(order_by: {name: asc}) {
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

        static readonly GraphQLRequest featureFlagByKeyRequest = new()
        {
            Query = @"
                query GetFeatureFlags($key: String = """") {
                      Bool_FeatureFlag(where: {key: {_eq: $key}}) {
                        id
                        key
                        name
                        description
                        value
                      }
                }"
        };

        public async Task<FeatureFlag> GetFeatureFlag(string key)
        {
            featureFlagByKeyRequest.Variables = new
            {
                key
            };

            var gqlresponse = await _graphQLClient.SendQueryAsync<FeatureFlagResponse>(featureFlagByKeyRequest);

            if (gqlresponse.Data.Bool_FeatureFlag.Count > 0)
            {
                return gqlresponse.Data.Bool_FeatureFlag[0];
            }

            else throw new FeatureFlagNotFoundException($"No features flags match: {key}");
        }
    }
}

