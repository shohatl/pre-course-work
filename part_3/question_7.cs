namespace Question7
{

    public class NumericalExpression
    {
        public int num { get; set; }
        private List<string> first = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private List<string> second = new List<string> { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private List<string> ten = new List<string> { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        public NumericalExpression(int num)
        {
            this.num = num;
        }

        public override string ToString()
        {
            string numberString = this.num.ToString();
            while (numberString.Length % 3 != 0)
            {
                numberString = "0" + numberString;
            }
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
                        final += this.second[numberString[i] - '0' - 1] + " ";
                    }
                    else if (i % 3 == 2)
                    {
                        final += this.first[numberString[i] - '0' - 1] + " ";
                    }
                }
            }

            return final;
        }
    }

    public class Program
    {
        public static void Main()
        {
            NumericalExpression num = new NumericalExpression(1234);
            Console.WriteLine(num.ToString());
        }
    }
}