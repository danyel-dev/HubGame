using Hub.Model;

class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("|===<> HUB DE JOGOS <>===|\n");
            Console.WriteLine("1 - Batalha Naval");
            Console.WriteLine("2 - Jogo da Velha");
            Console.WriteLine("3 - Xadrez");

            Console.Write("\nEscolha uma das opção acima (ou '0' para sair): ");
            string optionMenuGames = Console.ReadLine();

            Console.Clear();

            switch (optionMenuGames)
            {
                case "0":
                    Console.WriteLine("Obrigado por se divertir com nosso hub de jogos ;)\n");
                    break;
                case "1":
                    Console.WriteLine("Este jogo ainda não foi implementado\n");
                    break;
                case "2":
                    Console.Write("Informe o tamanho do Game: ");
                    int matrixOrder = int.Parse(Console.ReadLine());

                    JogoDaVelha game = new(matrixOrder);
                    game.MainGame();

                    Console.Clear();
                    break;
                case "3":
                    Console.WriteLine("Este jogo ainda não foi implementado\n");
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
