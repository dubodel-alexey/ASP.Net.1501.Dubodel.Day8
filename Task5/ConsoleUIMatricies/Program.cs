using System;
using Matrices;

namespace ConsoleUIMatricies
{
    class Program
    {
        static void ElementChanged(object sender, MatrixEventArgs e)
        {
            Console.WriteLine("Value changed in {0} At: [{1},{2}]", sender, e.i, e.j);
        }

        static void Main()
        {
            var symmetricMatrix = new SymmetricMatrix<int>(3);
            var diagonalMatrix = new DiagonalMatrix<int>(3);
            symmetricMatrix.ValueChanged += ElementChanged;
            diagonalMatrix.ValueChanged += ElementChanged;

            symmetricMatrix[1, 1] = 10;
            symmetricMatrix[1, 2] = 20;

            diagonalMatrix[1, 1] = 10;

            Console.ReadKey();
        }
    }
}
