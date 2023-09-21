#pragma warning disable CS8602
using ArvoreAvl.src.Dtos;

namespace ArvoreAvl.src.Controllers
{
    public class NodeController
    {
        Node root;

        private void CreateRoot(int number)
        {
            if (root is null)
            {
                root = new Node(number);
            }
        }

        public void Inserir(int number)
        {
            CreateRoot(number);

            if (root.Id > number)
            {
                if (root.Right is null)
                    root.Right = new Node(number);

                root.Right.Validator3000(number);
            }

            if (root.Id < number)
            {
                if (root.Left is null)
                    root.Left = new Node(number);

                root.Left.Validator3000(number);
            }
        }

        public void Buscar(int number)
        {
            if (root is null)
            {
                return;
            }

            if (root.Id > number)
            {
                Console.WriteLine(root.Right.Buscar(number));
            }

            if (root.Id < number)
            {
                Console.WriteLine(root.Left.Buscar(number));
            }

            Console.WriteLine(root);
        }

        public void BuscaCaminhamento(int value)
        {
            switch (value)
            {
                case 1:
                    root.PreOrdem();
                    break;
                case 2:
                    root.PosOrdem();
                    break;
                case 3:
                    root.EmOrdem();
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
}
#pragma warning restore CS8602