using ArvoreAvl.src.Controllers;
using ArvoreAvl.src.Dtos;


CSVController Utils = new CSVController();
IList<Pessoa> Pessoas = new List<Pessoa>();

bool sair = true;
Console.WriteLine("Olá, seja bem vindo(a) ao programa de árvore AVL! ");

while (sair)
{
    Console.WriteLine(" ");
    Console.WriteLine("Menu: ");
    Console.WriteLine("1 - Pega dados arquivo CSV");
    Console.WriteLine("2 - Buscar por nome");
    Console.WriteLine("3 - Buscar por cpf");
    Console.WriteLine("4 - Buscar por Data de Nascimento");
    Console.WriteLine("5 - Imprimir conforme caminhamento");
    Console.WriteLine(" ");

    string entrada = Console.ReadLine() ?? string.Empty;
    int.TryParse(entrada, out int opcao);

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Digite o caminho do arquivo que vai ser importado: ");
            string path = Console.ReadLine();

            Pessoas = Utils.ReadCsv(path);

            Console.WriteLine("Pessoas importadas com sucesso!");
            break;
        case 2:
            Utils.BuscaPessoaPeloNome("Cicrana Beltrana Delgrana");

            break;
        case 3:
            Utils.BuscaPessoaPeloCpf(12345678910);
            break;
        case 4:
            Utils.BuscaPessoaPelaDataDeNascimento("01/02/1958");
            break;
        case 5:
            Utils.testeImpressao();
            break;
        case 6:

            break;
        case 7:
            Console.WriteLine("Saindo...");
            sair = false;
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}