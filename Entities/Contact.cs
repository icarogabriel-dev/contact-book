using System;

namespace contactbook.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Telephone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public Contact(string name, double telephone, string email)
        {
            Name = name;
            Telephone = telephone;
            Email = email;
            CreatedDate = DateTime.Now;
        }

        public override string ToString()
        {
            return "Id - "
            + Name
            + "\nTel: "
            + Telephone
            + "\nEmail: "
            + Email
            + "\nCreated in: "
            + CreatedDate.ToString("dd/MM/yyyy HH:mm"); // Padrão ISO 8601 para a data de criação do contato
        }
    }
}
