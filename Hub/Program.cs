using Hub.Model;

class Program
{
    public static int SetPlayer()
    {
        Console.Write("Digite seu nome de usuário: ");
        string username = Console.ReadLine();

        Console.Write("Digite sua senha: ");
        string password = Console.ReadLine();

        return HubGame.FindPlayer(username);
    }

    public static void Main()
    {
        int playerOneIndice = -1, playerTwoIndice = -1;

        while (true)
        {
            if (playerOneIndice == -1 && playerTwoIndice == -1)
            {
                while (true)
                {
                    Console.WriteLine("1 - Entrar no Hub de Games");
                    Console.WriteLine("2 - Criar uma conta");
                    Console.WriteLine("0 - Sair\n");
                    Console.Write("Informe o número da sua opção: ");

                    string optionMenuInitial = Console.ReadLine();

                    Console.Clear();

                    switch (optionMenuInitial)
                    {
                        case "0":
                            break;
                        case "1":
                            Console.WriteLine("== Player 1 ==");
                            playerOneIndice = SetPlayer();

                            Console.WriteLine();

                            Console.WriteLine("== Player 2 ==");
                            playerTwoIndice = SetPlayer();

                            optionMenuInitial = "0";
                            Console.Clear();

                            break;
                        case "2":
                            Console.WriteLine("|| CADASTRO DE JOGADOR ||\n");

                            Console.Write("Informe seu nome completo: ");
                            string full_name = Console.ReadLine();

                            Console.Write("Agora nos informe um nome de usuário: ");
                            string username = Console.ReadLine();

                            Console.Write("Faça uma senha: ");
                            string password = Console.ReadLine();

                            Player player = new(full_name, username, password);

                            HubGame.AddPlayer(player);

                            Console.Clear();
                            Console.WriteLine("Jogador cadastrado com sucesso!\n");

                            break;
                        default:
                            Console.WriteLine("Opção incorreta, por favor preste atenção nas opções válidas abaixo.\n");
                            break;
                    }

                    if (optionMenuInitial == "0")
                        break;
                }
            }

            else
            {
                while (true)
                {
                    string optionMenuGames = HubGame.Menu();

                    Player playerOne = HubGame.Players[playerOneIndice];
                    Player playerTwo = HubGame.Players[playerTwoIndice];

                    Console.Clear();

                    switch (optionMenuGames)
                    {
                        case "0":
                            Console.WriteLine("Obrigado por se divertir com nosso hub de jogos ;)\n");
                            playerOneIndice = -1;
                            playerTwoIndice = -1;
                            break;
                        case "1":
                            Console.WriteLine("Este jogo ainda não foi implementado\n");
                            break;
                        case "2":
                            Console.Write("Informe o tamanho do Game: ");
                            int matrixOrder = int.Parse(Console.ReadLine());

                            JogoDaVelha game = new(matrixOrder, playerOne, playerTwo);
                            int winner = game.MainGame();

                            if (winner == 1)
                            {
                                HubGame.Players[playerOneIndice].ScoreJogoDaVelha.AddWins();
                                HubGame.Players[playerTwoIndice].ScoreJogoDaVelha.AddDefeats();
                            }
                            if (winner == 2)
                            {
                                HubGame.Players[playerTwoIndice].ScoreJogoDaVelha.AddWins();
                                HubGame.Players[playerOneIndice].ScoreJogoDaVelha.AddDefeats();
                            }
                            if (winner == 0)
                            {
                                HubGame.Players[playerOneIndice].ScoreJogoDaVelha.AddTies();
                                HubGame.Players[playerTwoIndice].ScoreJogoDaVelha.AddTies();
                            }

                            Console.Write("Aperte qualquer tecla para continuar... ");
                            Console.ReadKey();

                            Console.Clear();
                            break;
                        case "3":
                            Console.WriteLine("Este jogo ainda não foi implementado\n");
                            break;
                        case "4":
                            HubGame.Players[playerOneIndice].ShowScoreJogoDaVelha();
                            HubGame.Players[playerTwoIndice].ShowScoreJogoDaVelha();
                            break;
                        default:
                            Console.WriteLine("- Opção não encontrada, por favor olhe com mais atenção as opções listadas abaixo\n");
                            break;
                    }

                    if (optionMenuGames == "0")
                        break;
                }
            }
        }
    }
}
