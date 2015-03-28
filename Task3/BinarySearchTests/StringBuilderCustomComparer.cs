using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTests
{
    class StringBuilderCustomComparer : Comparer<StringBuilder>
    {
        public override int Compare(StringBuilder x, StringBuilder y)
        {
            return 1;
        }
    }
}
