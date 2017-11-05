using System;
using System.Collections.Generic;

namespace tests
{
    public class Round
    {
        private Dictionary<string, Score> round;

        public Round() => round = new Dictionary<string, Score>();

        public void AddPlayer(string name) {
            if (round.ContainsKey(name)) { throw new InvalidOperationException("A player with that name already exists"); }
            round.Add(name, new Score());
        }

        public bool ContainsPlayer(string name) {
            return round.ContainsKey(name);
        }

        public void Score(string player, string hole, string score) {
            round[player].Add(hole, score);
        }

        public int GetScoreFor(string player) {
            return round[player].Total;
        }
    }
}