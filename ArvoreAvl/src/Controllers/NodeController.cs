using ArvoreAvl.src.Dtos;

namespace ArvoreAvl.src.Controllers;

public class NodeController<T> where T : IComparable<T>
{
    /// <summary>
    /// Raiz da arvore
    /// </summary>
    private Node<T> root;

    /// <summary>
    /// Cria a raiz da arvore
    /// </summary>
    private void CriarArvore(T value, int index)
    {
        if (root is null)
        {
            root = new Node<T>(value, index);
        }
    }

    /// <summary>
    /// Insere um item na arvore
    /// </summary>
    public Node<T> Inserir(T value, int index)
    {
        CriarArvore(value, index);

        if (root is not null)
        {
            root.Validator3000(value, index);
        }

        return root;
    }

    /// <summary>
    /// Busca um item na arvore
    /// </summary>
    public Node<T> Buscar(T value)
    {
        Node<T> nodeBusca;
        if (root is null)
        {
            return null;
        }
        nodeBusca = root.Buscar(value);

        return nodeBusca;
    }

    public void EmOrdem(IList<Pessoa> pessoa, string pesquisa)
    {
        root.EmOrdem(pessoa, pesquisa);
    }

    /// <summary>
    /// Busca elementos em um intervalo de dados.
    /// </summary>
    public IList<Node<T>> BuscarDataNascimento(T value, T value2)
    {
        IList<Node<T>> nodeBusca = new List<Node<T>>();
        if (root is null)
        {
            return null;
        }

        nodeBusca = root.BuscarNoIntervaloDeDados(nodeBusca, value, value2);
        return nodeBusca;
    }

    /// <summary>
    /// Mostra a arvore
    /// </summary>
    public void ImprimirArvore()
    {
        if (root != null)
        {
            Console.WriteLine("Árvore AVL:");
            root.PrintTree(root);
        }
        else
        {
            Console.WriteLine("A árvore está vazia.");
        }
    }

}
