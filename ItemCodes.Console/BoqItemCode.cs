using System;
using System.Collections.Generic;
using System.Text;

namespace ItemCodes.Console
{
    public class BoqItemCode
    {
        public string StringValue { get; private set; }

        private List<BoqItemCodeSection> _sections { get; set; } = new List<BoqItemCodeSection>();

        public static BoqItemCode Parse(string value)
        {
            var itemCode = new BoqItemCode();
            itemCode.StringValue = value;
            string first;
            if (value.Length == 4)
            {
                first = value.Substring(0, 4);
                itemCode._sections.Add(new BoqItemCodeFirstSection { Content = first });
                return itemCode;
            }

            first = value.Substring(0, 7);
            itemCode._sections.Add(new BoqItemCodeFirstSection{Content = first});

            var remaining = value.Substring(7, value.Length - 7).Trim();
            if (remaining.Length == 0)
            {
                return itemCode;
            }

            var parts = remaining.Split('(');
            var second = "(" + parts[1].Replace("(", "").Replace(")", "") + ")";
            itemCode._sections.Add(new BoqItemCodeSecondSection {Content = second});

            foreach (var part in parts[2..])
            {
                var next = "(" + part.Replace("(", "").Replace(")", "") + ")";
                itemCode._sections.Add(new BoqItemCodeSection {Content = next});
            }
            
            return itemCode;
        }


    }
}
