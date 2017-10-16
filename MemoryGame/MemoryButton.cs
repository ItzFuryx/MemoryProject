using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public enum MemoryType
    {
        Harro = 0,
        Bart = 1,
        Kevin = 2,
        Pim = 3,
        Keanu = 4,
        Casper = 5,
        StarWars = 6,
        DieEneGozer = 7
    }

    class MemoryButton
    {
        internal Button Button = null;
        internal MemoryType Type;
        internal bool Succes = false;
    }
}
