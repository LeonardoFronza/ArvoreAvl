namespace ArvoreAvl.src.Dtos;

public class Node<T> where T : IComparable<T>
{
    /// <summary>
    /// Construtor.
    /// </summary>
    public Node(T id, int index)
    {
        Id = id;
        Index = index;
    }

    /// <summary>
    /// Id.
    /// </summary>
    public T Id { get; set; }

    public int Index { get; set; }

    /// <summary>
    /// Esquerda.
    /// </summary>
    public Node<T> Esquerda { get; set; }

    /// <summary>
    /// Direita.
    /// </summary>
    public Node<T> Direita { get; set; }

    /// <summary>
    /// Fator de balanceamento.
    /// </summary>
    public int BFactor { get; set; }

    /// <summary>
    /// Valida os itens a serem inseridos.
    /// </summary>
    public void Validator3000(T dado, int index)
    {
        if (Id.CompareTo(dado) == 0 && index != Index)
        {
            Validator6000(dado, index, index < Index);
        }

        if (Id.CompareTo(dado) > 0)
        {
            Validator6000(dado, index, true);
        }
        else if (Id.CompareTo(dado) < 0)
        {
            Validator6000(dado, index, false);
        }

        AtualizarBFactor();
        Balancear();
    }

    /// <summary>
    /// Valida os itens a serem inseridos.
    /// </summary>
    private void Validator6000(T dado, int index, bool isLeft)
    {
        Node<T> node = isLeft ? Esquerda : Direita;

        if (node is null)
        {
            node = new Node<T>(dado, index);
            if (isLeft)
            {
                Esquerda = node;
            }
            else
            {
                Direita = node;
            }
        }
        else
        {
            node.Validator3000(dado, index);
        }
    }

    /// <summary>
    /// Calcula a altura da arvore. Para calcular fator de balanceamento.
    /// </summary>
    private int Altura(Node<T> node)
    {
        if (node is null)
        {
            return 0;
        }

        int alturaEsquerda = Altura(node.Esquerda);
        int alturaDireita = Altura(node.Direita);

        return Math.Max(alturaEsquerda, alturaDireita) + 1;
    }

    /// <summary>
    /// Calcula o fator de balanceamento.
    /// </summary>
    public void AtualizarBFactor()
    {
        int alturaEsquerda = Altura(Esquerda);
        int alturaDireita = Altura(Direita);

        BFactor = alturaEsquerda - alturaDireita;
    }

    /// <summary>
    /// Realiza o balanceamento da arvore.
    /// </summary>
    public void Balancear()
    {
        if (BFactor > 1)
        {
            if (Esquerda.BFactor >= 0)
            {
                RotacaoDireita();
            }
            else
            {
                Esquerda.RotacaoEsquerda();
                RotacaoDireita();
            }
        }
        else if (BFactor < -1)
        {
            if (Direita.BFactor <= 0)
            {
                RotacaoEsquerda();
            }
            else
            {
                Direita.RotacaoDireita();
                RotacaoEsquerda();
            }
        }
    }

    /// <summary>
    /// Realiza a rotação para a direita.
    /// </summary>
    private void RotacaoDireita()
    {
        Node<T> novo = new Node<T>(Id, Index)
        {
            Direita = Direita,
            Esquerda = Esquerda.Direita
        };
        Direita = novo;
        Id = Esquerda.Id;
        Index = Esquerda.Index;
        Esquerda = Esquerda.Esquerda;
        AtualizarBFactor();
    }

    /// <summary>
    /// Realiza a rotação para a esquerda.
    /// </summary>
    private void RotacaoEsquerda()
    {
        Node<T> novo = new Node<T>(Id, Index)
        {
            Esquerda = Esquerda,
            Direita = Direita.Esquerda
        };
        Esquerda = novo;
        Id = Direita.Id;
        Index = Direita.Index;
        Direita = Direita.Direita;
        AtualizarBFactor();
    }

    /// <summary>
    /// Busca elemento na arvore.
    /// </summary>
    public Node<T> Buscar(T value)
    {
        if (Id.ToString().StartsWith(value.ToString()))
        {
            return this;
        }
        else if (Id.CompareTo(value) > 0 && Esquerda != null)
        {
            return Esquerda.Buscar(value);
        }
        else if (Id.CompareTo(value) < 0 && Direita != null)
        {
            return Direita.Buscar(value);
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Busca elementos em um intervalo de dados.
    /// </summary>
    public IList<Node<T>> BuscarNoIntervaloDeDados(IList<Node<T>> nodes, T value, T value2)
    {
        if (Esquerda != null && value.CompareTo(Id) <= 0)
        {
            Esquerda.BuscarNoIntervaloDeDados(nodes, value, value2);
        }

        if (value.CompareTo(Id) <= 0 && value2.CompareTo(Id) >= 0)
        {
            nodes.Add(this);
        }

        if (Direita != null && value2.CompareTo(Id) >= 0)
        {
            Direita.BuscarNoIntervaloDeDados(nodes, value, value2);
        }

        return nodes;
    }

    /// <summary>
    /// Mostra os itens da arvore em ordem.
    /// </summary>
    public void EmOrdem(IList<Pessoa> pessoa, string pesquisa)
    {
        if (Esquerda is not null)
        {
            Esquerda.EmOrdem(pessoa, pesquisa);
        }

        if (Id.ToString().StartsWith(pesquisa))
        {
            Console.WriteLine(pessoa[Index].ToString());
        }

        if (Direita is not null)
        {
            Direita.EmOrdem(pessoa, pesquisa);
        }

    }

    /// <summary>
    /// Remove um item da arvore.
    /// </summary>
    public Node<T> Remover(T valor)
    {
        if (Id.CompareTo(valor) < 0)
        {
            if (Esquerda != null)
            {
                Esquerda = Esquerda.Remover(valor);
                AtualizarBFactor();
                Balancear();
            }
        }
        else if (Id.CompareTo(valor) > 0)
        {
            if (Direita != null)
            {
                Direita = Direita.Remover(valor);
                AtualizarBFactor();
                Balancear();
            }
        }
        else
        {
            if (Esquerda == null && Direita == null)
            {
                return null;
            }
            else if (Esquerda == null)
            {
                return Direita;
            }
            else if (Direita == null)
            {
                return Esquerda;
            }
            else
            {
                Node<T> sucessor = EncontrarMaiorNode(Esquerda);
                Id = sucessor.Id;
                Esquerda = Esquerda.Remover(sucessor.Id);
                AtualizarBFactor();
                Balancear();
            }
        }

        return this;
    }

    private Node<T> EncontrarMaiorNode(Node<T> node)
    {
        while (node.Direita != null)
        {
            node = node.Direita;
        }
        return node;
    }

    /// <summary>
    /// Imprime a arvore.
    /// </summary>
    public void PrintTree(Node<T> node, string prefix = "")
    {
        if (node == null)
            return;

        bool isLeaf = (node.Esquerda == null && node.Direita == null);
        string nodeType = isLeaf ? "F" : "P"; // P para pai, F para filho

        Console.Write(prefix);
        Console.WriteLine($"[{nodeType}] {node.Id} {node.Index}");

        if (node.Esquerda != null)
        {
            if (node.Direita != null)
            {
                PrintTree(node.Direita, prefix + "│   └── ");
                PrintTree(node.Esquerda, prefix + "│   ├── ");
            }
            else
            {
                PrintTree(node.Esquerda, prefix + "    ├── ");
            }
        }
        else if (node.Direita != null)
        {
            PrintTree(node.Direita, prefix + "    └── ");
        }
    }
}
