using System;
using System.Collections.Generic;
using System.Text;

namespace ItemCodes.Console
{
    public class ItemCode: IEquatable<ItemCode>
    {
        public List<ItemCodeSection> Parts { get; set; } = new List<ItemCodeSection>();

        public bool Equals(ItemCode other)
        {
            throw new NotImplementedException();
        }
    }
}
