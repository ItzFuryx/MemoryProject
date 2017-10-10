using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;

namespace Memory
{
    public enum MemoryType
    {
        Harro = 0,
        Bart = 1,
        Kevin = 2,
        Pim = 3,
        Keanu = 4,
        Casper = 5,
        hoi = 6,
        fghh = 7,
        asldkfj = 8
    }

    class MemoryButton
    {
        internal Button Button= null;
        internal MemoryType Type;

    }
}
