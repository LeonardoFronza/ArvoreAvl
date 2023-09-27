
using System.Text.RegularExpressions;

namespace ArvoreAvl.src.Dtos
{
    public class Node
    {
        public Node() { }
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
        public Node Left { get; set; }

        /// <summary>
        /// Direita.
        /// </summary>
        public Node Right { get; set; }

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
                if (Left is null)
                {
                    Left = new Node(number);
                }
                else
                {
                    Left.Validator3000(number);
                }
            }
            else if (Id < number)
            {
                if (Right is null)
                {
                    Right = new Node(number);
                }
                else
                {
                    Right.Validator3000(number);
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

            int alturaEsquerda = Altura(node.Left);
            int alturaDireita = Altura(node.Right);

            return Math.Max(alturaEsquerda, alturaDireita) + 1;
        }

        /// <summary>
        /// Calcula o fator de balanceamento.
        /// </summary>
        public void AtualizarBFactor()
        {
            int alturaEsquerda = Altura(Left);
            int alturaDireita = Altura(Right);
            //Console.WriteLine("-----------------");
            //Console.WriteLine(alturaEsquerda + "--" + Id);
            //Console.WriteLine(alturaDireita + "--" + Id);
            BFactor = alturaEsquerda - alturaDireita;
            //Console.WriteLine(BFactor.ToString());
        }

        /// <summary>
        /// Realiza o balanceamento da arvore.
        /// </summary>
        public void Balancear()
        {
            if (BFactor > 1)
            {
                if (Left.BFactor >= 0)
                {
                    RotacaoDireita();
                }
                else
                {
                    Left.RotacaoEsquerda();
                    RotacaoDireita();
                }
            }
            else if (BFactor < -1)
            {
                if (Right.BFactor <= 0)
                {
                    RotacaoEsquerda();
                }
                else
                {
                    Right.RotacaoDireita();
                    RotacaoEsquerda();
                }
            }
        }

        private void RotacaoDireita()
        {
            Node novo = new Node(Id);
            novo.Right = Right;
            novo.Left = Left.Right;
            Right = novo;
            Id = Left.Id;
            Left = Left.Left;
            AtualizarBFactor();
        }

        private void RotacaoEsquerda()
        {
            Node novo = new Node(Id);
            novo.Left = Left;
            novo.Right = Right.Left;
            Left = novo;
            Id = Right.Id;
            Right = Right.Right;
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
            else if (number < Id && Left != null)
            {
                return Left.Buscar(number);
            }
            else if (number > Id && Right != null)
            {
                return Right.Buscar(number);
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
            Console.Write(Id + ", ");

            if (Left is not null)
            {
                Left.PreOrdem();
            }

            if (Right is not null)
            {
                Right.PreOrdem();
            }
        }

        public void PosOrdem()
        {
            if (Left is not null)
            {
                Left.PreOrdem();
            }

            if (Right is not null)
            {
                Right.PreOrdem();
            }

            Console.Write(Id + ", ");
        }

        public void EmOrdem()
        {
            if (Left is not null)
            {
                Left.PreOrdem();
            }

            Console.Write(Id + ", ");

            if (Right is not null)
            {
                Right.PreOrdem();
            }
        }

        public void PrintTree(Node teste)
        {
            PrintTree(teste, "");
        }

        public void PrintTree(Node node, string prefix)
        {
            if (node == null)
                return;

            bool isLeaf = (node.Left == null && node.Right == null);
            string nodeType = isLeaf ? "L" : "I"; // L para folha, I para nó interno

            Console.WriteLine($"{prefix}└── [{nodeType}] {node.Id}");

            if (node.Left != null || node.Right != null)
            {
                string newPrefix = prefix + (isLeaf ? "    " : "│   ");
                if (node.Left != null)
                {
                    PrintTree(node.Left, newPrefix + "├── ");
                }
                if (node.Right != null)
                {
                    PrintTree(node.Right, newPrefix + "└── ");
                }
            }
        }
    }
}
