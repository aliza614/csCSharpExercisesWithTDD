using System.Linq;

namespace CSharpExercisesWithTDD
{
    /// <summary>
    /// This class will handle the methods for exercises on this page:
    /// https://www.csharpexercises.com/linq
    /// </summary>
    public static class LinqExercises
    {
        private static char c;
        #region Easy

        /// <summary>
        /// Last Word Containing Letter
        /// Return the last word that contains 'e' after sorting the words alphabetically.
        /// https://www.csharpexercises.com/linq/exercise/last-word-containing-letter
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string LastWordContainingLetter(string[] words)
        {
            //order words
            words=words.OrderBy(word=>word).ToArray();
            //return the first word which contains e
            //LastOrDefault can return null if the search comes up empty
            //other way to do it words.Where(word => word.ToLower().Contains("e")).LastOrDefault();
            return words.LastOrDefault(word => word.ToLower().Contains("e"));
            
        }

        /// <summary>
        /// Minimum Number
        /// Returns words at least 5 characters long and make them uppercase.
        /// https://www.csharpexercises.com/linq/exercise/minimum-length
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string[] MinimumLength(string[] words)
        {
            return words.Where(word=>word.Length>=5).Select(word=>word.ToUpper()).ToArray();
        }

        /// <summary>
        /// Numbers from range
        /// Return all numbers greater than thirty and less than 100
        /// https://www.csharpexercises.com/linq/exercise/numbers-from-range
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static List<int> NumbersFromRange(int[] numbers)
        {
            return numbers.Where(n=>n>30&&n<100).ToList();
        }

        /// <summary>
        /// Replace Substring
        /// Replaces 'ea' substring with astersik (*) in given list of words.
        /// https://www.csharpexercises.com/linq/exercise/replace-substring
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string[] ReplaceSubstring(string[] words)
        {
            return words.Select(word => word.Replace("ea", "*")).ToArray();
        }

        /// <summary>
        /// Select Words
        /// Returns words starting with letter 'a' and ending with letter 'm'.
        /// https://www.csharpexercises.com/linq/exercise/select-words
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string[] SelectWords(string[] words)
        {
            return words.Where(word => word[0] == 'a' && word[^1]=='m').ToArray();
        }

        /// <summary>
        /// Square Greater Than Twenty
        /// Return numbers and their squares only if square is greater than 20
        /// https://www.csharpexercises.com/linq/exercise/square-greater-than-20
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string[] SquareGreaterThanTwenty(int[] numbers)
        {
            return numbers.Where(n => Math.Pow(n, 2) > 20).Select(n=>$"{n} - {Math.Pow(n,2)}").ToArray();
        }

        /// <summary>
        /// Top Five Numbers
        /// Returns top 5 numbers from the list of integers in descending order.
        /// https://www.csharpexercises.com/linq/exercise/top-5-numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static int[] TopFiveNumbers(int[] numbers)
        {
            return numbers.OrderByDescending(n => n).Take(5).ToArray();
        }

        #endregion Easy

        #region Medium

        /// <summary>
        /// Decrypt Number
        /// Given a non-empty string consisting only of special chars (!, @, # etc.),
        /// return a number (as a string) where each digit corresponds to given
        /// special char on the keyboard ( 1→ !, 2 → @, 3 → # etc.).
        /// https://www.csharpexercises.com/linq/exercise/decrypt-number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string DecryptNumber(string input)
        {
            return input.Select(c => {
                return c switch
                {
                    '@' => '2',
                    '#' => '3',
                    '$' => '4',
                    '%' => '5',
                    '^' => '6',
                    '&' => '7',
                    '*' => '8',
                    '(' => '9',
                    ')' => '0',
                    _ => '1',
                };
            }
            ).ToString()??"";
        }

        /// <summary>
        /// Frequency of Letters
        /// returns letters and their frequencies in the string.
        /// https://www.csharpexercises.com/linq/exercise/frequency-of-letters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string FrequencyOfLetters(string input)
        {
            return String.Join(",", input.Select(c => $"Letter {c} occurs {input.Where(c1=>c==c1).Count()} time(s)"));
         }

        /// <summary>
        /// Most Frequent Character
        /// Returns most frequent character in string. Assume that there is only one such character.
        /// https://www.csharpexercises.com/linq/exercise/most-frequent-character
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static char MostFrequentCharacter(string input)
        {
            //input="hello";
            
            //get the count of each character then return the character where the count is max 
            //first write code to get the max
            //Inprogress
            //OLD return input.Where(/* gets the count*/c => input.Where(c1=>c1==c).Count()/*end gets the count*/==/*gets the max count*/input.Select(c2 => input.Where(c1 => c1 == c2).Count()).ToArray().Max()/*end get max count*/).ToString().Single();
            //v2 Dictionary<char, int> charAndFreq = new Dictionary<char, int>();
            //v2 foreach ((char, int) tuple in (input.Select(c => (c, input.Where(c1 => c1 == c).Count()))))
            //v2    charAndFreq.Add(tuple.Item1,tuple.Item2);
            //(char[],int[])input.Select(c => (c, input.Where(c1 => c1 == c).Count())).ToArray();
            var e=((char,int)[])(input.Select(c => (c, input.Where(x => x == c).Count())).ToArray());
            var max = e.Where((c/*this is the element*/, i/*this is the index*/) => c.Item2 == e.Select((c, i) => c.Item2).Max());
            return max.Select((c, i) => c.Item1).First();
           
        }

        /// <summary>
        /// Shuffle An Array
        /// Write a query that shuffles sorted array.
        /// https://www.csharpexercises.com/linq/exercise/shuffle-an-array
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static int[] ShuffleAnArray(int[] input)
        {
            var random = new Random();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unique Values
        /// Return an array that contains only unique (non-duplicate) strings.
        /// https://www.csharpexercises.com/linq/exercise/unique-values
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string[] UniqueValues(string[] input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Uppercase Only
        /// Returns only uppercase words from string.
        /// https://www.csharpexercises.com/linq/exercise/uppercase-only
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string[] UppercaseOnly(string input)
        {
            throw new NotImplementedException();
        }

        #endregion Medium

        #region Hard

        /// <summary>
        /// Days Names
        /// Using Enum.GetValues() - Return days of the week in a string array
        /// https://www.csharpexercises.com/linq/exercise/days-names
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static string DaysNames()
        {
            throw new NotImplementedException();
        }

        #endregion Hard
    }
}