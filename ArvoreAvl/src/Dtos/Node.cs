
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
        public Node? Left { get; set; }

        /// <summary>
        /// Direita.
        /// </summary>
        public Node? Right { get; set; }

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

            if (Id < number)
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
        private void AtualizarBFactor()
        {
            int alturaEsquerda = Altura(Left);
            int alturaDireita = Altura(Right);
            BFactor = alturaEsquerda - alturaDireita;
        }

        /// <summary>
        /// Realiza o balanceamento da arvore.
        /// </summary>
        private void Balancear()
        {
            if (Left is null)
                return;


            if (Right is null)
                return;

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

        }

        private void RotacaoEsquerda()
        {

        }
    }
}
