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

    public void Remover(T value)
    {
        if (root is null)
        {
            return;
        }

        root = root.Remover(value);
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
        //root.PrintTree(nodeBusca);
    }

        public Node<T> BuscarPessoa(T value)
    {
        Node<T> nodeBusca;
        if (root is null)
        {
            return null;
        }
        nodeBusca = root.Buscar(value);

        return nodeBusca;
        //root.PrintTree(nodeBusca);
    }

    /// <summary>
    /// Busca caminhamento na arvore
    /// </summary>
    /// <param name="value"></param>
    public void BuscaCaminhamento(int value, string teste)
    {
        if (root is null)
        {
            return;
        }

        switch (value)
        {
            case 1:
                root.PreOrdem();
                break;
            case 2:
                root.PosOrdem();
                break;
            case 3:
                root.EmOrdem(teste);
                break;
        }
    }

    /// <summary>
    /// Mostra a arvore
    /// </summary>
    /// <param name="node"></param>
    /// <param name="prefix"></param>
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
