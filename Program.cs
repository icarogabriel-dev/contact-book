// content main

using System;
using contactbook.Services;
using contactbook.Data;
using contactbook.Entities;

namespace contactbook
{
    class Program
    {
        static void Main(string[] args)
        {
            ContatoService service = new ContatoService();
            bool executed = true;

            while (executed)
            {
                Console.WriteLine("=== AGENDA DE CONTATOS ===");
                Console.WriteLine("1 - Adicionar contato");
                Console.WriteLine("2 - Listar contatos");
                Console.WriteLine("3 - Buscar contato por ID");
                Console.WriteLine("4 - Editar contato");
                Console.WriteLine("5 - Remover contato");
                Console.WriteLine("6 - Sair");
                Console.Write("Escolha uma opção: ");

                string option = Console.ReadLine();
                Console.Clear();

                switch (option)
                {
                    case "1":
                        service.AddContact();
                        break;
                    case "2":
                        service.ListContact();
                        break;
                    case "3":
                        service.SearchId();
                        break;
                    case "4":
                        service.EditContact();
                        break;
                    case "5":
                        service.RemoveContact();
                        break;
                    case "6":
                        executed = false;
                        Console.WriteLine("Saindo do sistema..");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
