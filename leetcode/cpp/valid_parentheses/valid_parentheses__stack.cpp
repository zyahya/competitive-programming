#include <stack>
#include <string>

using namespace std;

class ValidParentheses_Stack
{
  private:
    static bool arePair(char open, char close)
    {
        return (open == '(' && close == ')') || (open == '{' && close == '}') || (open == '[' && close == ']');
    }

  public:
    static bool isValid(string s)
    {

        stack<char> stack;

        for (int i = 0; i < s.length(); i++)
        {
            if (s[i] == '(' || s[i] == '{' || s[i] == '[')
            {
                stack.push(s[i]);
            }
            else if (s[i] == ')' || s[i] == '}' || s[i] == ']')
            {
                if (stack.empty() || !arePair(stack.top(), s[i]))
                {
                    return false;
                }
                else
                {
                    stack.pop();
                }
            }
        }

        return stack.empty() ? true : false;
    }
};
