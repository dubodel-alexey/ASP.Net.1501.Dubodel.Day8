﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTests
{
    class IntCustomComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y) return -1;
            if (x < y) return 1;
            return 0;
        }
    }
}
