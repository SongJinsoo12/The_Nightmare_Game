using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public enum ItemType
    {
        None,
        Sword,
        Shield,
        Potion
    }
    public class Item
    {
        public ItemType Type { get; set; } = ItemType.None;

        public string Name { get; set; }
        public string Description { get; set; }

        public Item()
        {

        }
    }
}
