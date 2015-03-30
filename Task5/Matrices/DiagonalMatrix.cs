using System;
using Matrices.Abstraction;

namespace Matrices
{
    public class DiagonalMatrix<T> : AbstractSquareMatrix<T>
    {
        protected T[] matrix;

        public DiagonalMatrix(int order)
        {
            Order = order;
            matrix = new T[order];
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i < Order && i >= 0 && j < Order && j >= 0)
                {
                    return (i == j) ? matrix[i] : default(T);
                }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (i < Order && i >= 0 && j < Order && j >= 0)
                {
                    if (i == j)
                    {
                        matrix[i] = value;
                        OnValueChange(new MatrixEventArgs(i, j));
                    }
                    else
                        throw new ArgumentException("Can't change not diagonal element. i should be equals j");
                }
                else
                    throw new ArgumentOutOfRangeException("i");
            }
        }
    }
}
