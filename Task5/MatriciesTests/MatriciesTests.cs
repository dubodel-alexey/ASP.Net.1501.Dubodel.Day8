using System;
using Matrices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatriciesTests
{
    [TestClass]
    public class MatriciesTests
    {
        [TestMethod]
        public void AdditionTestMethod()
        {
            var symMatrix = new SymmetricMatrix<int>(3);
            var diagonalMatrix = new DiagonalMatrix<int>(3);
            var expectedMatrix = new[,] { 
            { 1, 1, 2 },
            { 1, 3, 3 }, 
            { 2, 3, 5 } };
            /*
             * 0 1 2
             * 1 2 3
             * 2 3 4
             */
            for (int i = 0; i < symMatrix.Order; i++)
            {
                for (int j = i; j < symMatrix.Order; j++)
                {
                    symMatrix[i, j] = i + j;
                }
            }

            for (int i = 0; i < diagonalMatrix.Order; i++)
            {
                diagonalMatrix[i, i] = 1;
            }

            var actualMatrix = symMatrix.Add(diagonalMatrix, (i, i1) => i + i1);

            bool result = true;
            for (int i = 0; i < symMatrix.Order; i++)
            {
                for (int j = 0; j < symMatrix.Order; j++)
                {
                    if (actualMatrix[i, j] != expectedMatrix[i, j])
                    {
                        result = false;
                        break;
                    }
                }
            }

            Assert.AreEqual(true, result);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AdditionMatriciesWithDifferentOrderTestMethod()
        {
            var symMatrix = new SymmetricMatrix<int>(3);
            var diagonalMatrix = new DiagonalMatrix<int>(4);

            symMatrix.Add(diagonalMatrix, (i, i1) => i + i1);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void AdditionMatriciesWitoutAdditionRulerTestMethod()
        {
            var symMatrix = new SymmetricMatrix<int>(3);
            var diagonalMatrix = new DiagonalMatrix<int>(3);

            symMatrix.Add(diagonalMatrix, null);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ChangeNotDiagonalElementsInDiagonalMatrixTestMethod()
        {
            var diagonalMatrix = new DiagonalMatrix<int>(4);

            diagonalMatrix[1, 2] = 10;
        }

        [TestMethod]
        public void ChangeElementsInSymmetricMatrixTestMethod()
        {
            var symMatrix = new SymmetricMatrix<int>(3);

            symMatrix[1, 2] = 10;

            Assert.AreEqual(symMatrix[1, 2], symMatrix[2, 1]);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void GetElementWithIndexBiggerThanOrderTestMethod()
        {
            var diagonalMatrix = new DiagonalMatrix<int>(4);

            var result = diagonalMatrix[5, 1];
        }
    }
}
