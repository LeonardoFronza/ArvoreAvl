
using ArvoreAvl.src.Dtos;

namespace ArvoreAvl.src.Controllers
{
    public class NodeController
    {
        public NodeController()
        {
            //newRoot();
        }

        Node? root = new Node();
        Node newNode = new Node();
        
        ///// <summary>
        ///// Criando a raiz da arvore.
        ///// </summary>
        //public void newRoot()
        //{
        //    root = null;
        //}

        public void Inserir(int number)
        {
            CreateRoot(number);

            if(root.Id > number)
            {
                root.Right.Validator3000(number);
            }

            if(newNode.Id < number)
            {
                root.Left.Validator3000(number);
            }
        }

        private void CreateRoot(int number)
        {
            newNode.Id = number;

            if (root is null)
            {
                root = newNode;
            }
        }
    }
}
