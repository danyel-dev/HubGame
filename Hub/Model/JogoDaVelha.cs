
using System;

namespace Hub.Model
{
    public class JogoDaVelha
    {
        public int MatrixOrder { get; set; }
        public string[,] MatrixGame { get; set; }

        public JogoDaVelha(int matrixOrder)
        {
            MatrixOrder = matrixOrder;
            MatrixGame = new string[matrixOrder, matrixOrder];
        }

        public void MainGame()
        {
            FillMatriz();
            Console.WriteLine();

            Console.WriteLine("1 - Player 01 começa com 'X'");
            Console.WriteLine("2 - Player 02 começa com 'X'");
            Console.Write("\nInforme o número da opção: ");

            int option = int.Parse(Console.ReadLine());

            Console.Clear();

            string player1, player2;

            if (option == 1)
            {
                player1 = "X";
                player2 = "O";
            }
            else
            {
                player2 = "X";
                player1 = "O";
            }

            string charactere = " ";

            int flag = 0;

            for (int i = 0; i < MatrixOrder * MatrixOrder; i++)
            {
                Console.WriteLine($"\nPlayer 1 - [{player1}]");
                Console.WriteLine($"Player 2 - [{player2}]\n");
                PrintMatrix();

                Console.WriteLine();

                if (i % 2 == 0)
                {
                    Console.WriteLine("- Vez do player 01");
                    charactere = player1;
                }
                else
                {
                    Console.WriteLine("- Vez do player 02");
                    charactere = player2;
                }

                Console.WriteLine();

                int[] matrixCell = new int[2];

                MatrixPosition(matrixCell);

                int line = matrixCell[0];
                int column = matrixCell[1];

                MatrixGame[line, column] = charactere;

                if (CheckColumn(column, charactere))
                {
                    flag = 1;
                    break;
                }

                if (CheckLine(line, charactere))
                {
                    flag = 1;
                    break;
                }

                else if (line == column)
                {
                    if (CheckMainDiagonal(charactere))
                    {
                        flag = 1;
                        break;
                    }
                }

                else if (line + column == MatrixOrder - 1)
                {
                    if (CheckSecondaryDiagonal(charactere))
                    {
                        flag = 1;
                        break;
                    }
                }

                Console.Clear();
            }

            Console.Clear();

            PrintMatrix();

            if (flag == 0)
                Console.WriteLine("\nEMPATE!!");
            else if (player1 == charactere)
                Console.WriteLine("\nPLAYER 1 GANHOU!!\n");
            else
                Console.WriteLine("\nPLAYER 2 GANHOU!!\n");

            Console.Write("Aperte qualquer tecla para sair... ");
            Console.ReadKey();
        }

        public void FillMatriz()
        {
            int count = 1;

            for (int i = 0; i < MatrixOrder; i++)
            {
                for (int j = 0; j < MatrixOrder; j++)
                {
                    MatrixGame[i, j] = $"{count}";
                    count++;
                }
            }
        }

        public void PrintMatrix()
        {
            int numberOfCharacters = MatrixOrder * 4;
            var charactere = "";

            for (int i = 1; i < numberOfCharacters; i++)
            {
                if (i % 4 == 0)
                    charactere += "+";
                else
                    charactere += "-";
            }

            for (int i = 0; i < MatrixOrder; i++)
            {
                for (int j = 0; j < MatrixOrder; j++)
                {
                    if (MatrixGame[i, j] == "X")
                        Console.ForegroundColor = ConsoleColor.Blue;

                    if (MatrixGame[i, j] == "O")
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($" {MatrixGame[i, j]} ");
                    Console.ResetColor();

                    if (j != MatrixOrder - 1)
                        Console.Write($"|");
                }

                Console.WriteLine();

                if (i != MatrixOrder - 1)
                    Console.WriteLine(charactere);
            }
        }

        public void MatrixPosition(int[] matrixCell)
        {
            Console.Write("Informe o número da posição que deseja jogar: ");
            int pos = int.Parse(Console.ReadLine());

            int line, column;

            if (pos <= MatrixOrder)
            {
                line = 0; column = pos - 1;
            }
            else if (pos == MatrixOrder * MatrixOrder)
            {
                line = MatrixOrder - 1;
                column = MatrixOrder - 1;
            }
            else if (pos % MatrixOrder != 0)
            {
                line = pos / MatrixOrder;
                column = pos % MatrixOrder - 1;
            }
            else
            {
                line = pos / MatrixOrder - 1;
                column = MatrixOrder - 1;
            }

            matrixCell[0] = line;
            matrixCell[1] = column;
        }

        public bool CheckColumn(int column, string charactere)
        {
            int count = 0;

            for (int i = 0; i < MatrixOrder; i++)
            {
                if (MatrixGame[i, column] == charactere)
                    count++;

                if (count == MatrixOrder)
                    return true;
            }

            return false;
        }

        public bool CheckLine(int line, string charactere)
        {
            int count = 0;

            for (int j = 0; j < MatrixOrder; j++)
            {
                if (MatrixGame[line, j] == charactere)
                    count++;

                if (count == MatrixOrder)
                    return true;
            }

            return false;
        }

        public bool CheckMainDiagonal(string charactere)
        {
            int count = 0;

            for (int i = 0; i < MatrixOrder; i++)
            {
                if (MatrixGame[i, i] == charactere)
                    count++;

                if (count == MatrixOrder)
                    return true;
            }

            return false;
        }

        public bool CheckSecondaryDiagonal(string charactere)
        {
            int count = 0;
            int column = MatrixOrder - 1;

            for (int i = 0; i < MatrixOrder; i++)
            {
                if (MatrixGame[i, column] == charactere)
                    count++;

                if (count == MatrixOrder)
                    return true;

                column--;
            }

            return false;
        }
    }
}
