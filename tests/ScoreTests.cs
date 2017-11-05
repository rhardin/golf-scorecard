using System;
using System.Collections.Generic;
using Xunit;

namespace tests {
    public class ScoreTests {

        [Theory]
        [InlineData("Par2", 2)]
        [InlineData("Par3", 3)]
        [InlineData("Par4", 4)]
        [InlineData("Par5", 5)]
        public void CanConvertHoleValue(string key, int answer) {
            Assert.Equal(answer, ConvertHole(key));
        }

        [Theory]
        [InlineData("Par3", "Bogey", 4)]
        [InlineData("Par4", "Bogey", 5)]
        [InlineData("Par2", "Bogey", 3)]
        [InlineData("Par5", "Bogey", 6)]
        public void CanIdentifyABogey(string key, string value, int answer){
            Assert.Equal(answer, Score(key, value));
        }

        [Theory]
        [InlineData("Par2", "Par", 2)]
        [InlineData("Par3", "Par", 3)]
        [InlineData("Par4", "Par", 4)]
        [InlineData("Par5", "Par", 5)]
        public void CanIdentifyPar(string key, string value, int answer) {
            Assert.Equal(answer, Score(key, value));
        }

        [Theory]
        [InlineData("Par4", "Birdie", 3)]
        public void CanIdentifyABirdie(string key, string value, int answer) {
            Assert.Equal(answer, Score(key, value));
        }

        private int ConvertHole(string holeValue)
        {
            var val = holeValue.Split(new [] { "Par" }, StringSplitOptions.None)[1];
            return int.Parse(val);
        }

        private int Score(string key, string value)
        {
            if (value == "Bogey") { return ConvertHole(key)+1; }
            if (value == "Par") { return ConvertHole(key); }
            if (value == "Birdie") { return ConvertHole(key)-1; }
            throw new NotImplementedException();
        }
    }
}