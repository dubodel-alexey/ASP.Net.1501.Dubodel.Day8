using System;

namespace Matrices
{
    public static class Extensions
    {
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix,
            Func<T, T, T> elementsAddition)
        {
            if (firstMatrix == null)
                throw new ArgumentNullException("firstMatrix");

            if (secondMatrix == null)
                throw new ArgumentNullException("secondMatrix");

            if (firstMatrix.Order != secondMatrix.Order)
                throw new ArgumentException("Can't add square matricies with different order.");

            if (elementsAddition == null)
                throw new ArgumentNullException("elementsAddition");

            var result = new SquareMatrix<T>(firstMatrix.Order);
            for (int i = 0; i < firstMatrix.Order; i++)
            {
                for (int j = 0; j < secondMatrix.Order; j++)
                {
                    result[i, j] = elementsAddition(firstMatrix[i, j], secondMatrix[i, j]);
                }
            }

            return result;
        }
    }
}
