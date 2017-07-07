using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Five Dwarves ( Gimli Fili Ilif Ilmig and Mark) met at the Prancing Pony and played 
 * a word game to determine which combinations of their names resulted in a palindrome.
 * Write a program in that prints out all of those combinations.
 */

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        { 
            IEnumerable<string> palindromes;

            var timer = Stopwatch.StartNew();

            if (args.Count() >= 2)
            {
                palindromes = Palindrome.FindPalindromes(args.ToList());
            }
            else
            {
                palindromes = Palindrome.FindPalindromes(GetNames());
            }

            timer.Stop();

            // Output
            Console.WriteLine("Found {0} palindromes in {1} milliseconds", palindromes.Count(), timer.ElapsedMilliseconds);
            WritePalindromes(palindromes);
            Console.ReadLine();
        }

        private static void WritePalindromes(IEnumerable<string> palindromes)
        {
            foreach(var palindrome in palindromes)
            {
                Console.WriteLine(palindrome);
            }   
        }

        static IList<string> GetNames()
        {
            var names = new List<string>
            {
                "Gimli", "Fili", "Ilif", "Ilmig", "Mark"
            };

            return names;
        }
    }
}
