#include <stack>
#include <string>
#include <iostream>

using namespace std;

class Q0020_ValidParentheses {
public:
  bool arePair(char open, char close)
  {
      return (open == '(' && close == ')') ||
              (open == '{' && close == '}') ||
              (open == '[' && close == ']');
  }

  bool isValid(string s) {

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
