using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    public class Palindrome
    {
        /// <summary>
        /// Find all palindromes of combinations of words in a list
        /// </summary>
        /// <param name="words">The word list</param>
        /// <returns>A list of palindromes</returns>
        public static IEnumerable<string> FindPalindromes(IEnumerable<string> words)
        {
            return Enumerable.Range(1, words.Count())
                            .SelectMany(i => Perms(i, words)
                            .Select(x => x.Aggregate((w, n) => w + n))
                            .Where(x => IsPalindrome(x)));
        }

        /// <summary>
        /// Recursively find all permutations of a list of words
        /// </summary>
        /// <param name="words">The list of words</param>
        /// <param name="length">The number of words to choose from the list</param>
        /// <returns>Enumerable containing the permutations</returns>
        private static IEnumerable<IEnumerable<string>> Perms(int length, IEnumerable<string> words)
        {
            if (length == 1)
            {
                return words.Select(w => new string[] { w });
            }

            return Perms(length - 1, words)
                .SelectMany(w => words
                .Where(e => !w.Contains(e)), (t1, t2) => t1.Concat(new string[] { t2 }));
        }

        /// <summary>
        /// Determines if a word is a palindrome. Case insensitive
        /// </summary>
        /// <param name="word">The word to test</param>
        /// <returns>true is the word is a palindrome, false otherwise</returns>
        private static bool IsPalindrome(string word)
        {
            var reversed = new string(word.Reverse().ToArray());
            return word.Equals(reversed,StringComparison.OrdinalIgnoreCase);
        }
    }
}
