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
        public void ScoreCantBeLessThanZero(string hole, string playerScore) {
            var score = new Score();
            Assert.Throws<InvalidOperationException>(() => score.Calculate(hole, playerScore));
        }
    }

    public class Score {
        private Dictionary<string, int> scoreOperations;

        public Score() {
            //setup operations
            scoreOperations = new Dictionary<string, int>() {
                {"Condor", -4},
                {"Albatross", -3},
                {"Eagle", -2},
                {"Birdie", -1},
                {"Par", 0},
                {"Bogey", 1},
                {"Double", 2},
                {"Triple", 3}
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