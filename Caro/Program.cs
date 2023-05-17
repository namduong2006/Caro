using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Caro
{
    internal class Program
    {
        static string filePath = "D:\\Code Gym\\Caro\\result.txt";
        static void Main(string[] args)
        {
                Console.OutputEncoding = Encoding.UTF8;
                int X = 0, O = 0;
                Board board = new Board();           
                Console.WriteLine("1.Play");
                Console.WriteLine("2.GameOver");
                Console.Write("Chọn: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        board.Reset();
                        while (board.gameover == false)
                        {
                            Console.Clear();
                            board.DrawBoard();
                            board.Player();
                            Console.Clear();
                            board.DrawBoard();
                            board.Check();                           
                            if (board.gameover == true)
                            {
                                X += 1;
                                break;
                            }
                            board.CheckFull();
                            if (board.gameover == true)
                            {
                                X=X;
                                break;
                            }
                            board.Computer();
                            Console.Clear();
                            board.DrawBoard();
                            board.Check();                           
                            if (board.gameover == true)
                            {
                                O += 1;
                                break;
                            }
                            board.CheckFull();
                            if (board.gameover == true)
                            {
                                O =O;
                                break;
                            }
                        }                                              
                        using (StreamWriter writer = new StreamWriter(filePath, true))
                        {                          
                            writer.WriteLine($"X vs O : {X}:{O}");
                        }
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Không hợp lệ");
                        break;
                }
                Console.ReadLine();
        }
    }
}
