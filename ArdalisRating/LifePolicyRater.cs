using System;

namespace ArdalisRating
{
    public class LifePolicyRater : Rater
    {
        private readonly RatingEngine _ratingEngine;
        private ConsoleLogger _logger;

        public LifePolicyRater(RatingEngine ratingEngine, ConsoleLogger logger)
        {
            _ratingEngine = ratingEngine;
            _logger = logger;
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating LIFE policy...");
            _logger.Log("Validating policy.");
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                _logger.Log("Life policy must include Date of Birth.");
                return;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                _logger.Log("Centenarians are not eligible for coverage.");
                return;
            }
            if (policy.Amount == 0)
            {
                _logger.Log("Life policy must include an Amount.");
                return;
            }

            var age = GetAge(policy.DateOfBirth);

            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
            {
                _ratingEngine.Rating = baseRate * 2;
                return;
            }
            _ratingEngine.Rating = baseRate;
        }

        private int GetAge(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < dateOfBirth.Day ||
                DateTime.Today.Month < dateOfBirth.Month)
            {
                age--;
            }

            return age;
        }
    }
}
