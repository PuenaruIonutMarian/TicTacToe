using System;

namespace TicTacToe
{
    internal class Program
    {
        static char[,] board = new char[3, 3];
        static char currentPlayer = 'X';
        static int playerXScore = 0;
        static int playerOScore = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");

            bool playAgain = true;

            while (playAgain)
            {
                InitializeBoard();

                bool gameWon = false;
                int moves = 0;

                while (!gameWon && moves < 9)
                {
                    DrawBoard();
                    int position = GetPlayerMove();
                    int row = (position - 1) / 3;
                    int col = (position - 1) % 3;

                    if (board[row, col] == '\0')
                    {
                        board[row, col] = currentPlayer;
                        moves++;

                        if (CheckWin(row, col))
                        {
                            gameWon = true;
                            UpdateScore();
                        }
                        else
                        {
                            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Please try again.");
                    }
                }

                DrawBoard();

                if (gameWon)
                {
                    Console.WriteLine("Player " + currentPlayer + " wins!");
                }
                else
                {
                    Console.WriteLine("It's a draw!");
                }

                Console.WriteLine("Score: Player X - " + playerXScore + " | Player O - " + playerOScore);
                Console.Write("Do you want to play again? (yes/no): ");
                string playAgainInput = Console.ReadLine().ToLower();

                while (playAgainInput != "yes" && playAgainInput != "no")
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                    Console.Write("Do you want to play again? (yes/no): ");
                    playAgainInput = Console.ReadLine().ToLower();
                }

                playAgain = (playAgainInput == "yes");
                currentPlayer = 'X';
            }

            Console.WriteLine("Thank you for playing Tic Tac Toe!");
            Console.ReadLine();
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '\0';
                }
            }
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine(" 1 | 2 | 3 ");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" 4 | 5 | 6 ");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" 7 | 8 | 9 ");
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '\0')
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        Console.Write(" " + board[i, j] + " ");
                    }

                    if (j < 2)
                    {
                        Console.Write("|");
                    }
                }

                Console.WriteLine();

                if (i < 2)
                {
                    Console.WriteLine("---+---+---");
                }
            }

            Console.WriteLine();
        }

        static int GetPlayerMove()
        {
            Console.Write("Player " + currentPlayer + ", enter your move (1-9): ");
            string input = Console.ReadLine();
            int position;

            while (!int.TryParse(input, out position) || position < 1 || position > 9)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                Console.Write("Player " + currentPlayer + ", enter your move (1-9): ");
                input = Console.ReadLine();
            }

            return position;
        }

        static bool CheckWin(int row, int col)
        {
            // Check row
            if (board[row, 0] == currentPlayer && board[row, 1] == currentPlayer && board[row, 2] == currentPlayer)
                return true;

            // Check column
            if (board[0, col] == currentPlayer && board[1, col] == currentPlayer && board[2, col] == currentPlayer)
                return true;

            // Check diagonal
            if ((row == col && board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (row + col == 2 && board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
                return true;

            return false;
        }

        static void UpdateScore()
        {
            if (currentPlayer == 'X')
                playerXScore++;
            else
                playerOScore++;
        }
    }
}
