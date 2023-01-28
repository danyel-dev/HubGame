namespace Hub.Model
{
    public class Player
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; private set; }
        public int Victories { get; set; }

        public Player(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
            Victories = 0;
        }
    }
}
