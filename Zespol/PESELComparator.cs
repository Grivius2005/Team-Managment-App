using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zespol
{
    class PESELComparator:IComparer<CzlonekZespolu>
    {
        public int Compare(CzlonekZespolu x, CzlonekZespolu y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }

            return x.pesel.CompareTo(y.pesel);
        }

    }
}
