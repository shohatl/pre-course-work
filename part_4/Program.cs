using System;
using System.Reflection.Metadata;
using _2048;

namespace _2048{
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }

    public enum GameStatus
    {
        Win,
        Lose,
        Idle
    }

    public class Board
    {
        protected int[,] Data;

        public Board()
        {
            this.Data = new int[4,4];
            this.Data = new int[,]{
                {0,0,0,0},
                {0,0,0,0},
                {8,4,2,2},
                {0,0,0,0}
            };
            // for(int i = 0; i < 2; i++)
            // {
                // this.AddPiece();
            // }
        }

        public int[,] GetData()
        {
            int[,] copy = new int[this.Data.GetLength(0), this.Data.GetLength(1)];
            Array.Copy(this.Data, copy, this.Data.Length);
            return copy;
        }
        
        protected void AddPiece()
        {
            List<(int, int)> freeLocations = new List<(int, int)>();

            for (int x = 0; x < this.Data.GetLength(0); x++)
            {
                for (int y = 0; y < this.Data.GetLength(0); y++)
                {
                    if (this.Data[x,y] ==0)
                    {
                        freeLocations.Add((x,y));
                    }
                }
            }

            if (freeLocations.Count > 0)
            {
                Random rnd = new Random();
                (int newX, int newY) = freeLocations[rnd.Next(0, freeLocations.Count)];
                int newNum = rnd.Next(1, 3) * 2;

                this.Data[newX, newY] = newNum;
            }
        }

        private List<int> GetRowPieces(int y)
        {
            List<int> pieces = new List<int>();
            if (y >= 0 && y > this.Data.GetLength(1))
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int x = 0; x < this.Data.GetLength(0); x++)
            {
                if (this.Data[x,y] != 0)
                {
                    pieces.Add(this.Data[x,y]);
                }
            }
            return pieces;
        }

        private List<int> GetColumnPieces(int x)
        {
            List<int> pieces = new List<int>();
            if (x >= 0 && x > this.Data.GetLength(0))
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int y = 0; y < this.Data.GetLength(1); y++)
            {
                if (this.Data[x,y] != 0)
                {
                    pieces.Add(this.Data[x,y]);
                }
            }
            
            return pieces;
        }
        public int Move(Direction direction)
        {
            int points = 0;
            switch (direction)
            {
                case Direction.Up:
                    for (int x = 0; x < this.Data.GetLength(0); x++)
                    {
                        List<int> pieces = this.GetColumnPieces(x);
                        
                        int tempY = 0;
                        while (tempY < pieces.Count - 1)
                        {
                            if (pieces[tempY] == pieces[tempY + 1])
                            {
                                pieces[tempY] += pieces[tempY + 1];
                                points += pieces[tempY];
                                pieces.RemoveAt(tempY + 1);
                            }
                            tempY++;
                        }

                        for (int y = 0; y < this.Data.GetLength(1); y++)
                        {
                            if (y < pieces.Count)
                            {
                                this.Data[x, y] = pieces[y];
                            }

                            else
                            {
                                this.Data[x, y] = 0;
                            }
                        }
                    }
                    break;
                
                case Direction.Down:
                    for (int x = 0; x < this.Data.GetLength(0); x++)
                    {
                        List<int> pieces = this.GetColumnPieces(x);

                        int tempY = 0;
                        while (tempY < pieces.Count - 1)
                        {
                            if (pieces[pieces.Count - 1 -tempY] == pieces[pieces.Count - 2 -tempY])
                            {
                                pieces[pieces.Count - 1 -tempY] += pieces[pieces.Count - 2 -tempY];
                                points += pieces[pieces.Count - 1 -tempY];
                                pieces.RemoveAt(pieces.Count - 2 -tempY);
                            }
                            tempY++;
                        }
                        pieces.Reverse();
                        for (int y = 0; y < this.Data.GetLength(1); y++)
                        {
                            if (y < pieces.Count)
                            {
                                this.Data[x, this.Data.GetLength(1) - 1 - y] = pieces[y];
                            }

                            else
                            {
                                this.Data[x, this.Data.GetLength(1) - 1 - y] = 0;
                            }
                        }
                    }
                    break;
                
                case Direction.Right:
                    for (int y = 0; y < this.Data.GetLength(1); y++)
                    {
                        List<int> pieces = this.GetRowPieces(y);

                        int tempX = 0;
                        while (tempX < pieces.Count - 1)
                        {
                            if (pieces[pieces.Count - 1 -tempX] == pieces[pieces.Count - 2 -tempX])
                            {
                                pieces[pieces.Count - 1 -tempX] += pieces[pieces.Count - 2 -tempX];
                                points += pieces[pieces.Count - 1 -tempX];
                                pieces.RemoveAt(pieces.Count - 2 -tempX);
                            }
                            tempX++;
                        }
                        pieces.Reverse();
                        for (int x = 0; x < this.Data.GetLength(0); x++)
                        {
                            if (x < pieces.Count)
                            {
                                this.Data[this.Data.GetLength(0) - 1 - x, y] = pieces[x];
                            }

                            else
                            {
                                this.Data[this.Data.GetLength(0) - 1 - x ,y] = 0;
                            }
                        }
                    }
                    break;

                case Direction.Left:
                    for (int y = 0; y < this.Data.GetLength(1); y++)
                    {
                        List<int> pieces = this.GetRowPieces(y);

                        int tempX = 0;
                        while (tempX < pieces.Count - 1)
                        {
                            if (pieces[tempX] == pieces[tempX + 1])
                            {
                                pieces[tempX] += pieces[tempX + 1];
                                points += pieces[tempX];
                                pieces.RemoveAt(tempX + 1);
                            }
                            tempX++;
                        }

                        for (int x = 0; x < this.Data.GetLength(0); x++)
                        {
                            if (x < pieces.Count)
                            {
                                this.Data[x, y] = pieces[x];
                            }

                            else
                            {
                                this.Data[x, y] = 0;
                            }
                        }
                    }
                    break;
            }
            this.AddPiece();
            return points;
        }

        public int GetHighestPiece()
        {
            int max = 0;
            for (int x = 0; x < this.Data.GetLength(0); x++)
            {
                for (int y = 0; y < this.Data.GetLength(1); y++)
                {
                    if (this.Data[x, y] > max)
                    {
                        max = this.Data[x, y];
                    }
                }
            }
            return max;
        }

        public bool PossibleMove()
        {
            for (int x = 0; x < this.Data.GetLength(0); x++)
            {

                for (int y = 0; y < this.Data.GetLength(1); y++)
                {
                    if (this.Data[x, y] == 0)
                    {
                        return true;
                    }
                    if (x < this.Data.GetLength(0) - 1 && this.Data[x, y] == this.Data[x + 1, y])
                    {
                    return true;
                    }

                    if  (y < this.Data.GetLength(1) - 1 && this.Data[x, y] == this.Data[x, y + 1])
                    {
                    return true;
                    }
                }
            }
            return false;
        }
        
    }

    public class Game
    {
        protected Board Board;
        protected GameStatus GameStatus;
        public int Points {protected set; get;}

        public Game()
        {
            this.Board = new Board();
            this.GameStatus = GameStatus.Idle;
            this.Points = 0;
        }
        public void Move(Direction direction)
        {
            if (this.GameStatus == GameStatus.Lose){
                return;
            }
            else if (GameStatus == GameStatus.Idle)
            {
                this.Points += this.Board.Move(direction);
            }
            if (this.Board.GetHighestPiece() == 2048)
            {
                this.GameStatus = GameStatus.Win;
            }
            else if (!this.Board.PossibleMove())
            {
                this.GameStatus = GameStatus.Lose;
            }
        }

        public int[,] GetBoardData()
        {
            return this.Board.GetData();
        }

        public GameStatus GetStatus()
        {
            return this.GameStatus;
        }
    }

    public class ConsoleGame
    {
        public static Direction GetInput()
        {
            Console.WriteLine("Input direction");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char input = keyInfo.KeyChar;
                if (input == 'w')
                {
                    return Direction.Up;
                }
                else if (input == 's')
                {
                    return Direction.Down;
                }
                else if (input == 'a')
                {
                    return Direction.Left;
                }
                else if (input == 'd')
                {
                    return Direction.Right;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        private static string ArrayToString(int[,] array)
        {
            string result = "";
            int lengthX = 6;
            int lengthY = 3;
            string fillerY = "";
            for (int i = 0; i < (lengthY - 1) / 2; i++)
                {
                    fillerY += "\n";
                    for (int z = 0; z < 5; z++)
                    {
                        fillerY += "|";
                        for (int temp = 0; temp < lengthX; temp++)
                        {
                            fillerY += " ";
                        }
                    }
                    fillerY += "\n";
                }
            for (int y = 0; y < array.GetLength(1); y++)
            {
                for (int i = 0; i < lengthX * 4 + 5; i++)
                {
                    result += "_";
                }
                result += fillerY + "|";
                for (int x = 0; x < array.GetLength(0); x++)
                {
                    string fillerX = "";
                    for (int temp = 0; temp < (lengthX - array[x, y].ToString().Length) / 2; temp++)
                    {
                        fillerX += " ";
                    }
                    result += fillerX + array[x, y] + fillerX;
                    if ((lengthX - array[x, y].ToString().Length) % 2 == 1)
                    {
                        result += " ";
                    }
                    result += "|";
                }
                result += fillerY;
            }
            for (int i = 0; i < lengthX * 4; i++)
                {
                    result += "_";
                }

            return result;
        }

        public static void ShowGame(Game game)
        {
            Console.WriteLine($"Points scored: {game.Points}");
            Console.WriteLine(ArrayToString(game.GetBoardData()));
            if (game.GetStatus() == GameStatus.Win)
            {
                Console.WriteLine("You Won");
            }
            else if (game.GetStatus() == GameStatus.Lose)
            {
                Console.WriteLine("You Lost");
            }

        }
    }
    public class Program
    {
        public static void Main()
        {
            Game game = new Game();
            while (game.GetStatus() == GameStatus.Idle)
            {
                ConsoleGame.ShowGame(game);
                game.Move(ConsoleGame.GetInput());
            }
            ConsoleGame.ShowGame(game);
        }
    }
}