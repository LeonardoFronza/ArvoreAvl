
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
                if (Left == null)
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
                if (Right == null)
                {
                    Right = new Node(number);
                }
                else
                {
                    Right.Validator3000(number);
                }
            }
        }
    }
}
