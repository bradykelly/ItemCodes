using System;
using System.Collections.Generic;
using System.Text;

namespace ItemCodes.Console
{
    public class BoqItemCode
    {
        public string StringValue { get; set; }

        private List<BoqItemCodeSection> _parts { get; set; } = new List<BoqItemCodeSection>();

        public static BoqItemCode Parse(string value)
        {
            var itemCode = new BoqItemCode();
            var first = value.Substring(0, 6);
            itemCode._parts.Add(new BoqItemCodeFirstSection{Content = first});

            var parts = value.Substring(6, value.Length - 6).Split('(');
            foreach (var part in parts)
            {
                var content = "(" + part.Replace("(", "").Replace(")", "") + ")";
                itemCode._parts.Add(new BoqItemCodeSection {Content = content});
            }

            return itemCode;
        }


    }
}
