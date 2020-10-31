using System;

namespace ArdalisRating
{
    public class AutoPolicyRater : Rater
    {
        private readonly RatingEngine _ratingEngine;
        private ConsoleLogger _logger;

        public AutoPolicyRater(RatingEngine ratingEngine, ConsoleLogger logger)
        {
            _ratingEngine = ratingEngine;
            _logger = logger;
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating AUTO policy...");
            _logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                _logger.Log("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _ratingEngine.Rating = 1000m;
                    return;
                }
                _ratingEngine.Rating = 900m;
            }
        }
    }
}
