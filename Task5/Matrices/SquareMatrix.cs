using System;

namespace Matrices
{
    public class SquareMatrix<T>
    {
        protected T[,] matrix;
        public int Order { get; protected set; }

        public event EventHandler<MatrixEventArgs> ValueChanged = delegate { };

        public SquareMatrix(int order)
        {
            matrix = new T[order, order];
            Order = order;
        }

        private void OnValueChange(MatrixEventArgs e)
        {
            ValueChanged(this, e);
        }

        public virtual T this[int i, int j]
        {
            get
            {
                if (i < Order && i >= 0 && j < Order && j >= 0)
                    return matrix[i, j];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (i < Order && i >= 0 && j < Order && j >= 0)
                {
                    matrix[i, j] = value;
                    OnValueChange(new MatrixEventArgs(i, j));
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
