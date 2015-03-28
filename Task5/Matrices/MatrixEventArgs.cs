using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    public class MatrixEventArgs : EventArgs
    {
        public int i { get; private set; }
        public int j { get; private set; }

        public MatrixEventArgs(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }
}
