using System;
using System.Collections.Generic;
using System.Text;

namespace _8QueenPuzzle
{
    public class Chessboard
    {
        static readonly int QUEENS = 8;
        private int[] _queenPositions = new int[QUEENS];
        private int _solutionCount = 0;

        public void GetResult()
        {
            Check(0);
        }

        private void Check(int n)
        {
            if (n == QUEENS)
            {
                Print();
                return;
            }

            for (int i = 0; i < QUEENS; i++)
            {
                _queenPositions[n] = i;

                if (IsConflict(n))
                {
                    continue;
                }

                Check(n + 1);
            }
        }

        private bool IsConflict(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (_queenPositions[i] == _queenPositions[n] ||
                    Math.Abs(n - i) == Math.Abs(_queenPositions[n] - _queenPositions[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private void Print()
        {
            _solutionCount++;

            Console.WriteLine($"// Solution {_solutionCount}");

            for (int i = 0; i < QUEENS; i++)
            {

                for (int j = 0; j < QUEENS; j++)
                {
                    var grid = _queenPositions[i] == j ? 'Q' : '.';
                    Console.Write($"{grid}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
