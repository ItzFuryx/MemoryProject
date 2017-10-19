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
        internal System.Drawing.Image Image;

        public void SetCardType(MemoryType type)
        {
            Type = type;
            switch (Type)
            {
                case MemoryType.Bart:
                    Image = Properties.Resources.KA;
                    break;
                case MemoryType.Casper:
                    Image = Properties.Resources.KJ;
                    break;
                case MemoryType.DieEneGozer:
                    Image = Properties.Resources.KQ;
                    break;
                case MemoryType.Harro:
                    Image = Properties.Resources.KK;
                    break;
                case MemoryType.Keanu:
                    Image = Properties.Resources.SA;
                    break;
                case MemoryType.Kevin:
                    Image = Properties.Resources.SJ;
                    break;
                case MemoryType.Pim:
                   Image = Properties.Resources.SQ;
                    break;
                case MemoryType.StarWars:
                    Image = Properties.Resources.SK;
                    break;
            }
        }
    }
}
