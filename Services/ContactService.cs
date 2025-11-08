using System;
using System.Collections.Generic;
using contactbook.Entities;
using contactbook.Data;

namespace contactbook.Services
{
    public class ContatoService
    {
        private List<Contact> contacts;
        private Repository repository;

        public ContatoService()
        {
            repository = new Repository();
            contacts = repository.Load();
        }

        public void AddContact()
        {
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Telefone: ");
            double telephone = double.Parse(Console.ReadLine());

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Contact contact = new Contact(name, telephone, email);

            if (contacts.Count == 0) // Começa com ID 1 caso não houver contatos salvos
            {
                contact.Id = 1;
            } else // Pega o ID do último contato salvo e soma 1 
              {
                contact.Id = contacts[contacts.Count - 1].Id + 1;
            }

            contacts.Add(contact); // Adiciona o contato novo na lista

            repository.Save(contacts); // Salva o contato no arquivo Json
        }

        public void ListContact()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado. Tente novamente.");
                return;
            }

            Console.WriteLine("--- Lista de Contatos ---");
            foreach (Contact c in contacts)
            {
                Console.WriteLine(c);
                Console.WriteLine("--------------------------");
            }
        }

        public void SearchId()
        {
            Console.Write("Digite o ID do contato: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Tente novamente.");
                return;
            }

            bool search = false;
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Id == id)
                {
                    Console.WriteLine("Contato encontrado:");
                    Console.WriteLine(contacts[i]);
                    search = true;
                    break;
                }
            }

            if (!search)
            {
                Console.WriteLine("Contato não encontrado. Tente novamente.");
            }
        }

        public void EditContact()
        {
            Console.Write("Digite o ID do contato que deseja editar: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Tente novamente.");
                return;
            }

            Contact contactEdit = null;
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Id == id)
                {
                    contactEdit = contacts[i];
                    break;
                }
            }

            if (contactEdit == null)
            {
                Console.WriteLine("Contato não encontrado. Tente novamente.");
                return;
            }

            Console.Write("Novo nome: ");
            contactEdit.Name = Console.ReadLine();

            Console.Write("Novo telefone: ");
            contactEdit.Telephone = double.Parse(Console.ReadLine());

            Console.Write("Novo email: ");
            contactEdit.Email = Console.ReadLine();

            repository.Save(contacts);
            Console.WriteLine("Contato atualizado com sucesso!");
        }

        public void RemoveContact()
        {
            Console.Write("Digite o ID do contato que deseja remover: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Tente novamente.");
                return;
            }

            int index = -1;
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Id == id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Contato não encontrado.");
                return;
            }

            contacts.RemoveAt(index);
            repository.Save(contacts);
            Console.WriteLine("Contato removido com sucesso!");
        }
    }
}
