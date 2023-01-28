using Hub;

class Program
{
    public static void Main()
    {
        Console.Write("Informe o tamanho do Game: ");
        int ordemMatriz = int.Parse(Console.ReadLine());

        JogoDaVelha game = new(ordemMatriz);
        game.MainGame();
    }
}
