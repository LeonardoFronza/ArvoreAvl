// See https://aka.ms/new-console-template for more information
using ArvoreAvl.src.Controllers;


NodeController controller = new NodeController();


controller.Inserir(120);
controller.Inserir(130);
controller.Inserir(150);
controller.Inserir(200);
controller.Inserir(100);
controller.Inserir(110);
controller.Inserir(80);
controller.ImprimirArvore();

//controller.Buscar(20);