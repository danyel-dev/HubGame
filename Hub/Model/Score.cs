
namespace Hub.Model
{
    public class Score
    {
        public int Wins { get; private set; } = 0;
        public int Defeats { get; private set; } = 0;
        public int Ties { get; private set; } = 0;
        public int Punctuation { get; private set; } = 0;


        public void AddWins()
        {
            Wins++;
            Punctuation += 2;
        }

        public void AddDefeats()
        {
            Defeats++;
            Punctuation -= 2;
        }

        public void AddTies()
        {
            Ties++;
            Punctuation++;
        }
    }
}
