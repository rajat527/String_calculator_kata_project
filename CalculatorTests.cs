using System;
using FluentAssertions;
using Xunit;

namespace StringCalculator.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("", 0)]     // empty string return 0
        [InlineData("1", 1)]    // string 1 return 1
        [InlineData("1,2", 3)]  // string 1,2 return their sum
        public void Add_AddsUpToTwoNumber_WhenStringIsValid(string calculation, int awaited_value) // sum of the number added in random_value
        {
            // we made a calculator class 
            var System_On_The_Test = new Calculator(); 
            
            // using Add method 
            var result = System_On_The_Test.Add(calculation);

            // result should be same as awaited_value
            result.Should().Be(awaited_value);
        }
        
        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("10,90,10,20", 130)]
        public void Add_AddsUpToAnyNumber_WhenStringIsValid(string calculation, int awaited_value)
        {
            // we made a calculator class 
            var System_On_The_Test = new Calculator();
            
            // using Add method 
            var result = System_On_The_Test.Add(calculation);

            // result should be same as awaited_value
            result.Should().Be(awaited_value);
        }
        
        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("10\n90,10\n20", 130)]
        public void Add_AddsNumbersUsingNewLineDelimiter_WhenStringIsValid(string calculation, int awaited_value)
        {
            // we made a calculator class 
            var System_On_The_Test = new Calculator();
            
            // using Add method 
            var result = System_On_The_Test.Add(calculation);

            // result should be same as awaited_value
            result.Should().Be(awaited_value);
        }
        
        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//;\n1;2;4", 7)]
        public void Add_AddsNumbersUsingCustomDelimiter_WhenStringIsValid(string calculation, int awaited_value)
        {
            // we made a calculator class 
            var System_On_The_Test = new Calculator();
            
            // using Add method 
            var result = System_On_The_Test.Add(calculation);

            // result should be same as awaited_value
            result.Should().Be(awaited_value);
        }
        
        [Theory]
        [InlineData("1,2,-1", "-1")]
        [InlineData("//;\n1;-2;-4", "-2,-4")]
        public void Add_ShouldThrowAnException_WhenNegativeNumbersAreUsed(string calculation, string negativeNumbers)
        {
            // we made a calculator class 
            var System_On_The_Test = new Calculator();
            
            // using Add method 
            Action action = () => System_On_The_Test.Add(calculation);

            // result should be same as awaited_value
            action.Should().Throw<Exception>()
                .WithMessage("Negatives not allowed: " + negativeNumbers);
        }
    }
}