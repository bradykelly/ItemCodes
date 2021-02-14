using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ItemCodes.Console
{
    public class BoqItemCodeSection
    {
        protected string _content;
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

        public virtual double Value => RomanConverter.RomanToInt(_content.Substring(1, _content.Length - 2));

        protected virtual bool IsValid(string value)
        {
            // From https://stackoverflow.com/a/39561639/8741
            var regex = new Regex(@"^\(x{0,3}(ix|iv|v?i{0,3})\)$");

            return regex.IsMatch(value);
        }
    }
}