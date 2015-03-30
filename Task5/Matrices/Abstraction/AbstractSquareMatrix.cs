using System;

namespace Matrices.Abstraction
{
    public abstract class AbstractSquareMatrix<T>
    {
        public int Order { get; protected set; }

        public event EventHandler<MatrixEventArgs> ValueChanged = delegate { };

        protected virtual void OnValueChange(MatrixEventArgs e)
        {
            ValueChanged(this, e);
        }

        public abstract T this[int i, int j] { get; set; }
    
    }
}
