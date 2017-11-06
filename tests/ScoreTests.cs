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
            var score = new Score();
            Assert.Equal(answer, score.ConvertHole(key));
        }

        [Theory]
        [InlineData("Par5", "Condor", 1)]
        [InlineData("Par4", "Condor", 0)]
        [InlineData("Par5", "Albatross", 2)]
        [InlineData("Par4", "Albatross", 1)]
        [InlineData("Par3", "Albatross", 0)]
        [InlineData("Par5", "Eagle", 3)]
        [InlineData("Par4", "Eagle", 2)]
        [InlineData("Par3", "Eagle", 1)]
        [InlineData("Par4", "Birdie", 3)]
        [InlineData("Par3", "Birdie", 2)]
        [InlineData("Par5", "Birdie", 4)]
        [InlineData("Par2", "Par", 2)]
        [InlineData("Par3", "Par", 3)]
        [InlineData("Par4", "Par", 4)]
        [InlineData("Par5", "Par", 5)]
        [InlineData("Par3", "Bogey", 4)]
        [InlineData("Par4", "Bogey", 5)]
        [InlineData("Par2", "Bogey", 3)]
        [InlineData("Par5", "Bogey", 6)]
        [InlineData("Par5", "Double", 7)]
        [InlineData("Par4", "Double", 6)]
        [InlineData("Par3", "Double", 5)]
        [InlineData("Par2", "Double", 4)]
        [InlineData("Par5", "Triple", 8)]
        [InlineData("Par4", "Triple", 7)]
        [InlineData("Par3", "Triple", 6)]
        [InlineData("Par2", "Triple", 5)]
        public void CanIdentifyAScore(string key, string value, int answer){
            var score = new Score();
            Assert.Equal(answer, score.Calculate(key, value));
        }

        [Theory]
        [InlineData("Par1", "Eagle")]
        [InlineData("Par2", "Albatross")]
        [InlineData("Par3", "Condor")]
        [InlineData("Par3", "-4")]
        [InlineData("Par1", "-41")]
        public void ScoreCantBeLessThanZero(string hole, string playerScore) {
            var score = new Score();
            Assert.Throws<InvalidOperationException>(() => score.Calculate(hole, playerScore));
        }

        [Fact]
        public void ScoreCanAccumulate() {
            var score = new Score();
            Assert.Equal(4, score.Add("Par3", "Bogey"));
            Assert.Equal(7, score.Add("Par3", "Par"));
            Assert.Throws<InvalidOperationException>(() => score.Add("Par1", "Albatross"));
            Assert.Equal(7, score.Total);
        }

        [Fact]
        public void CanGetTotal() {
            var score = new Score();
            var x = score.Add("Par3", "Bogey");
            Assert.Equal(4, score.Total);
            Assert.Equal(x, score.Total);
        }

        [Theory]
        [InlineData("Par4", "+5", 9)]
        [InlineData("Par3", "+1", 4)]
        [InlineData("Par2", "+3", 5)]
        [InlineData("Par3", "+9", 12)]
        public void CanScoreANumber(string hole, string value, int answer) {
            var score = new Score();
            Assert.Equal(answer, score.Calculate(hole, value));
        }

        [Theory]
        [InlineData("Rob23")]
        [InlineData("41test")]
        [InlineData("41")]
        [InlineData("Par")]
        public void MustProvideValidHole(string hole) {
            var score = new Score();
            Assert.Throws<ArgumentException>(() => score.ConvertHole(hole));
        }
    }
}