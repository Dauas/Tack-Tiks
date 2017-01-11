using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tack_Tic
{
    class TurnHandler
    {
        new String input;
        new String boardread;
        new String storage;
        new int winningteam;
        new Boolean running;
        new int[] board = new int[9];
        Random random = new Random();

        public void Run()
        {
            Console.WriteLine("Type \"help\" if you don't know how to play.");
            boardread = "* * * \n* * * \n* * *";
            for (int i = 0; i < 9; i++)
            {
                board[i] = 0;
            }
            PrintBoard();
            running = true;
            while (running)
            {
                Console.WriteLine("Your turn");
                Interpret();
                PrintBoard();
                WinCheck();
                Console.WriteLine("Opponent's turn");
                AIturn();
                PrintBoard();
                WinCheck();
            }
        }

        public void newgame()
        {
            Run();
            winningteam = 0;
        }

        public void Interpret()
        {
            int selection = 0;
            input = Console.ReadLine().ToLower();
            if (input == "help"){
                Console.WriteLine("Each space on the tic-tac-toe grid corresponds to a number\n\n7 8 9\n4 5 6\n1 2 3\n\n Simply type the number that you wish to place your \'X\'");
                Interpret();
            }
            else if (Int32.TryParse(input, out selection) & selection<10 & selection>0)
            {
                selection = selection-1;
                if(board[selection]==0)
                {
                    ModifyBoard(1, selection);
                }
                else
                {
                    Console.WriteLine("Invalid Tile, Please choose a tile that has not been selected yet.");
                    Interpret();
                }
            }
            else
            {
                Console.WriteLine("Invalid command, type \"help\" if you need instructions.");
                Interpret();
            }
        }
        public void ModifyBoard(int turn, int i)
        {
            board[i] = turn;
        }
        public void AIturn()
        {
            int aichoice = random.Next(0, 8);
            if (board[aichoice] == 0)
            {
                ModifyBoard(2, aichoice);
            }
            else
            {
                AIturn();
            }
        }
        public void WinCheck()
        {
            int checkstore = WinCondition();
            if (checkstore == 1)
            {
                Console.WriteLine("Player Wins");
                running = false;
                End();
            }
            else if (checkstore == 2)
            {
                Console.WriteLine("Computer Wins");
                running = false;
                End();
            }
        }
        public int WinCondition()
        {
            if (((board[0] == board[1] & board[0] == board[2]) || (board[0] == board[3] & board[0] == board[6])) & (board[0] != 0))
            {
                winningteam = board[0];
            }
            else if (((board[8] == board[6] & board[8] == board[7]) || (board[8] == board[2] & board[8] == board[5])) & (board[8] != 0))
            {
                winningteam = board[8];
            }
            else if (((board[4] == board[1] & board[4] == board[7]) || (board[4] == board[3] & board[4] == board[5]) || 
                      (board[4] == board[0] & board[4] == board[8]) || (board[4] == board[2] & board[4] == board[6])) & (board[4] != 0))
            {
                winningteam = board[4];
            }
            else { winningteam = 0; }
            return winningteam;
        }

        public void PrintBoard()
        {
            boardread = "";
            for (int k = 0; k < 3; k++) {
                storage = "";
                for (int i = k * 3; i < (k * 3) + 3; i++)
                {
                    if (board[i] == 0)
                    {
                        storage = storage + "* ";
                    }
                    else if (board[i] == 1)
                    {
                        storage = storage + "X ";
                    }
                    else if (board[i] == 2)
                    {
                        storage = storage + "O ";
                    }
                    if (i == 8 || i == 5)
                    {
                        storage = storage + "\n";
                    }
                }
                boardread = storage + boardread;
            }
            Console.WriteLine("______");
            Console.WriteLine(boardread);
            Console.WriteLine("______");
        }

        public void End()
        {
            Console.Write("\nWould you like to play again? y/n\n>");
            String replayinput = Console.ReadLine();
            if (replayinput.ToLower() == "y")
            {
                newgame();
            }
            if (replayinput.ToLower() == "n")
            {
                System.Environment.Exit(1);
            }
            else
            {
                Console.Write("Invalid Input");
                End();
            }
        }
    }
}
