using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Algorithms.TakeYouForward
{
    public static partial class TakeUForward
    {
        public static class Strings
        {
            // https://leetcode.com/problems/sort-characters-by-frequency/
            public static string FrequencySort(string s)
            {
                var concatenatedValues = string.Empty;

                //var groupedAndOrdered = s
                //    .GroupBy(x => x)
                //    .OrderByDescending(x => x.Count());

                //foreach (var group in groupedAndOrdered)
                //{
                //    foreach (var value in group)
                //    {
                //        concatenatedValues += value;
                //    }
                //}

                concatenatedValues = string.Concat(s
                        .GroupBy(@char => @char)
                        .OrderByDescending(@char => @char.Count())
                        .SelectMany(groupItem => groupItem)
                );

                return concatenatedValues;
            }

            //Maximum Nesting Depth of the Parentheses
            public static int MaxDepth(string s)
            {
                if (string.IsNullOrEmpty(s)) return 0;

                var results = new HashSet<int>();
                int openBracketCount = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '(') openBracketCount++;
                    if (s[i] == ')') openBracketCount--;
                    results.Add(openBracketCount);
                }

                return results.Max();
            }

            public static int MaxDepthAggregate(string s)
            {
                if (string.IsNullOrEmpty(s)) return 0;
                var results = new HashSet<int>();

                s.Aggregate(0, (acc, currentChar) =>
                {
                    if (currentChar == '(') acc++;
                    if (currentChar == ')') acc--;
                    results.Add(acc);
                    return acc;
                });
                return results.Max();
            }

            public static int RomanToInt(string s)
            {
                if (string.IsNullOrEmpty(s)) return 0;
                if (s.Length > 15) return -1;

                var romanNumbersDict = new Dictionary<string, int>()
                {
                    {"I", 1},
                    {"V", 5},
                    {"X", 10},
                    {"L", 50},
                    {"C", 100},
                    {"D", 500},
                    {"M", 1000},
                    {"IV", 4},
                    {"IX", 9},
                    {"XL", 40},
                    {"XC", 90},
                    {"CD", 400},
                    {"CM", 900},
                };

                int result = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if ((s[i] == 'I' || s[i] == 'X' || s[i] == 'C') && i < s.Length - 1)
                    {
                        var tmp = string.Concat("", s[i], s[i + 1]);
                        if (romanNumbersDict.ContainsKey(tmp))
                        {
                            result += romanNumbersDict[tmp];
                            i++;
                            continue;
                        }
                    }

                    result += romanNumbersDict[s[i].ToString()];
                }

                return result;
            }
        }
    }


}
