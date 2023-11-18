using ArvoreAvl.src;
using ArvoreAvl.src.Controllers;
using ArvoreAvl.src.Dtos;

NodeController NodeController = new NodeController();

bool sair = true;
Console.WriteLine("Olá, seja bem vindo(a) ao programa de árvore AVL! ");

while (sair)
{
    Console.WriteLine(" ");
    Console.WriteLine("Menu: ");
    Console.WriteLine("1 - Inserir");
    Console.WriteLine("2 - Buscar");
    Console.WriteLine("3 - Remover");
    Console.WriteLine("4 - Mostrar arvore");
    Console.WriteLine("5 - Imprimir conforme caminhamento");
    Console.WriteLine("6 - Sair");
    Console.WriteLine(" ");

    string entrada = Console.ReadLine() ?? string.Empty;
    int.TryParse(entrada, out int opcao);

    switch (opcao)
    {
        case 1:
            bool sairInserir = true;
            while (sairInserir)
            {
                Console.WriteLine("Digite os valores a serem inseridos separados por vírgula (ex: 1,2,3): ");
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (!string.IsNullOrEmpty(input))
                {
                    string[] valores = input.Split(',');

                    foreach (string valorStr in valores)
                    {
                        if (int.TryParse(valorStr, out int valor))
                        {
                            NodeController.Inserir(valor);
                        }
                        else
                        {
                            Console.WriteLine($"Ignorando valor inválido: {valorStr}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida.");
                }

                Console.WriteLine("Deseja adicionar mais números? (S/N)");
                string resposta = Console.ReadLine()?.Trim().ToUpper() ?? string.Empty;
                if (resposta != "S" || resposta is null)
                {
                    sairInserir = false;
                }
            }
            break;
        case 2:
            Console.WriteLine("Digite o valor a ser buscado: ");
            int valorBusca = Convert.ToInt32(Console.ReadLine());
            NodeController.Buscar(valorBusca);
            break;
        case 3:
            Console.WriteLine("Digite o valor a ser removido: ");
            int valorARemover = Convert.ToInt32(Console.ReadLine());
            NodeController.Remover(valorARemover);
            NodeController.ImprimirArvore();
            break;
        case 4:
            NodeController.ImprimirArvore();
            break;
        case 5:
            Console.WriteLine("Digite o tipo de caminhamento: ");
            Console.WriteLine("1 - Pre Ordem");
            Console.WriteLine("2 - Pos Ordem");
            Console.WriteLine("3 - Em Ordem");
            int tipoCaminhamento = Convert.ToInt32(Console.ReadLine());
            NodeController.BuscaCaminhamento(tipoCaminhamento);
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