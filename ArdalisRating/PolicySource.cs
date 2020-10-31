using System.IO;

namespace ArdalisRating
{
    public class PolicySource
    {
        public string GetPolicy()
        {
            return File.ReadAllText("policy.json");
        }
    }
}
