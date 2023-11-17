namespace ArvoreAvl.src.Dtos;

public class Pessoa
{
    public string Nome { get; set; }
    public long Cpf { get; set; }
    public long Rg { get; set; }
    public string DataNascimento { get; set; }
    public string CidadeNascimento { get; set; }

    public override string ToString()
    {
        return $"[ Nome: {Nome} | CPF: {Cpf} | RG: {Rg} | Data de Nascimento: {DataNascimento} | Cidade: {CidadeNascimento} ]";
    }
}