using System;
using System.Text.RegularExpressions;

namespace ItemCodes.Console
{
    public class BoqItemCodeSecondSection : BoqItemCodeSection
    {
        public override double Value
        {
            get
            {
                var total = 0;

                for (var index = 1; index <= _content.Length - 3; index++)
                {
                    total += (int)Math.Pow(26, index) * (_content[index] - 'a' + 1);
                }
                total += _content[^2] - 'a' + 1;

                return total;
            }
        }

        protected override bool IsValid(string value)
        {
            //if (value.Length < 3)
            //{
            //    return false;
            //}

            var regex = new Regex(@"^\([a-z]{1,2}\)$");
            if (!regex.IsMatch(value))
            {
                return false;
            }

            return true;
        }
    }
}