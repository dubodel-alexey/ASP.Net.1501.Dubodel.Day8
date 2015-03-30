using System;
using Matrices.Abstraction;

namespace Matrices
{
    public class SquareMatrix<T> : AbstractSquareMatrix<T>
    {
        protected T[] matrix;

        public SquareMatrix(int order)
        {
            matrix = new T[order * order];
            Order = order;
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i < Order && i >= 0 && j < Order && j >= 0)
                    return matrix[j + i * Order];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (i < Order && i >= 0 && j < Order && j >= 0)
                {
                    matrix[j + i * Order] = value;
                    OnValueChange(new MatrixEventArgs(i, j));
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
