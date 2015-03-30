using System;
using Matrices.Abstraction;

namespace Matrices
{
    public class SymmetricMatrix<T> : AbstractSquareMatrix<T>
    {
        protected T[] matrix;

        public SymmetricMatrix(int order)
        {
            Order = order;
            matrix = new T[(order + 1) * order / 2];  //sum(1,2,...,n) = n*(n+1) /2
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i < Order && i >= 0 && j < Order && j >= 0)
                {
                    int currI = (i > j) ? j : i;
                    int currJ = (i > j) ? i : j;

                    int rowIndex = (2 * Order - currI + 1) * currI / 2;
                    int colIndex = currJ - currI;
                    return matrix[rowIndex + colIndex];
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (i < Order && i >= 0 && j < Order && j >= 0)
                {
                    int currI = (i > j) ? j : i;
                    int currJ = (i > j) ? i : j;

                    int rowIndex = (2 * Order - currI + 1) * currI / 2;
                    int colIndex = currJ - currI;

                    matrix[rowIndex + colIndex] = value;
                    OnValueChange(new MatrixEventArgs(i, j));
                    OnValueChange(new MatrixEventArgs(j, i));
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
