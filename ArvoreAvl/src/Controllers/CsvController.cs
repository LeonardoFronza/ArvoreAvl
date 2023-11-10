using System.Collections.Generic;
using System.IO;
using System.Linq;
using ArvoreAvl.src.Dtos;

namespace ArvoreAvl.src.Controllers;

public class CSVController
{
    public  NodeController<string> ArvoreNome = new NodeController<string>();
    public  NodeController<long> ArvoreCpf = new NodeController<long>();
    public  NodeController<string> ArvoreData = new NodeController<string>();
    IList<Pessoa> pessoas = new List<Pessoa>();

    /// <summary>
    /// Lê o arquivo CSV.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public IList<Pessoa> ReadCsv(string path)
    {
        int i=0;
        using (var reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line?.Split(';');

                Pessoa pessoa = new Pessoa();
                pessoa.Cpf = long.Parse(values?[0]);
                pessoa.Rg = long.Parse(values[1]);
                pessoa.Nome = values?[2];
                pessoa.DataNascimento = values?[3];
                pessoa.CidadeNascimento = values?[4];

                ArvoreNome.Inserir(pessoa.Nome, i);
                ArvoreCpf.Inserir(pessoa.Cpf, i);
                ArvoreData.Inserir(pessoa.DataNascimento, i++);
                pessoas.Add(pessoa);
            }
        }

        return pessoas;
    }

    public void testeImpressao()
    {
        ArvoreNome.ImprimirArvore();
    }

    public void BuscaPessoaPeloCpf(long cpf)
    {
        ArvoreCpf.ImprimirArvore();
        Console.WriteLine(pessoas[ArvoreCpf.Buscar(cpf).Index].ToString());
    }

    public void BuscaPessoaPelaDataDeNascimento(string data)
    {
        ArvoreData.ImprimirArvore();
        Console.WriteLine(pessoas[ArvoreData.Buscar(data).Index].ToString());
    }

    public void BuscaPessoaPeloNome(string nome)
    {
        ArvoreNome.ImprimirArvore();
        foreach(int number in ArvoreNome.Buscar(nome).EmOrdem(nome))
        {
            Console.WriteLine(pessoas[number].ToString());
        }
        ;
    }

    public static void BuscaPessoaPorChave(IList<Pessoa> pessoas, string palavra)
    {
        if (pessoas is null)
        {
            Console.WriteLine("Não há pessoas cadastradas");
            return;
        }

        foreach (Pessoa pessoa in pessoas)
        {
            if (pessoa.Nome.Contains(palavra))
            {
                int count = 1;
                Console.WriteLine(count++ + "° Pessoa com Nome:" + pessoa.Nome + " CPF: " + pessoa.Cpf + " RG: " + pessoa.Rg + " Data de Nascimento: " + pessoa.DataNascimento + " Cidade Natal: " + pessoa.CidadeNascimento);
            }
        }
    }
}
