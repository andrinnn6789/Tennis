using Tennis;
using Xunit;

namespace TennisTest
{
    public class GameTest
    {
        [Theory]
        [InlineData("player 1 wins", true, 1, 1, 1, 1)]
        [InlineData("player 2 wins", true, 2, 2, 2, 2)]
        [InlineData("Thirty\tThirty", false, 1, 1, 2, 2)]
        [InlineData("Forty\tAdvantage", false, 1, 1, 1, 2, 2, 2, 2)]
        [InlineData("Forty\tForty", false, 1, 1, 1, 2, 2, 2, 2, 1)]
        [InlineData("player 1 wins", true, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1)]
        public void Test1(string expectedText, bool expectedIsFinished, params int[] scoringPlayers)
        {
            // Arrange
            var game = new Game();
            var score = new Score();

            // Act
            foreach (var scoringPlayer in scoringPlayers)
                score = game.PlayGame(scoringPlayer);

            // Assert
            Assert.Equal(expectedText, score.Text);
            Assert.Equal(expectedIsFinished, score.GameIsFinished);
        }
    }
}