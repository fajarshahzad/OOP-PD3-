using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using System.Threading;
using tsk6_game_;
using System.Runtime.InteropServices;

namespace tsk6_game_
{
    class Player
    {
        public char player;
        public int pX;
        public int pY;
        public Player(char symbol,int pX,int pY)
        {
            this.player = symbol;
            this.pX = pX;
            this.pY = pY;
        }
        public void Move_Horizontally(string direction,int maze_width)
        {
            if (direction == "left" && pX > 1)//move left
            {
                pX = pX - 1;
            }
            else if(direction=="right"&&pX<maze_width)//move right
            {
                pX = pX + 1;
            }
                Thread.Sleep(100); 
        }
        public void move_Vertically(ref string direction,int maze_height)
        {
            if(direction=="up"&&pY>1)
            {
                pY = pY - 1;
            }
            else if(direction=="down"&&pY<maze_height)
            {
                pY = pY + 1;
            }
            // reversing the direction with wall detection 
            else if(pY==maze_height)
            {
                direction = "up";
                pY = pY - 1;
            }
            // reversing the dirction
            else if(pY==1)
            {
                direction = "down";
                pY = pY + 1;
            }
            Thread.Sleep(200);
        }
        public void remove()
        {
            Console.SetCursorPosition(pX,pY);
            Console.Write(" ");
        }
        public void Display()
        {
            Console.SetCursorPosition(pX,pY);
            Console.Write(player);
        }
    }
}
    internal class Program
    {
    static void Main(string[] args)
    {
        int option = 0;
        int maze_width = 20;
        int maze_height = 18;
        int enemies_count = 3;
        Player players = new Player('P', 27, 27);
        Player[] enemies = new Player[enemies_count];//enemies are stored in the array
        enemies[0] = new Player('E', 15, 15);
        enemies[1] = new Player('X', 20, 20);
        enemies[2] = new Player('Y', 25, 25);
        string Pmovement = "down";
        string Emovement = "down";
        name();
        while (option!=3)
            {
                Console.Clear();
                name();
                option = DisplayMenu();
                if(option==2)
                {
                    Console.Clear();
                    PrintBoard();
                    name();
                    players.Display();
                for(int i=0;i<enemies_count;i++)
                {
                    enemies[i].Display();
                }
                    while (true)
                    {
                        if(Keyboard.IsKeyPressed(Key.LeftArrow))
                    {
                        players.remove();
                        players.Move_Horizontally("left", maze_width);
                        players.Display();
                    }
                     if(Keyboard.IsKeyPressed(Key.RightArrow))
                    {
                        players.remove();
                        players.Move_Horizontally("right", maze_width);
                        players.Display();
                    }
                     if(Keyboard.IsKeyPressed(Key.UpArrow))
                    {
                        players.remove();
                        Pmovement = "up";
                        players.move_Vertically(ref Pmovement, maze_height);
                        players.Display();
                    }
                     if(Keyboard.IsKeyPressed(Key.DownArrow))
                    {
                        players.remove();
                        Pmovement = "down";
                        players.move_Vertically(ref Pmovement, maze_height);
                        players.Display();
                    }
                     //enemies movement
                     for(int i=0;i<enemies_count;i++)
                    {
                        enemies[i].remove();
                        enemies[i].move_Vertically(ref Emovement, maze_height);
                        enemies[i].Display();
                    }
                     if(Keyboard.IsKeyPressed(Key.Escape))
                    {
                        break;
                    }
                    Thread.Sleep(100);
                    }
                }
                if(option==1)
                {
                    Console.Clear();
                    name();
                    Console.WriteLine(" 1. Press Left Arrow Key <- to move Left the Spaceship");
                    Console.WriteLine();
                    Console.WriteLine(" 2. Press Right Arrow Key -> to move Right the Spaceship");
                    Console.WriteLine();
                    Console.WriteLine(" 3. Press Up Arrow Key -> to move Up the Spaceship");
                    Console.WriteLine();
                    Console.WriteLine(" 4. Press Down Arrow Key -> to move Down the Spaceship");
                    Console.WriteLine();
                    //Console.WriteLine(" 3. Press M key to Fire");
                    // Console.WriteLine();
                    //Console.WriteLine(" 4. Keep Spaceship Away From The Enemies and their Fire");
                    //Console.WriteLine();
                    //Console.WriteLine(" 5. Save your lives otherwise you'll lose:(");
                    //  Console.WriteLine();
                     Console.WriteLine(" 5. Press ESC key to End the Game");
                     Console.WriteLine();
                    Console.ReadKey();
                }
                if(option==3)
                {
                    Console.Clear();
                    name();
                    thanks();
                    Console.ReadKey();
                }
            }
            
        }
        static void PrintBoard()
        {
            Console.WriteLine("####################################################################################");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("#                                                                                  #");
            Console.WriteLine("####################################################################################");

        }
        static void name()
        {
            Console.WriteLine("  ___      _                 _     _     \r\n / _ \\    | |               (_)   | |    \r\n/ /_\\ \\___| |_ ___ _ __ ___  _  __| |___ \r\n|  _  / __| __/ _ \\ '__/ _ \\| |/ _` / __|\r\n| | | \\__ \\ ||  __/ | | (_) | | (_| \\__ \\\r\n\\_| |_/___/\\__\\___|_|  \\___/|_|\\__,_|___/\r\n                                         \r\n                                         ");
        }
        static int DisplayMenu()
        {
            Console.WriteLine("1.Instructions for the Game>");
            Console.WriteLine("2.Lets Begin the Game>>>>>>>");
            Console.WriteLine("3.Exit>>>>>>>>>>>>>>>>>>>>>>");
        again:
            Console.WriteLine("Enter the option: ");
            int option = int.Parse(Console.ReadLine());
            if(option<1||option>3)
            {
                Console.WriteLine("Invalid Option:(");
                goto again;
            }
            return option;
        }
        static void thanks()
        {
            Console.WriteLine(" _____ _                 _         ______          ______ _             _             \r\n|_   _| |               | |        |  ___|         | ___ \\ |           (_)            \r\n  | | | |__   __ _ _ __ | | _____  | |_ ___  _ __  | |_/ / | __ _ _   _ _ _ __   __ _ \r\n  | | | '_ \\ / _` | '_ \\| |/ / __| |  _/ _ \\| '__| |  __/| |/ _` | | | | | '_ \\ / _` |\r\n  | | | | | | (_| | | | |   <\\__ \\ | || (_) | |    | |   | | (_| | |_| | | | | | (_| |\r\n  \\_/ |_| |_|\\__,_|_| |_|_|\\_\\___/ \\_| \\___/|_|    \\_|   |_|\\__,_|\\__, |_|_| |_|\\__, |\r\n                                                                   __/ |         __/ |\r\n                                                                  |___/         |___/ ");
        }
            
    }

