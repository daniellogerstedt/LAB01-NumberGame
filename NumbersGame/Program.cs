using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unfortunately, something went wrong");
                Console.WriteLine($"Error: {e.Message}");
            }
            finally
            {
                Console.WriteLine("The Game Has Ended");
            }
        }

        static void StartSequence()
        {
            Console.WriteLine("Please Enter A Number Greater Than 0");
            string answer = Console.ReadLine();
            if (answer.Equals("Surprise")) throw new Exception("This is a surprise error.");
            try
            {
                int popArrLen = Convert.ToInt32(answer);
                int[] unpopArr = new int[popArrLen];
                int[] popArr = Populate(unpopArr);
                int sum = GetSum(popArr);
                int product = GetProduct(popArr, sum);
                decimal quotient = GetQuotient(product);
                int random = product / sum;
                decimal divisor = product / quotient;
                Console.WriteLine($"Your array is size: {popArrLen}");
                string numbersString = $"The numbers in the array are {popArr[0]}";
                for (int i = 1; i < popArrLen; i++)
                {
                    numbersString = $"{numbersString}, {popArr[i]}";
                }
                Console.WriteLine(numbersString);
                Console.WriteLine($"The sum of the array is {sum}");
                Console.WriteLine($"{sum} * {random} = {product}");
                Console.WriteLine($"{product} / {divisor} = {quotient}");
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (OverflowException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        static int[] Populate(int[] popArr)
        {
            int arrLen = popArr.Length;
            for (int i = 0; i < arrLen; i++)
            {
                Console.WriteLine($"Please enter a number {i + 1}/{arrLen}");
                string answer = Console.ReadLine();
                int number = int.Parse(answer);
                popArr[i] = number;
            }
            return popArr;
        }

        static int GetSum(int[] popArr)
        {
            int sum = 0;
            for (int i = 0; i < popArr.Length; i++)
            {
                sum = sum + popArr[i];
            }
            if (sum < 20) throw new Exception($"Value of {sum} is too low");
            return sum;
        }

        static int GetProduct(int[] popArr, int sum)
        {
            Console.WriteLine($"Please enter a random number between 1 and {popArr.Length}");
            string randomString = Console.ReadLine();
            int randomNumber = Int32.Parse(randomString);
            try
            {
                int product = sum * popArr[randomNumber - 1];
                return product;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Please enter a number to divide your product {product} by");
            string divisorString = Console.ReadLine();
            int.TryParse(divisorString, out int divisor);
            try
            {
                decimal quotient = decimal.Divide(product, divisor);
                return quotient;
            }
            catch (DivideByZeroException e)
            {
                throw e;
            }
        }
    }
}
