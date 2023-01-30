namespace Hub.Model
{
    class HubGame
    {
        public static List<Player> Players { get; private set; } = new();

        public static string Menu()
        {
            Console.WriteLine("|===<> HUB DE JOGOS <>===|\n");
            Console.WriteLine("1 - Batalha Naval");
            Console.WriteLine("2 - Jogo da Velha");
            Console.WriteLine("3 - Xadrez");

            Console.Write("\nEscolha uma das opção acima (ou '0' para sair): ");
            return Console.ReadLine();
        }

        public static void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public static int FindPlayer(string username)
        {
            return Players.FindIndex(player => player.Username == username);
        }
    }
}
