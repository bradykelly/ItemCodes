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
            var first = value.Substring(0, 7);
            itemCode._sections.Add(new BoqItemCodeFirstSection{Content = first});
            
            var parts = value.Substring(7, value.Length - 7).Split('(');
            var second = "(" + parts[1].Replace("(", "").Replace(")", "") + ")";
            itemCode._sections.Add(new BoqItemCodeSecondSection {Content = second});

            foreach (var part in parts[2..])
            {
                var next = "(" + part.Replace("(", "").Replace(")", "") + ")";
                itemCode._sections.Add(new BoqItemCodeSection {Content = next});
            }
            itemCode.StringValue = value;

            return itemCode;
        }


    }
}
