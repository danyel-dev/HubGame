
namespace Hub
{
    public class Player
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; private set; }
        public int Victories { get; set; }

        public Player(string name, string username, string password) {
            this.Name = name;
            this.Username = username; 
            this.Password = password;
            this.Victories = 0;
        }
    }
}
