using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ItemCodes.Console
{
    public class ItemCodeSection
    {
        private static string _validChars = "xvi";

        private string _content;
        public string Content
        {
            get => _content;
            set
            {
                if (IsValid(value))
                {
                    _content = value;
                }
                else
                {
                    throw new ArgumentException($"Section value '{value}' is not valid");
                }
            }
        }

        public int Value { get; private set; }

        public virtual bool IsValid(string value)
        {
            // From https://stackoverflow.com/a/39561639/8741
            var regex = new Regex(@"\b\(x{0,3}(ix|iv|v?i{0,3})\)\b");

            return regex.IsMatch(value.Substring(1, value.Length - 2));
        }
    }
}