using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression (ex. 2 + 3): ");
            string input = Console.ReadLine();

            try
            {
                Parser parser = new Parser();
                (double num1, string op, double num2) = parser.Parse(input);

                Calculator calculator = new Calculator();
                double result = calculator.Calculate(num1, op, num2);

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Parser class to parse the input
    public class Parser
    {
        public (double, string, double) Parse(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length != 3)
            {
                throw new FormatException("Input must be in the format: number operator number");
            }

            double num1 = Convert.ToDouble(parts[0]);
            string op = parts[1];
            double num2 = Convert.ToDouble(parts[2]);

            return (num1, op, num2);
        }
    }

    // Calculator class to perform operations
    public class Calculator
    {
        // ---------- TODO ----------
        public int getgcd(int n1, int n2){
            if(n1 % n2 == 0){
                return n2;
            }else{
                return getgcd(n2, n1%n2);
            }
        }
        public double Calculate(double num1, string op, double num2){
            if(op=="+"){
                return num1 + num2;
            }
            else if(op=="-"){
                return num1 - num2;
            }
            else if(op == "*"){
                return num1 * num2;
            }
            else if(op == "/"){
                if(num2 == 0){
                    throw new DivideByZeroException("Division by zero is not allowed");
                }
                else{
                    return num1 / num2;
                }
            }
            else if(op == "**"){
                double pow_result = 1;
                int num1_pow = (int)num1;
                if(num2 >= 0){
                    for(int i = 0; i < num2; i++){
                    pow_result *= num1_pow;
                    }
                }else{
                    for(int j = 0; j < -num2; j++){
                        pow_result /= num1_pow;
                    }
                }
                return pow_result;
            }
            else if(op=="%"){
                int num1_per = (int)num1;
                int num2_per = (int)num2;
                return num1_per % num2_per;
            }
            else if(op =="G"){
                int num1_G = (int)num1;
                int num2_G = (int)num2;
                if (num1_G >= num2_G){
                    return getgcd(num1_G, num2_G);
                }
                else{
                    return getgcd(num2_G, num1_G);
                }
            }
            else if(op == "L"){
                int num1_G = (int)num1;
                int num2_G = (int)num2;
                if (num1_G >= num2_G){
                    return num1_G*num2_G/getgcd(num1_G, num2_G);
                }
                else{
                    return num1_G*num2_G/getgcd(num2_G, num1_G);
                }
            }
            else{
                throw new InvalidOperationException("Invalid operator");
            }
        }
        // --------------------
    }
}

/* example output

Enter an expression (ex. 2 + 3):
>> 4 * 3
Result: 12

*/


/* example output (CHALLANGE)

Enter an expression (ex. 2 + 3):
>> 4 ** 3
Result: 64

Enter an expression (ex. 2 + 3):
>> 5 ** -2
Result: 0.04

Enter an expression (ex. 2 + 3):
>> 12 G 15
Result: 3

Enter an expression (ex. 2 + 3):
>> 12 L 15
Result: 60

Enter an expression (ex. 2 + 3):
>> 12 % 5
Result: 2

*/