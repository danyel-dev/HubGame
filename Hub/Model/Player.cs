namespace Hub.Model
{
    public class Player
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; private set; }
        public Score ScoreJogoDaVelha { get; private set; } = new Score();

        public Player(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
        }

        public void ShowScoreJogoDaVelha()
        {
            Console.WriteLine($"<== Player: {Name} ==>\n");
            Console.WriteLine($"| Número de vitórias: {ScoreJogoDaVelha.Wins}");
            Console.WriteLine($"| Número de derrotas: {ScoreJogoDaVelha.Defeats}");
            Console.WriteLine($"| Número de empates: {ScoreJogoDaVelha.Ties}");
            Console.WriteLine($"| Pontuação: {ScoreJogoDaVelha.Punctuation}\n");
        }
    }
}
