namespace Bool
{
    public class FeatureFlagNotFoundException : System.Exception
    {
        public FeatureFlagNotFoundException(string message) : base(message) { }
    }
}
