// See https://aka.ms/new-console-template for more information
using ArvoreAvl.src.Controllers;


NodeController controller = new NodeController();

controller.Inserir(10);

controller.Inserir(4);
controller.Inserir(5);

controller.Inserir(3);
controller.Inserir(2);
controller.Inserir(1);

controller.Inserir(6);

controller.Buscar(1);


controller.ImprimirArvore();