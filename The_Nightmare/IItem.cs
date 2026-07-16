using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    internal interface IItem
    {
        string Name { get; }
        string Description { get; }
        void Use(Player player);
    }
}
