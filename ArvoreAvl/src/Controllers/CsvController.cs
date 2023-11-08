using System.Collections.Generic;
using System.IO;
using ArvoreAvl.src.Dtos;

namespace ArvoreAvl.src.Controllers;

public class CSVController
{
    /// <summary>
    /// Lê o arquivo CSV.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static IList<Pessoa> ReadCsv(string path)
    {
        IList<Pessoa> pessoas = new List<Pessoa>();

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

                pessoas.Add(pessoa);
            }
        }

        return pessoas;
    }

    public static void BuscaPessoaPeloCpf(IList<Pessoa> pessoas, long cpf)
    {
        foreach (Pessoa pessoa in pessoas)
        {
            if (pessoa.Cpf == cpf)
            {
                Console.WriteLine(pessoa.Nome);
                Console.WriteLine(pessoa.Cpf);
                Console.WriteLine(pessoa.Rg);
                Console.WriteLine(pessoa.DataNascimento);
                Console.WriteLine(pessoa.CidadeNascimento);
            }
        }
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
