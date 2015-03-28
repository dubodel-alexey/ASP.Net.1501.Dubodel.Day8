using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int order)
            : base(order)
        {

        }

        public override T this[int i, int j]
        {
            get { return base[i, j]; }
            set
            {
                if (i == j)
                    base[i, j] = value;
                else
                {
                    throw new ArgumentException("Can't change not diagonal element. i should be equals j");
                }
            }
        }
    }
}
