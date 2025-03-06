﻿using MedicineDiary.BotLogic.Handlers.MessageHandlers;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace MedicineDiary.Tests
{
    public class FunctionsTest
    {
        private readonly ITestOutputHelper _output;
        public FunctionsTest(ITestOutputHelper output)
        {
            _output = output;            
        }

        [Theory]
        [InlineData("10 30 ")]
        [InlineData(" 10/30")]
        [InlineData("10:30")]
        [InlineData("10. 30")]
        public async void AddChatTimeHandlerParseTimeTest(string time)
        {

            var result = AddChatTimeHandler.ParseTime(time);

            _output.WriteLine(result.ToString());
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(10,29)]
        [InlineData(12,48)]
        [InlineData(9,6)]
        [InlineData(16,32)]
        public async void GetUtcDeviationTest(int hours, int minutes)
        {

            var result = AddChatTimeHandler.GetUtcDeviation(new TimeSpan(hours,minutes,0));

            _output.WriteLine(result.ToString());
            Assert.NotNull(result);
        }

    }
}
