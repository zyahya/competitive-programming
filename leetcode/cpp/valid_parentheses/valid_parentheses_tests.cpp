#include "./valid_parentheses__stack.cpp"
#include <doctest.h>

TEST_CASE("valid parentheses")
{
    SUBCASE("")
    {
        CHECK(ValidParentheses_Stack::isValid("(){[]}") == true);
        CHECK(ValidParentheses_Stack::isValid("(){[]}[") == false);
    }
}
