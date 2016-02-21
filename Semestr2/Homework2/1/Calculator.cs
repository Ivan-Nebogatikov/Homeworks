using System;
using InerfaceStack;

namespace NamespaceCalculator
{
    /// <summary>
    /// Stack calculator class
    /// </summary>
    class Calculator
    {
        private static bool IsOperation(char symbol)
        {
            return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';
        }

        private static bool IsNumber(char symbol)
        {
            return symbol >= '0' && symbol <= '9';
        }

        /// <summary>
        /// Stack calculating method. Returns value from stack head or Int32.MinValue if expression is incorrect
        /// </summary>
        public static int Calculate(IStack stack, string expression)
        {
            foreach (var symbol in expression)
            {
                if (IsNumber(symbol))
                {
                    stack.Push((int)char.GetNumericValue(symbol));
                    continue;
                }
                if (IsOperation(symbol))
                {
                    int firstNumber = 0;
                    int secondNumber = 0;
                    if (!stack.IsEmpty())
                        firstNumber = stack.Pop();
                    else
                        return Int32.MinValue;
                    if (!stack.IsEmpty())
                        secondNumber = stack.Pop();
                    else
                        return Int32.MinValue;
                    switch (symbol)
                    {
                        case '+':
                            stack.Push(firstNumber + secondNumber);
                            break;
                        case '-':
                            stack.Push(firstNumber - secondNumber);
                            break;
                        case '*':
                            stack.Push(firstNumber * secondNumber);
                            break;
                        case '/':
                            if (secondNumber != 0)
                                stack.Push(firstNumber / secondNumber);
                            else
                                return Int32.MinValue;
                            break;
                        default:
                            return Int32.MinValue;
                    }
                    continue;
                }
                if (symbol != ' ')
                    return Int32.MinValue;
            }
            if (stack.IsEmpty())
                return Int32.MinValue;
            return stack.Pop();
        }
    }
}
