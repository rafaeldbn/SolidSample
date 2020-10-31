namespace ArdalisRating
{
    public class RaterFactory
    {
        private readonly RatingEngine _ratingEngine;
        private ConsoleLogger _logger;

        public RaterFactory(RatingEngine ratingEngine, ConsoleLogger logger)
        {
            _ratingEngine = ratingEngine;
            _logger = logger;
        }

        public Rater CreateRater(PolicyType type)
        {
            switch (type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(_ratingEngine, _logger);

                case PolicyType.Land:
                    return new LandPolicyRater(_ratingEngine, _logger);

                case PolicyType.Life:
                    return new LifePolicyRater(_ratingEngine, _logger);

                default:
                    return null;
            }
        }
    }
}
