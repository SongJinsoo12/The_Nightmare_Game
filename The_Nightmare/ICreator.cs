using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public interface ICreator
    {
        GameObject Create(int x, int y);
    }
}
