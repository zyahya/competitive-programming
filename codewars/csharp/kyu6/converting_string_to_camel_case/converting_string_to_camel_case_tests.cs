namespace Codewars.Solutions.kyu6.converting_string_to_camel_case;

public class ConvertingStringToCamelCaseTests
{
    [Theory]
    [InlineData("the-stealth-warrior", "theStealthWarrior")]
    [InlineData("The_Stealth_Warrior", "TheStealthWarrior")]
    [InlineData("The_Stealth-Warrior", "TheStealthWarrior")]
    public void StringBuilder(string input, string output)
    {
        string result = ConvertingStringToCamelCase_StringBuilder.Solution(input);

        Assert.Equal(output, result);
    }
}
