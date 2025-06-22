using System.Security.Cryptography;

Console.Clear();

Console.WriteLine("Bem-vindo ao Surpresinha!\n");

const int QuantidadeNumerosPorSequencia = 6;
const int ValorMaximoNumero = 99;

bool continuar = true;

while (continuar)
{
    Console.WriteLine("--- Geração de sequências de números Aleatórios ---\n");

    int quantidadeSequencias;

    while (true)
    {
        Console.Write("Digite o número de sequências desejadas: ");

        string? entrada = Console.ReadLine()!;

        bool entradaValida = int.TryParse(entrada, out quantidadeSequencias);

        if (!entradaValida || quantidadeSequencias <= 0)
        {
            Console.WriteLine("Entrada inválida. Digite um número inteiro maior que 0.\n");
        }
        else
        {
            break;
        }
    }

    Console.WriteLine();

    int[][] listaSequencias = new int[quantidadeSequencias][];

    for (int indiceSequencia = 0; indiceSequencia < quantidadeSequencias; indiceSequencia++)
    {
        int[] sequenciaAtual = new int[QuantidadeNumerosPorSequencia];

        int indiceNumero = 0;
        while (indiceNumero < QuantidadeNumerosPorSequencia)
        {
            int numeroSorteado = RandomNumberGenerator.GetInt32(1, ValorMaximoNumero + 1);

            bool repetido = false;
            for (int i = 0; i < indiceNumero; i++)
            {
                if (sequenciaAtual[i] == numeroSorteado)
                {
                    repetido = true;
                    break;
                }
            }

            if (repetido)
            {
                continue;
            }

            sequenciaAtual[indiceNumero] = numeroSorteado;
            indiceNumero++;
        }

        Array.Sort(sequenciaAtual);

        listaSequencias[indiceSequencia] = sequenciaAtual;
    }

    Console.WriteLine("--- Sequência(s) Geradas ---\n");

    for (int sequencia = 0; sequencia < quantidadeSequencias; sequencia++)
    {
        Console.Write($"Sequência {sequencia + 1:D2}: ");
        for (int numero = 0; numero < QuantidadeNumerosPorSequencia; numero++)
        {
            Console.Write($"{listaSequencias[sequencia][numero]:D2}");
            if (numero < QuantidadeNumerosPorSequencia - 1)
                Console.Write(" - ");
        }
        Console.WriteLine();
    }

    Console.WriteLine();

    Console.Write("Deseja gerar novas sequências? (S): ");
    string? resposta = Console.ReadLine()!;

    if (string.IsNullOrWhiteSpace(resposta) || resposta.Trim().ToUpper() != "S")
    {
        continuar = false;
        Console.WriteLine("\nObrigado por usar o Surpresinha! Até mais!\n");
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Bem-vindo novamente ao Surpresinha!\n");
    }
}

