using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TurnBaseGame
{
    public class Item
    {
        public string itemName;
        public int itemid;

        public Item(string itemName)
        {
            this.itemName = itemName;
            this.itemid = GetHashCode();
        }

        public virtual void Use(string itemname)
        {
            Console.WriteLine($"Using {itemname}");
        }

        public virtual void Function(Charater charater)
        {
        }

        public virtual void Remove(Charater charater)
        {

        }
    }
}
