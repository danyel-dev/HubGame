namespace Hub.Model
{
    class HubGame
    {
        public static List<Player> Players { get; set; } = new();

        public static void AddPlayer(Player player)
        {
            Players.Add(player);
        }
    }
}
