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
        [InlineData("Par5", "Eagle", 3)]
        [InlineData("Par4", "Eagle", 2)]
        [InlineData("Par3", "Eagle", 1)]
        [InlineData("Par3", "Bogey", 4)]
        [InlineData("Par4", "Bogey", 5)]
        [InlineData("Par2", "Bogey", 3)]
        [InlineData("Par5", "Bogey", 6)]
        [InlineData("Par4", "Birdie", 3)]
        [InlineData("Par3", "Birdie", 2)]
        [InlineData("Par5", "Birdie", 4)]
        [InlineData("Par2", "Par", 2)]
        [InlineData("Par3", "Par", 3)]
        [InlineData("Par4", "Par", 4)]
        [InlineData("Par5", "Par", 5)]
        public void CanIdentifyAScore(string key, string value, int answer){
            var score = new Score();
            Assert.Equal(answer, score.Calculate(key, value));
        }

        [Fact]
        public void CantIdentifyAnInvalidScore() {
            var score = new Score();
            Assert.Throws<InvalidOperationException>(() => score.Calculate("Par1", "Eagle"));
        }
    }

    public class Score {
        private Dictionary<string, int> scoreOperations;

        public Score() {
            //setup operations
            scoreOperations = new Dictionary<string, int>(){
                {"Eagle", -2},
                {"Birdie", -1},
                {"Par", 0},
                {"Bogey", 1}
            };
        }

        public int Calculate(string holeValue, string playerScore) {
            if (scoreOperations.ContainsKey(playerScore)) { 
                var x = ConvertHole(holeValue) + scoreOperations[playerScore]; 
                if (x < 0) { throw new InvalidOperationException("A score cannot result in a valud less than 0"); }
                return x;
            }
            throw new NotImplementedException();
        }

        public int ConvertHole(string holeValue)
        {
            var val = holeValue.Split(new [] { "Par" }, StringSplitOptions.None)[1];
            return int.Parse(val);
        }
    }
}