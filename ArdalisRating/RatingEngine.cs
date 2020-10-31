namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private ConsoleLogger _logger { get; set; } = new ConsoleLogger();
        private PolicySource _policySource { get; set; } = new PolicySource();
        private PolicySerializer _policySerializer { get; set; } = new PolicySerializer();
        public decimal Rating { get; set; }

        public void Rate()
        {
            _logger.Log("Starting rate.");
            _logger.Log("Loading policy.");

            string policyJson = _policySource.GetPolicy();

            var policy = _policySerializer.GetPolicyFromJsonString(policyJson);

            var raterFactory = new RaterFactory(this, _logger);
            var rater = raterFactory.CreateRater(policy.Type);
            rater?.Rate(policy);

            _logger.Log("Rating completed.");
        }
    }
}
