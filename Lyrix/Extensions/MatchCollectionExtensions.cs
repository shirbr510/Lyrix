using System.Linq;
using System.Text.RegularExpressions;

namespace Lyrix.Extensions
{
    internal static class MatchCollectionExtensions
    {
        public static string JoinMatches(this MatchCollection matchCollection)
        {
            if (matchCollection.Count ==0)
            {
                return string.Empty;
            }
            var matchValueEnumerable = matchCollection.OfType<Match>().Select(match => match.Value);
            return string.Join("\n", matchValueEnumerable);
        }
    }
}
