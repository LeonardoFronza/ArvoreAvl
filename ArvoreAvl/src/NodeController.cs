
using ArvoreAvl.src.Dtos;

namespace ArvoreAvl.src.Controllers
{
    public class NodeController
    {
        /// <summary>
        /// Raiz da arvore
        /// </summary>
        private Node? root;

        /// <summary>
        /// Cria a raiz da arvore
        /// </summary>
        private void CriarArvore(int number)
        {
            if (root is null)
            {
                root = new Node(number);
            }
        }

        /// <summary>
        /// Insere um item na arvore
        /// </summary>
        public Node? Inserir(int number)
        {
            CriarArvore(number);

            if (root is not null)
            {
                    root.Validator3000(number);
            }

            return root;
        }

        public void Remover(int number)
        {
            if (root is null)
            {
                return;
            }

            root = root.Remover(number);
        }

        /// <summary>
        /// Busca um item na arvore
        /// </summary>
        public void Buscar(int number)
        {
            Node nodeBusca;
            if (root is null)
            {
                return;
            }
            nodeBusca = root.Buscar(number);
            root.PrintTree(nodeBusca);
        }

        /// <summary>
        /// Busca caminhamento na arvore
        /// </summary>
        /// <param name="value"></param>
        public void BuscaCaminhamento(int value)
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