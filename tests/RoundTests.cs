using Xunit;

namespace tests {
    public class RoundTests {
        [Fact]
        public void CanAddPlayer() {
            var round = new Round();
            round.AddPlayer("Rob");
            Assert.True(round.ContainsPlayer("Rob"));
        }

        [Fact]
        public void CanGetAScoreForAPlayer() {
            var round = new Round();
            round.AddPlayer("Rob");
            round.Score("Rob", "Par4", "Par");
            Assert.Equal(4, round.GetScoreFor("Rob"));
        }

        [Fact]
        public void CanScoreAGroupOnAHole() {
            var round = new Round();
            round.AddPlayer("Joe");
            round.AddPlayer("Bob");
            
            round.Score("Joe", "Par4", "Par");
            round.Score("Bob", "Par4", "Birdie");

            Assert.Equal(4, round.GetScoreFor("Joe"));
            Assert.Equal(3, round.GetScoreFor("Bob"));
        }
    }
}