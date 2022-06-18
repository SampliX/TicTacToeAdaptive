using System;

namespace TicTacToeAdaptive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Кастомизация игры
            int poleSize = 3;
            int rowSize = 3;

            int player = 1;
            string symbol = "X";
            int tmp;

            string[,] pole = new string[poleSize, poleSize];

            while (true)
            {
                Console.WriteLine("\n" + $"Ход {player}-ого игрока. Выберите ячейку:");
                tmp = int.Parse(Console.ReadLine()) - 1;
                if (tmp >= 0 && tmp <= 8 && pole[tmp / 3, tmp % 3] == null)
                {
                    if (player == 1)
                        symbol = "X";
                    else
                        symbol = "0";

                    pole[tmp / 3, tmp % 3] = symbol;

                    WritePole(pole);

                    if (CheckTheRows(pole, rowSize) || CheckTheDiagonals(pole, rowSize))
                    {
                        Console.WriteLine(player + "-ый игрок победил!");
                        break;
                    }

                    if (player == 1)
                        player = 2;
                    else if (player == 2)
                        player = 1;
                }
            }
        }

        static void WritePole(string[,] pole)
        {
            Console.Clear();
            for (int x = 0; x < pole.GetLength(0); x++)
            {
                for (int y = 0; y < pole.GetLength(1); y++)
                {
                    if (pole[x,y] != null)
                        Console.Write(" " + pole[x,y]);
                    else
                        Console.Write(" " + " ");
                }
                Console.WriteLine();
            }
        }

        static bool CheckTheRows(string[,] pole, int rowSize)
        {
            bool isWin = false;
            int RowElemIter = 1;
            int ColumnElemIter = 1;

            for (int x = 0; x < pole.GetLength(0) && !isWin; x++)
            {
                for (int y = 0; y < pole.GetLength(1) - 1 && !isWin; y++)
                {
                    if (pole[x,y] != null && pole[x,y] == pole[x, y + 1])
                    {
                        RowElemIter++;
                    }
                    else if(pole[x, y] != null)
                    {
                        RowElemIter = 1;
                    }

                    if (pole[y, x] != null && pole[y, x] == pole[y + 1, x])
                    {
                        ColumnElemIter++;
                    }
                    else if (pole[y, x] != null)
                    {
                        ColumnElemIter = 1;
                    }

                    if (RowElemIter == rowSize || ColumnElemIter == rowSize)
                        isWin = true;
                }
            }

            return isWin;
        }

        static bool CheckTheDiagonals(string[,] pole, int rowSize)
        {
            bool isWin = false;
            int DiagonalElemIter = 1;

            for (int x = 0; x < pole.GetLength(0) && !isWin; x++)
            {
                for (int y = 0; y < pole.GetLength(1) && !isWin; y++)
                {
                    if(pole.GetLength(0) - x >= rowSize && pole.GetLength(0) - y >= rowSize)
                    {
                        for(int i = 1; i < rowSize; i++)
                        {
                            if (pole[x, y] != null && pole[x, y] == pole[x + i, y + i])
                            {
                                DiagonalElemIter++;
                            }
                            else if (pole[x, y] != null)
                            {
                                DiagonalElemIter = 1;
                                break;
                            }
                        }
                    }
                    
                    if(pole.GetLength(0) - x >= rowSize && y - (rowSize - 1) >= 0)
                    {
                        for (int i = 1; i < rowSize; i++)
                        {
                            if (pole[y, x] != null && pole[y, x] == pole[y - i, x + i])
                            {
                                DiagonalElemIter++;
                            }
                            else if (pole[y, x] != null)
                            {
                                DiagonalElemIter = 1;
                                break;
                            }
                        }
                    }

                    if (DiagonalElemIter == rowSize)
                        isWin = true;
                }
            }

            return isWin;
        }
    }
}
