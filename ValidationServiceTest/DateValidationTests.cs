using System;
using ValidationService;
using Xunit;

namespace ValidationServiceTest
{
    public class DateValidationTests
    {
        private readonly DateValidation _dateValidation;
        public DateValidationTests() => _dateValidation = new DateValidation();

        [Fact]
        public void IsValid_ValidDate_ReturnsTrue()
            => Assert.True(_dateValidation.IsValid("30/04/2022"));

        [Fact]
        public void IsValid_LengthOfDateWrong_ReturnsFalse()
            => Assert.False(_dateValidation.IsValid("30/04//2022"));


        [Theory]
        [InlineData("30/04/20222")]
        [InlineData("30/04//2022")]
        public void IsValid_LengthOfDatesWrong_ReturnsFalse(string dateParam) 
            => Assert.False(_dateValidation.IsValid(dateParam));


        [Fact]
        public void IsValid_DelimiterOfDateWrong_ThrowsArgumentException()
            => Assert.Throws<ArgumentException>(() => _dateValidation.IsValid("30.04.2022"));

        [Theory]
        [InlineData("28/04/2022")]
        [InlineData("29/04/2022")]
        public void IsValid_ValidDates_ReturnsTrue(string dateParam)
            => Assert.True(_dateValidation.IsValid(dateParam));

    }
}
