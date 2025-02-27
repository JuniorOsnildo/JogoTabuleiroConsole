namespace JogoTabuleiroConsole;

public class Tabuleiro
{
    public static void AttTabuleiro(int posicaoJogador, int posicaoBot, bool turno)
    {
        Console.Clear();
        
        Console.Clear();
        Console.WriteLine("('-') <- Você -> posição: " + posicaoJogador);
        Console.WriteLine("[ò_ó] <- Bot -> posição: "+posicaoBot);
        Console.WriteLine();
        
        for (int i = 0; i < 31; i++)
        {
            Console.Write(posicaoBot == i ? "[ò_ó]" : "_");
            
        }
        
        Console.WriteLine();
        
        for (int i = 0; i < 31; i++)
        {
            Console.Write(posicaoJogador == i ? "('-')" : "_");
        }
        
        Console.WriteLine();
        Console.WriteLine();
        
        Console.WriteLine(turno
            ? "\nPrecione [R] para rolar o dano"
            : "\nTurno do Bot, precione qualquer tecla para continuar");
    }
    
    public static void AttFinal(int posicaoJogador, int posicaoBot)
    {
        
        for (int i = 0; i < 31; i++)
        {
            Console.Write(posicaoBot == i ? "[ò_ó]" : "_");
        }
        
        Console.WriteLine();
        
        for (int i = 0; i < 31; i++)
        {
            Console.Write(posicaoJogador == i ? "('-')" : "_");
        }
        
    }
}