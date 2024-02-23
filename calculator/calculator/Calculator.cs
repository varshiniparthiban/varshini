using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace calculator
{
    class Calculator
    {
        public double Calculate(String  expression)
        {
            /* DataTable table = new DataTable();
             DataColumn column = new DataColumn("expression", typeof(double), txttotal);
             table.Columns.Add(column);
             DataRow row = table.NewRow();
             table.Rows.Add(row);
             double result = (double)row["expression"];
             return result;*/
            Stack<double> numbers = new Stack<double>();
            Stack<char> operators = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (c == ' ')
                {
                    continue;
                }
                else if (char.IsDigit(c))
                {
                    double num = 0;
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        num = num * 10 + (expression[i] - '0');
                        i++;
                    }
                    i--;
                    numbers.Push(num);
                }
                else
                {
                    while (operators.Count > 0 && GetPrecedence(c) <= GetPrecedence(operators.Peek()))
                    {
                        ProcessOperator(numbers, operators);
                    }
                    operators.Push(c);
                }
            }

            while (operators.Count > 0)
            {
                ProcessOperator(numbers, operators);
            }

            return numbers.Peek();
        }

        static void ProcessOperator(Stack<double> numbers, Stack<char> operators)
        {
            char op = operators.Pop();
            double num2 = numbers.Pop();
            double num1 = numbers.Pop();
            double result = 0;

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;
                case '^':
                    result = Math.Pow(num1, num2);
                    break;
                case '%':
                    result = num1 % num2;
                    break;
            }

            numbers.Push(result);
        }

        static int GetPrecedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                case '%':
                    return 2;
                case '^':
                    return 3;
                default:
                    return 0;
            }

        }
    }
}
