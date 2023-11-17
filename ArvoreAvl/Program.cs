using ArvoreAvl.src.Controllers;
using ArvoreAvl.src.Utils;

CSVController Utils = new CSVController();

bool sair = true;
Console.WriteLine("Olá, seja bem vindo(a) ao programa de árvore AVL! ");
Console.WriteLine(" ");
while (sair)
{
    string entrada;
    int opcao = 0;
    do
    {
        if (!Utils.VerificaSePossuiPessoasNaLista())
        {
            entrada = "1";
        }
        else
        {
            Console.WriteLine(" ");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1 - Pega dados arquivo CSV");
            Console.WriteLine("2 - Buscar por nome");
            Console.WriteLine("3 - Buscar por cpf");
            Console.WriteLine("4 - Buscar por Data de Nascimento");
            Console.WriteLine("5 - Imprimir todas as árvores");
            Console.WriteLine("6 - Sair");
            Console.WriteLine(" ");

            Console.Write("Digite a opção desejada: ");
            entrada = Console.ReadLine() ?? string.Empty;
            Console.WriteLine(" ");
        }

        if (!int.TryParse(entrada, out opcao))
        {
            Console.WriteLine("Por favor, insira um número válido.");
        }
    } while (!int.TryParse(entrada, out opcao));

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Digite o caminho do arquivo que vai ser importado: ");
            string path = Console.ReadLine();

            Utils.ReadCsv(path);

            Console.WriteLine("Pessoas importadas com sucesso!");
            break;
        case 2:
            Console.WriteLine("Digite o nome a ser buscado: ");
            string nome = Console.ReadLine();
            Utils.BuscaPessoaPeloNome(nome.ToUpper());

            break;
        case 3:
            Console.WriteLine("Digite o cpf da pessoa a ser buscada: ");
            string cpf = Console.ReadLine();

            while (!long.TryParse(cpf, out long cpfNumerico))
            {
                Console.WriteLine("CPF inválido. Por favor, digite apenas números.");
                cpf = Console.ReadLine();
            }
            Utils.BuscaPessoaPeloCpf(long.Parse(cpf));
            break;
        case 4:
            Console.Write("Digite a data de início da busca (dd/mm/yyyy): ");
            string dataInicio = Console.ReadLine();
            while (!ValidadorDeData.VerificaSeDataEhValida(dataInicio))
            {
                Console.Write("Data inválida. Digite novamente a data de início da busca (dd/mm/yyyy): ");
                dataInicio = Console.ReadLine();
            }

            Console.Write("Digite a data de final da busca (dd/mm/yyyy): ");
            string dataFim = Console.ReadLine();
            while (!ValidadorDeData.VerificaSeDataEhValida(dataFim))
            {
                Console.Write("Data inválida. Digite novamente a data de final da busca (dd/mm/yyyy): ");
                dataFim = Console.ReadLine();
            }

            Utils.BuscaPessoaPelaDataDeNascimento(DateOnly.ParseExact(dataInicio, "dd/MM/yyyy", null), DateOnly.ParseExact(dataFim, "dd/MM/yyyy", null));
            break;
        case 5:
            Utils.ImprimirTodasAsArvores();
            break;
        case 6:
            Console.WriteLine("Saindo...");
            sair = false;
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}