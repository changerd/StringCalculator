using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public class Calculator
    {
        public static double Calculate(string input)
        {
            return 0;
        }

        static void ClosingParanthesis(Stack<double> vStack, Stack<char> opStack)
        {

        }

        static double InputNumebr(char[] exp, int pos, Stack<double> vStack)
        {
            return pos;
        }

        static void InputOpertor(char op, Stack<double> vStack, Stack<char> opStack)
        {

        }

        static bool OperatorCausesEvalation(char op, char prevOp)
        {            
            bool evaluate = false;

            switch(op)
            {
                case '+':
                case '-':
                    evaluate = (prevOp != '(');
                    break;
                case '*':
                case '/':
                    evaluate = (prevOp == '*' || prevOp == '/');
                    break;
                case ')':
                    evaluate = true;
                    break;
            }

            return evaluate;
        }

        static void ExecuteOperation(Stack<double> vStack, Stack<char> opStack)
        {
            double rightOperand = vStack.Pop();
            double leftOperand = vStack.Pop();
            char op = opStack.Pop();

            double result = 0;

            switch (op)
            {
                case '+':
                    result = leftOperand + rightOperand;
                    break;
                case '-':
                    result = leftOperand - rightOperand;
                    break;
                case '*':
                    result = leftOperand * rightOperand;
                    break;
                case '/':
                    result = leftOperand / rightOperand;
                    break;
            }

            vStack.Push(result);
        }
    }
}
