using System;

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
        protected int[,] Data = new int[4,4];

        public Board()
        {
            for(int i = 0; i < 2; i++)
            {
                this.AddPiece();
            }
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
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    for (int x = 0; x < this.Data.GetLength(0); x++)
                    {
                        List<int> pieces = this.GetColumnPieces(x);
                        for (int y = 0; y < this.Data.GetLength(1); y++)
                        {
                            if (pieces.Count < y)
                            {
                                this.Data[x,y] = pieces[y];
                            }

                            else
                            {
                                this.Data[x,y] = 0;
                            }
                        }
                    }
                    break;
                
                case Direction.Down:
                    for (int x = 0; x < this.Data.GetLength(0); x++)
                    {
                        List<int> pieces = this.GetColumnPieces(x);
                        for (int y = 0; y < this.Data.GetLength(1); y++)
                        {
                            if (pieces.Count < y)
                            {
                                this.Data[x, y] = pieces[y];
                            }

                            else
                            {
                                this.Data[x, this.Data.GetLength(1) - y] = 0;
                            }
                        }
                    }
                    break;
                
                case Direction.Right:
                    for (int y = 0; y < this.Data.GetLength(0); y++)
                    {
                        List<int> pieces = this.GetRowPieces(y);
                        for (int x = 0; x < this.Data.GetLength(0); x++)
                        {
                            if (pieces.Count < x)
                            {
                                this.Data[x,y] = pieces[x];
                            }

                            else
                            {
                                this.Data[x,y] = 0;
                            }
                        }
                    }
                    break;

                case Direction.Left:
                    for (int y = 0; y < this.Data.GetLength(0); y++)
                    {
                        List<int> pieces = this.GetRowPieces(y);
                        for (int x = 0; x < this.Data.GetLength(0); x++)
                        {
                            if (pieces.Count < x)
                            {
                                this.Data[this.Data.GetLength(0) - x,y] = pieces[x];
                            }

                            else
                            {
                                this.Data[x,y] = 0;
                            }
                        }
                    }
                    break;
            }
            this.AddPiece();
        }
        
    }
    public class Program
    {
        public static void Main()
        {
            Board test = new Board();
            test.Move(Direction.Down);
            Console.WriteLine(ArrayToString(test.GetData()));
        }
        
        private static string ArrayToString(int[,] array)
        {
            string result = "";

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    result += array[i, j] + " ";
                }
                result += "\n";
            }

            return result;
        }
    }
}