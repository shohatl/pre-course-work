namespace Question7
{

    public class NumericalExpression
    {
        private int InitialNum;
        public int Num { get; set; }
        private readonly List<string> first = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private readonly List<string> second = new List<string> { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private readonly List<string> ten = new List<string> { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

        private readonly List<string> addons = new List<string> { "thousand", "million", "billion", "trillion", "quadrillion"};

        public NumericalExpression(int num)
        {
            this.Num = num;
            this.InitialNum = num;
        }

        public int GetValue()
        {
            return this.InitialNum;
        }

        public override string ToString()
        {
            string numberString = this.Num.ToString();
            while (numberString.Length % 3 != 0)
            {
                numberString = "0" + numberString;
            }
            int neededAddons = numberString.Length / 3 - 2;
            string final = "";
            for (int i = 0; i < numberString.Length; i++)
            {
                if (numberString[i] != '0')
                {
                    if (i % 3 == 0)
                    {
                        final += this.first[numberString[i] - '0' - 1] + " hundred ";
                    }
                    else if (i % 3 == 1)
                    {
                        if(numberString[i] == '1')
                        {
                            i++;
                            final += this.ten[numberString[i] - '0' - 1] + " ";
                        }
                        else{
                            final += this.second[numberString[i] - '0' - 1] + " ";
                        }
                    }
                    else if (i % 3 == 2)
                    {
                        final += this.first[numberString[i] - '0' - 1] + " ";

                    }
                      
                    if(i % 3 == 2)
                    {
                        if (neededAddons > -1)
                        {
                            if (neededAddons < this.addons.Count)
                            {
                                final += this.addons[neededAddons] + ", ";
                            }
                            neededAddons--;
                        } 
                    }
                }
            }

            return final;
        }

        public static int SumLetters(int num)
        {
            int sum = 0;
            for (int i = 0; i <= num; i++)
            {
                NumericalExpression expression = new NumericalExpression(i);
                sum += expression.ToString().Replace(" ", "").Length;
            }
            return sum;
        }

        public static int SumLetters(NumericalExpression num)
        {
            int sum = 0;
            for (int i = 0; i <= num.Num; i++)
            {
                NumericalExpression expression = new NumericalExpression(i);
                sum += expression.ToString().Replace(" ", "").Length;
            }
            return sum;
        }
    }

    public class Program
    {
        public static void Main()
        {
            NumericalExpression num = new NumericalExpression(1212121214);
            Console.WriteLine(num.ToString());
        }
    }
}