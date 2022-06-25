using System.Collections.Generic;

namespace Bool
{
    public class FeatureFlagResponse
    {
        public List<FeatureFlag> Bool_FeatureFlag { get; set; }
    }

    public class FeatureFlag
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Value { get; set; }

    };
}

