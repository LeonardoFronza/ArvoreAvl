using ArvoreAvl.src.Dtos;
using ArvoreAvl.src.Utils;

namespace ArvoreAvl.src.Controllers;

public class CSVController
{
    public NodeController<string> ArvoreNome = new NodeController<string>();
    public NodeController<long> ArvoreCpf = new NodeController<long>();
    public NodeController<DateOnly> ArvoreData = new NodeController<DateOnly>();
    IList<Pessoa> pessoas = new List<Pessoa>();

    /// <summary>
    /// Lê o arquivo CSV.
    /// </summary>
    public IList<Pessoa> ReadCsv(string path)
    {
        int i = 0;

        if (!File.Exists(path)) throw new Exception("Arquivo não encontrado. No diretório: " + path + "");

        using (var reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line?.Split(';');

                if (values == null || values.Length <= 3) continue;

                if (!long.TryParse(values[0], out var cpf) ||
                    !long.TryParse(values[1], out var rg)) continue;

                Pessoa pessoa = new Pessoa
                {
                    Cpf = cpf,
                    Rg = rg,
                    Nome = values[2],
                    DataNascimento = values[3],
                    CidadeNascimento = values[4]
                };

                ArvoreNome.Inserir(pessoa.Nome, i);
                ArvoreCpf.Inserir(pessoa.Cpf, i);
                ArvoreData.Inserir(ValidadorDeData.ConversorStringInDateOnly(pessoa.DataNascimento), i++);
                pessoas.Add(pessoa);
            }
        }

        return pessoas;
    }

    //ok
    public void BuscaPessoaPeloCpf(long cpf)
    {
        ArvoreCpf.ImprimirArvore();
        Console.WriteLine(" ");
        Node<long> node = ArvoreCpf.Buscar(cpf);

        if (node is null)
        {
            Console.WriteLine("Não foi encontrada nenhuma pessoa com o CPF informado. Tente novamente.");
            return;
        }

        Console.WriteLine(pessoas[node.Index].ToString());
    }

    //ok
    public void BuscaPessoaPelaDataDeNascimento(DateOnly dataInicio, DateOnly dataFim)
    {
        IList<Node<DateOnly>> lista = new List<Node<DateOnly>>();
        ArvoreData.ImprimirArvore();
        Console.WriteLine(" ");
        lista = ArvoreData.BuscarDataNascimento(dataInicio, dataFim);

        if (!lista.Any())
        {
            Console.WriteLine("Não foi encontrada nenhuma pessoa com a data de nascimento informada. Tente novamente.");
            return;
        }

        foreach (var pessoa in lista)
        {
            Console.WriteLine(pessoas[pessoa.Index].ToString());
        }
    }

    //ok
    public void BuscaPessoaPeloNome(string nome)
    {
        ArvoreNome.ImprimirArvore();
        Console.WriteLine(" ");
        IList<Node<string>> busca = ArvoreNome.EmOrdem(nome);
        if (!busca.Any())
        {
            Console.WriteLine("Não foi encontrada nenhuma pessoa com o nome informado. Tente novamente.");
            return;
        }

        foreach (var pessoa in busca)
        {
            Console.WriteLine(pessoas[pessoa.Index].ToString());
        }

    }

    //ok
    public void ImprimirTodasAsArvores()
    {
        ArvoreNome.ImprimirArvore();
        ArvoreCpf.ImprimirArvore();
        ArvoreData.ImprimirArvore();
    }

    //ok
    public bool VerificaSePossuiPessoasNaLista()
    {
        return pessoas.Any();
    }
}
