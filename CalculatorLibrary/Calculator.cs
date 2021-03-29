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
            char[] exp = input.ToCharArray();
            Stack<double> vStack = new Stack<double>();
            Stack<char> opStack = new Stack<char>();

            opStack.Push('(');

            int pos = 0;
            while(pos <= exp.Length)
            {
                if(pos == exp.Length || exp[pos] == ')')
                {
                    ClosingParanthesis(vStack, opStack);
                    pos++;
                }
                else if (exp[pos] >= '0' && exp[pos] <= '9')
                {
                    pos = InputNumber(exp, pos, vStack);
                }
                else
                {
                    InputOpertor(exp[pos], vStack, opStack);
                    pos++;
                }
            }

            return vStack.Pop();
        }

        static void ClosingParanthesis(Stack<double> vStack, Stack<char> opStack)
        {
            while (opStack.Peek() != '(')
            {
                ExecuteOperation(vStack, opStack);
            }

            opStack.Pop();
        }

        static int InputNumber(char[] exp, int pos, Stack<double> vStack)
        {
            double value = 0;
            while(pos < exp.Length && exp[pos] >= '0' && exp[pos] <= '9')
            {
                value = 10 * value + (double)(exp[pos++] - '0');
            }

            vStack.Push(value);

            return pos;
        }

        static void InputOpertor(char op, Stack<double> vStack, Stack<char> opStack)
        {
            while (opStack.Count > 0 && OperatorCausesEvalation(op, opStack.Peek()))
            {
                ExecuteOperation(vStack, opStack);
            }

            opStack.Push(op);
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
            char op = opStack.Pop();
            //double leftOperand = vStack.Pop();
            double leftOperand = 0;
            if (vStack.Count > 0)
            {
                leftOperand = vStack.Pop();
            }
            else if (vStack.Count == 0 && op == '-')
            {
                leftOperand = -1;
                op = '*';
            }
            /*else
            {
                throw new Exception("Error calculate operation");
            }*/

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
