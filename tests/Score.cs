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
            int result = 0, val = 0;
            if (scoreOperations.ContainsKey(playerScore)) { 
                result = ConvertHole(holeValue) + scoreOperations[playerScore]; 
            }
            else if (int.TryParse(playerScore, out val)) { 
                result = ConvertHole(holeValue) + val; 
            }
            else { 
                throw new ArgumentException(); 
            }
            
            if (result < 0) { throw new InvalidOperationException("A score cannot result in a value less than 0"); }

            return result;
        }

        public int ConvertHole(string holeValue)
        {
            if (!holeValue.Contains("Par") || holeValue.ToLower() == "par") { 
                throw new ArgumentException("holeValue must be in the format of ParX"); 
            }
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