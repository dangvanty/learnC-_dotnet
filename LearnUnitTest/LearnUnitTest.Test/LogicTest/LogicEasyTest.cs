using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using LearnUnitTest.DNS;
using LearnUnitTest.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace LearnUnitTest.Test.LogicTest
{
    public class LogicEasyTest
    {
        private readonly LogicEasy _logicEasy;
        private readonly IDNS _dNS;
        public LogicEasyTest() 
        {
            //dependencies
            _dNS = A.Fake<IDNS>();

            //SUT
            _logicEasy = new LogicEasy(_dNS);
        
        }
        [Fact]
        public void LogicEasy_SayHi_ReturnString()
        {
            // Arrage, variables, classes, mocks
            //LogicEasy logicEasyTest = new LogicEasy();
            A.CallTo(()=>_dNS.SendDNS()).Returns(true);

            // act
            var result = _logicEasy.SayHi();

            // assert

            result.Should().Be("Hello : baby");
            result.Should().NotContain("ty");
        }
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(1,4,5)]
        public void LogicEasy_SumTwoNum_ReturnInt(int a, int b, int expected)
        {
            // Arange:
            //LogicEasy logicEasy = new LogicEasy();

            // Act

            var result = _logicEasy.SumTwoNum(a,b);
            // Assert
            result.Should().Be(expected);
            result.Should().NotBe(0);
            result.Should().NotBeInRange(100, 100000);

        }

        [Fact]
        public void LogicEasy_DateNow_ReturnDate()
        {
            
            // act
            var result = _logicEasy.DateNow();

            // assert

            result.Should().BeAfter(1.February(2022));
            result.Should().BeBefore(10.December(2023));
            result.Should().HaveDay(14);
            result.Should().HaveMonth(7);
            result.Should().NotHaveYear(2022);
            //result.Should().BeLessThan(45.Minutes()).Before(new DateTime(2015,07,14,10,00,30));
        }

        [Fact]
        public void LogicEasy_GetPingOptions_ReturnObject()
        {
            //arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
            // act
            var result = _logicEasy.GetPingOptions();

            // assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }

        [Fact]
        public void LogicEasy_GetPingOptionsList_ReturnObject()
        {
            //arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            //act
            var result = _logicEasy.GetPingOptionsList();

            // assert
            result.Should().BeOfType<PingOptions[]>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x=>x.DontFragment==true);
        }

    }
}
