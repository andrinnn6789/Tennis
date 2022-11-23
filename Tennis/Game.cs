using System.Collections.Generic;

namespace Tennis
{
    public class Game
    {
        private readonly List<StateType> _players = new List<StateType>() {StateType.Love, StateType.Love};
        private readonly Score _score = new Score();

        public Score PlayGame(int player)
        { 
            if (player == 1)
                PlayPoint(0, 1);

            if (player == 2)
                PlayPoint(1, 0);

            if (!_score.GameIsFinished)
                _score.Text = _players[0] + "\t" + _players[1];

            return _score;
        }

        private void PlayPoint(int scoringPlayerIndex, int otherPlayerIndex)
        {
            if (HasScoringPlayerWon(scoringPlayerIndex, otherPlayerIndex))
            {
                _score.Text = "player " + (scoringPlayerIndex + 1) + " wins";
                _score.GameIsFinished = true;
            }
            else if (HasOtherPlayerAdvantage(scoringPlayerIndex, otherPlayerIndex))
            {
                _players[otherPlayerIndex]--;
            }
            else
            {
                _players[scoringPlayerIndex]++;
            }

        }

        private bool HasOtherPlayerAdvantage(int scoringPlayerIndex, int otherPlayerIndex)
        {
            return _players[scoringPlayerIndex] == StateType.Forty &&
                   _players[otherPlayerIndex] == StateType.Advantage;
        }

        private bool HasScoringPlayerWon(int scoringPlayerIndex, int otherPlayerIndex)
        {
            return _players[scoringPlayerIndex] == StateType.Advantage ||
                   (
                       _players[scoringPlayerIndex] == StateType.Forty &&
                       _players[otherPlayerIndex] != StateType.Forty &&
                       _players[otherPlayerIndex] != StateType.Advantage
                   );
        }
    }
}
