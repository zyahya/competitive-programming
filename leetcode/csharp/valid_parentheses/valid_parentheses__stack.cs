using System.Collections.Generic;

namespace LeetCode.Solutions.q20_valid_parentheses;

public class ValidParentheses_Stack
{
    public static bool Solution(string parentheses)
    {
        Stack<char> stack = new();

        for (int current = 0; current < parentheses.Length; current++)
        {
            if (IsEmpty(stack))
            {
                if (IsCloseParenthesis(parentheses[current]))
                {
                    return false;
                }
                else
                {
                    stack.Push(parentheses[current]);
                }
            }
            else
            {
                if (ArePair(stack.Peek(), parentheses[current]))
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(parentheses[current]);
                }
            }
        }

        return IsEmpty(stack);
    }

    private static bool IsEmpty(Stack<char> stack)
    {
        return stack.Count == 0;
    }

    private static bool IsCloseParenthesis(char parenthesis)
    {
        return parenthesis == ')' || parenthesis == ']' || parenthesis == '}';
    }

    private static bool ArePair(char open, char close)
    {
        return open == '(' && close == ')' ||
                open == '[' && close == ']' ||
                open == '{' && close == '}';
    }
}
