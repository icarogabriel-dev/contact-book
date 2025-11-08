// project storage data

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using contactbook.Entities;
using contactbook.Services;

namespace contactbook.Data
{
    public class Repository
    {
        private const string FilePath = "contatos.json";

        public List<Contact> Load()
        {
            if (!File.Exists(FilePath)) {
                return new List<Contact>(); // Retorna uma lista vazia
            } else {
                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
                // ?? new List<Contact>() -> Se algo der errado, não retorna null, e sim uma lista vazia
            }
        }

        public void Save(List<Contact> contacts)
        {
            string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            // JsonSerializer.Serialize -> Transforma a lista dos contatos em formato de texto
            // WriteIndented -> Define que os dados salvos sejam identados para melhor entendimento
            File.WriteAllText(FilePath, json); // Grava o texto no arquivo "FilePath"
        }
    }
}
