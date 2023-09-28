
using System.Text.RegularExpressions;

namespace ArvoreAvl.src.Dtos
{
    public class Node
    {
        /// <summary>
        /// Construtor.
        /// </summary>
        public Node(int number)
        {
            Id = number;
        }

        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Esquerda.
        /// </summary>
        public Node Esquerda { get; set; }

        /// <summary>
        /// Direita.
        /// </summary>
        public Node Direita { get; set; }

        /// <summary>
        /// Fator de balanceamento.
        /// </summary>
        public int BFactor { get; set; }

        /// <summary>
        /// Valida os itens a serem inseridos.
        /// </summary>
        /// <param name="number"></param>
        public void Validator3000(int number)
        {
            if (Id == number)
            {
                return;
            }

            if (Id > number)
            {
                if (Esquerda is null)
                {
                    Esquerda = new Node(number);
                }
                else
                {
                    Esquerda.Validator3000(number);
                }
            }
            else if (Id < number)
            {
                if (Direita is null)
                {
                    Direita = new Node(number);
                }
                else
                {
                    Direita.Validator3000(number);
                }
            }

            AtualizarBFactor();
            Balancear();
        }

        /// <summary>
        /// Calcula a altura da arvore. Para calcular fator de balanceamento.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int Altura(Node node)
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
            Node novo = new Node(Id)
            {
                Direita = Direita,
                Esquerda = Esquerda.Direita
            };
            Direita = novo;
            Id = Esquerda.Id;
            Esquerda = Esquerda.Esquerda;
            AtualizarBFactor();
        }

        /// <summary>
        /// Realiza a rotação para a esquerda.
        /// </summary>
        private void RotacaoEsquerda()
        {
            Node novo = new Node(Id)
            {
                Esquerda = Esquerda,
                Direita = Direita.Esquerda
            };
            Esquerda = novo;
            Id = Direita.Id;
            Direita = Direita.Direita;
            AtualizarBFactor();
        }

        /// <summary>
        /// Busca elemento na arvore.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Node Buscar(int number)
        {
            if (number == Id)
            {
                return this;
            }
            else if (number < Id && Esquerda != null)
            {
                return Esquerda.Buscar(number);
            }
            else if (number > Id && Direita != null)
            {
                return Direita.Buscar(number);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Mostra os itens da arvore em pré-oredem.
        /// </summary>
        public void PreOrdem()
        {
            Console.Write(Id);

            if (Esquerda is not null)
            {
                Console.Write(", ");
                Esquerda.PreOrdem();
            }

            if (Direita is not null)
            {
                Console.Write(", ");
                Direita.PreOrdem();
            }
        }

        /// <summary>
        /// Mostra os itens da arvore em pós-oredem.
        /// </summary>
        public void PosOrdem()
        {
            if (Esquerda is not null)
            {
                Esquerda.PosOrdem();
                Console.Write(", ");
            }

            if (Direita is not null)
            {
                Direita.PosOrdem();
                Console.Write(", ");
            }

            Console.Write(Id);
        }

        /// <summary>
        /// Mostra os itens da arvore em ordem.
        /// </summary>
        public void EmOrdem()
        {
            if (Esquerda is not null)
            {
                Esquerda.EmOrdem();
                Console.Write(", ");
            }

            Console.Write(Id);

            if (Direita is not null)
            {
                Console.Write(", ");
                Direita.EmOrdem();
            }
        }

        /// <summary>
        /// Remove um item da arvore.
        /// </summary>
        public Node Remover(int valor)
        {
            if (valor < Id)
            {
                if (Esquerda != null)
                {
                    Esquerda = Esquerda.Remover(valor);
                    AtualizarBFactor();
                    Balancear();
                }
            }
            else if (valor > Id)
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
                // Encontrou o nó a ser removido
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
                    Node sucessor = EncontrarMenorNode(Direita);
                    Id = sucessor.Id;
                    Direita = Direita.Remover(sucessor.Id);
                    AtualizarBFactor();
                    Balancear();
                }
            }

            return this;
        }

        private Node EncontrarMenorNode(Node node)
        {
            while (node.Esquerda != null)
            {
                node = node.Esquerda;
            }
            return node;
        }

        /// <summary>
        /// Imprime a arvore.
        /// </summary>
        public void PrintTree(Node node, string prefix = "")
        {
            if (node == null)
                return;

            bool isLeaf = (node.Esquerda == null && node.Direita == null);
            string nodeType = isLeaf ? "F" : "P"; // P para pai, F para filho

            Console.Write(prefix);
            Console.WriteLine($"[{nodeType}] {node.Id}");

            if (node.Esquerda != null)
            {
                if (node.Direita != null)
                {
                    PrintTree(node.Esquerda, prefix + "│   ├── ");
                    PrintTree(node.Direita, prefix + "│   └── ");
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
}
