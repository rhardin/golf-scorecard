using System;
using System.Collections.Generic;

namespace tests {
    public class Score {
        private Dictionary<string, int> scoreOperations;
        private int total = 0;

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

        public int Total => total;

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

        internal int Add(string holeValue, string playerScore)
        {
            total += Calculate(holeValue, playerScore);
            return total;
        }
    }
}