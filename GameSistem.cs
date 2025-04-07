namespace JogoTabuleiroConsole;

public class GameSistem
{
    private bool FimDeJogo { get; set; }
    private int ModJogador {get; set;}
    private int ModBot { get; set; }
    private int posicaoJogador  {get; set;}
    private int posicaoBot {get; set;}
    private Stack<bool> Turnos { get; set; }

    public void ComecarJogo()
    {
        Turnos = new Stack<bool>();

        for (int i = 0; i < 50; i++)
        {
            Turnos.Push(false); // Turno do Bot
            Turnos.Push(true); // Turno do Jogador
        }
            
        while (!FimDeJogo)
        {
            Tabuleiro.AttTabuleiro(posicaoJogador, posicaoBot,Turnos.Peek());
            ProcessarTurno();
        }
    }

    private int Rolar()
    {
        Random random = new Random();
        return random.Next(1, 7);
    }

    private int AddModJogador()
    {
        int mod = ModJogador;
        ModJogador = 0;
        return mod;
    }

    private int AddModBot()
    {
        int mod = ModBot;
        ModBot = 0;
        return mod;
    }
    

    private void ProcessarRolagem(bool turno)
    {
        int rolagem = Rolar();

        if (rolagem == 6)
            Turnos.Push(turno); // o jogador atual recebe mais um turno

        if(turno)
            posicaoJogador += (rolagem+AddModJogador());
        else
            posicaoBot += (rolagem+AddModBot());

        Console.WriteLine(modificadores(turno));
        
        if(VerificarFimDeJogo(turno))
            FimDeJogo = true;
        
    }

    private bool VerificarFimDeJogo(bool turno)
    {
        switch (turno)
        {
            case true when posicaoJogador >= 30:
                posicaoJogador = 30;
                Tabuleiro.AttFinal(posicaoJogador, posicaoBot);
                Console.WriteLine("\nParabens você venceu! :D");
                return true;
            case false when posicaoBot >= 30:
                posicaoBot = 30;
                Tabuleiro.AttFinal(posicaoJogador, posicaoBot);
                Console.WriteLine("\nHummm, não foi dessa vez! :(");
                return true;
            default:
                return false;
        }
    }

    private string modificadores(bool turno)
    {
        int posicao = turno ? posicaoJogador : posicaoBot;
        
        switch (posicao)
        {
            case 1:
                if (turno)
                {
                    ModJogador = 3;
                    return "Sua próxima rolagem vai receber +3";
                }
                else
                {
                    ModBot = 3;
                    return "O bot receberá +3 na próxima rolagem";
                }
            case 4:
                if (turno)
                {
                    ModJogador = 2;
                    return "Sua próxima rolagem vai receber +2";
                }
                else
                {
                    ModBot = 2;
                    return "O bot receberá +2 na próxima rolagem";
                }
            case 6:
                if (turno)
                {
                    ModJogador = 1;
                    return "Sua próxima rolagem vai receber +1";
                }
                else
                {
                    ModBot = 1;
                    return "O bot receberá +1 na próxima rolagem";
                }
            case 7:
                if (turno)
                {
                    ModJogador = -2;
                    return "Sua próxima rolagem vai receber -2";
                }
                else
                {
                    ModBot = -2;
                    return "O bot receberá -2 na próxima rolagem";
                }
            case 8:
                if (turno)
                {
                    Turnos.Push(turno);
                    return "Sua próxima rolagem vai receber UM TURNO EXTRA";
                }
                else
                {
                    Turnos.Push(turno);
                    return "O bot receberá UM TURNO EXTRA";
                }
            case 9:
                if (turno)
                {
                    ModJogador = -3;
                    return "Sua próxima rolagem vai receber -3";
                }
                else
                {
                    ModBot = -3;
                    return "O bot receberá 3 na próxima rolagem";
                }
            case 12:
                if (turno)
                {
                    posicaoJogador += 3;
                    return "Avance +3 casas";
                }
                else
                {
                    posicaoBot += 3;
                    return "O bot Avança +3 casas";
                }
            case 14:
                if (turno)
                {
                    posicaoJogador += 1;
                    return "Avance +1 casas";
                }
                else
                {
                    posicaoBot += 1;
                    return "O bot Avança +1 casas";
                }
            case 19:
                if (turno)
                {
                    Turnos.Push(!turno);
                    return "Perca seu próximo turno";
                }
                else
                {
                    Turnos.Push(!turno);
                    return "O bot perde o próximo turno";
                }
            case 21:
                if (turno)
                {
                    posicaoJogador -= 1;
                    return "volte uma casa";
                }
                else
                {
                    posicaoBot -= 1;
                    return "O bot volta uma casa";
                }
            case 25:
                if (turno)
                {
                    posicaoJogador -= 2;
                    return "volte duas casas";
                }
                else
                {
                    posicaoBot -= 2;
                    return "O bot volta duas casas";
                }
            case 26:
                if (turno)
                {
                    ModJogador = 1;
                    return "Sua próxima rolagem vai receber +1";
                }
                else
                {
                    ModBot = 1;
                    return "O bot receberá +1 na próxima rolagem";
                }
            default:
                return "";
        }
    }

    private void ProcessarTurno()
    {
        
        bool turno = Turnos.Pop();
        
        if (turno)
        {
            bool keypress = true;
            while (keypress)
            {
                if (Console.ReadKey().Key == ConsoleKey.R)
                {
                    keypress = false;
                }
            }
            ProcessarRolagem(turno);

        }
        else
        {
            ProcessarRolagem(turno);
            Console.ReadKey();
        }

    }

}