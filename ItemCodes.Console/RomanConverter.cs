using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemCodes.Console
{
    class RomanConverter
    {
        private static readonly Dictionary<char, int> RomanNumerals = new Dictionary<char, int>() {
            {'M', 1000}, {'D', 500}, {'C', 100}, {'L', 50}, {'X', 10}, {'x', 10}, {'V', 5}, {'v', 5}, {'I', 1}, {'i', 1}
        };

        public static int RomanToInt(string value)
        {
            if (null == value)
                throw new ArgumentNullException(nameof(value));
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Empty or WS only value is not allowed.", nameof(value));

            int v;

            int[] values = value
                .Select(c => RomanNumerals.TryGetValue(c, out v) ? v : -1)
                .ToArray();

            int result = 0;
            int current = 1000;
            int count = 0;

            for (int i = 0; i < values.Length; ++i)
            {
                v = values[i];

                if (v < 0)
                    throw new FormatException($"Invalid symbol {value[i]} at {i + 1}");
                else if (v > current)
                    throw new FormatException($"Invalid symbol {value[i]}");
                else if (current == v)
                {
                    count += 1;

                    if (count > 1 && (v == 5 || v == 50 || v == 500))
                        throw new FormatException($"Invalid symbol {value[i]} at {i + 1}");
                    else if (count > 3 && current != 1000)
                        throw new FormatException($"Invalid symbol {value[i]} at {i + 1}");
                }
                else
                {
                    count = 1;
                    current = v;
                }

                if (i < value.Length - 1)
                    if (v == 1 || v == 10 || v == 100)
                        if (v * 5 == values[i + 1] || v * 10 == values[i + 1])
                        {
                            v = values[i + 1] - v;
                            count = 3;

                            i += 1;
                        }

                result += v;
            }

            return result;
        }
    }
}
