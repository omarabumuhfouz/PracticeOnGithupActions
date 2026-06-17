using PlayWithGithupActions.Services;
using Xunit;

namespace PlayWithGithupActions.Tests;

public class DiscountCalculatorTests
{
    private readonly DiscountCalculator _sut; // sut = System Under Test

    public DiscountCalculatorTests()
    {
        _sut = new DiscountCalculator();
    }

    [Theory]
    [InlineData(-30, false, 30)]    // VIP over $100 -> 20% discount (150 * 0.20 = 30)
    [InlineData(50, true, 5)]      // VIP under $100 -> 10% discount (50 * 0.10 = 5)
    [InlineData(150, false, 7.5)]  // Normal over $100 -> 5% discount (150 * 0.05 = 7.5)
    [InlineData(50, false, 0)]     // Normal under $100 -> 0% discount
    [InlineData(-10, true, 0)]     // Edge case: Negative order amount returns 0
    [InlineData(0, false, 0)]      // Edge case: Zero order amount returns 0
    public void CalculateDiscount_ShouldReturnExpectedAmount(decimal amount, bool isVip, decimal expectedDiscount)
    {
        // Act
        var result = _sut.CalculateDiscount(amount, isVip);

        // Assert
        Assert.Equal(expectedDiscount, result);
    }
}