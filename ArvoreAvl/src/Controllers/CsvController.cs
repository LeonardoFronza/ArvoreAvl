using ArvoreAvl.src.Dtos;

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
        Console.WriteLine(pessoas[ArvoreCpf.Buscar(cpf).Index].ToString());
    }

    //ok
    public void BuscaPessoaPelaDataDeNascimento(DateOnly dataInicio, DateOnly dataFim)
    {
        IList<Node<DateOnly>> lista = new List<Node<DateOnly>>();
        ArvoreData.ImprimirArvore();

        lista = ArvoreData.BuscarDataNascimento(dataInicio, dataFim);

        foreach (var pessoa in lista)
        {
            Console.WriteLine(pessoas[pessoa.Index].ToString());
        }
    }

    //ok - Melhorar metodo do node para retonar uma lista de INT
    public void BuscaPessoaPeloNome(string nome)
    {
        ArvoreNome.ImprimirArvore();
        ArvoreNome.Buscar(nome).EmOrdem(pessoas, nome);
    }

    //ok
    public void ImprimirTodasAsArvores()
    {
        ArvoreNome.ImprimirArvore();
        ArvoreCpf.ImprimirArvore();
        ArvoreData.ImprimirArvore();
    }
}
