namespace ArvoreAvl.src.Dtos;

public class Pessoa : IComparable<Pessoa>
{
    public string Nome { get; set; }
    public long Cpf { get; set; }
    public long Rg { get; set; }
    public string DataNascimento { get; set; }
    public string CidadeNascimento { get; set; }

    public int CompareTo(Pessoa? other)
    {
         if (other == null) return 1;
        return this.Nome.CompareTo(other.Nome);
    }

    public string ToString()
    {
        return Nome+"/"+Cpf+"/"+DataNascimento;
    }
}