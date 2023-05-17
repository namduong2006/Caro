using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Caro
{
    internal class Board
    {
        public int x;
        public int y;
        public char[,] board= new char[3,3]; 
        public bool gameover=false;
        
        public void Reset()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    board[i,j] = ' ';
                }
            }
        }
        
        public void DrawBoard()
        {
            // Khởi tạo bàn cờ
            
            Console.WriteLine("  1 2 3");
            Console.WriteLine(" -------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + 1 + "|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + "|");
                }
                Console.WriteLine();
                Console.WriteLine(" -------");
            }
        }
        public void Player()
        {
            Console.WriteLine("Play 1 (X)");
            Console.Write("x= ");
            x = int.Parse(Console.ReadLine()) - 1;            
            Console.Write("y= ");
            y = int.Parse(Console.ReadLine()) - 1;
            if (board[x,y]!=' ')
            {
                Console.WriteLine("Ô này đã sử dụng, nhập tọa độ ô khác!");
                while (board[x, y] != ' ')
                {
                    Console.Write("x= ");
                    x = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("y= ");
                    y = int.Parse(Console.ReadLine()) - 1;
                }
            }
            board[x, y] = 'X';
        }
        public void Computer()
        {
            Console.WriteLine("Play 2 (O)");
            Console.Write("x= ");
            x = int.Parse(Console.ReadLine()) - 1;
            Console.Write("y= ");
            y = int.Parse(Console.ReadLine()) - 1;
            if (board[x, y] != ' ')
            {
                Console.WriteLine("Ô này đã sử dụng, nhập tọa độ ô khác!");
                while (board[x, y] != ' ')
                {
                    Console.Write("x= ");
                    x = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("y= ");
                    y = int.Parse(Console.ReadLine()) - 1;
                }
            }
            board[x, y] = 'O';
        }
        public void Check()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i,0]=='X')
                {
                    gameover = true;
                    Console.WriteLine("Play 1 (X) win");
                    
                }
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] == 'O')
                {
                    gameover = true;
                    Console.WriteLine("Play 2 (O) win");
                }
            }
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] != ' ' && board[0, j] == board[1, j] && board[1, j] == board[2, j] && board[0, j] == 'X')
                {
                    gameover = true;
                    Console.WriteLine("Play 1 (X) win");
                }
                if (board[0, j] != ' ' && board[0, j] == board[1, j] && board[1, j] == board[2, j] && board[0, j] == 'O')
                {
                    gameover = true;
                    Console.WriteLine("Play 2 (O) win");
                }
            }
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0,0]=='X')
            {
                gameover = true;
                Console.WriteLine("Play 1 (X) win");
            }
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] == 'O')
            {
                gameover = true;
                Console.WriteLine("Play 2 (O) win");
            }
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0,2]=='X')
            {
                gameover = true;
                Console.WriteLine("Play 1 (X) win");
            }
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] == 'O')
            {
                gameover = true;
                Console.WriteLine("Play 2 (O) win");
            }
        }
        public void CheckFull()
        {
            int kq = 0;
            for(int i = 0; i < 3; i++)
            {
                int c = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                     c++;                    
                }
                kq = c;
            }
            if (kq == 0)
            {
                Console.WriteLine("Hòa");
                gameover = true;
            }
        }
    }
}
