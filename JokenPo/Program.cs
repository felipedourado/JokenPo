// See https://aka.ms/new-console-template for more information
Console.WriteLine("Bem vindo ao JankenPo!");

var sinais = new List<string> { "pedra", "papel", "tesoura" };

//pedra empata com pedra, pedra perde papel, pedra vence tesoura
//papel vence pedra, papel empata papel, papel perde tesoura
//tesoura perde pedra, tesoura vence papel, tesoura empata tesoura
string[,] matrizDecisao = new string[,]
{
    { "e", "p", "v"},
    { "v", "e", "p"},
    { "p", "v", "e"},
};

var resultado = new Dictionary<string, string>
{
    {"e","empatou!" },
    {"v","venceu!" },
    {"p","perdeu!" }
};

string msgResultado = "Jogador inseriu: {input} - Pc inseriu: {pc} - Resultado: Você {resultadoFinal}";

Console.WriteLine("Digite um dos sinais para jogar! (pedra, papel, tesoura)");
Console.WriteLine("Ou digite sair para encerrar");

while (true)
{
    var input = Console.ReadLine()!.ToLower();

    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Digite um dos sinais para jogar! (pedra, papel, tesoura)");
        continue;
    }

    if (input!.Equals("sair"))
        break;
   
    if(!BuscarItemNaLista(input))
    {
        Console.WriteLine("Sinal inválido!");
        continue;
    }
    
    GerarJogada(input);
}

bool BuscarItemNaLista(string input)
{
    for (int i = 0; i < sinais.Count; i++)
    {
        if (sinais[i].Equals(input))
            return true;
    }

    return false;
}

void GerarJogada(string input)
{
    var random = new Random();
    var jogadaPc = sinais[random.Next(sinais.Count)];
    msgResultado = msgResultado.Replace("{input}", input).Replace("{pc}", jogadaPc);
    //outras maneiras
    //var randomValue = DateTime.Now.Ticks;
    // Usar o valor de ticks para gerar um índice aleatório
    //var index = (int)(randomValue % sinais.Count);
    //var jogadaPc = sinais[index];
    //ou
    //var randomValue = Guid.NewGuid().GetHashCode();
    // Usar o valor gerado para acessar um índice aleatório
    //var index = Math.Abs(randomValue) % sinais.Count;
    //var jogadaPc = sinais[index];

    var indiceJogador = input.IndexOf(input);
    var indicePc = jogadaPc.IndexOf(jogadaPc);

    VerificarResultado(indiceJogador, indicePc);

}

void VerificarResultado(int jogador, int pc)
{
    var decididoResultado = matrizDecisao[jogador, pc];
    var resultadoFinal = resultado[decididoResultado];
    msgResultado = msgResultado.Replace("{resultadoFinal}", resultadoFinal);
    Console.WriteLine(msgResultado);
}



