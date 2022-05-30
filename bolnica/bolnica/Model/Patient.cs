using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model
{
    public class Patient
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //public DateTime DateOfBirth { get; set; }
        public string DateOfBirth { get; set; }
        public string Username { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        //public Allergen Allergens { get; set; }

        public Patient()
        {

        }

        public Patient(uint id, string name, string surname, string dateOfBirth, string username, string adress, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Username = username;
            Adress = adress;
            Email = email;
        }

        public Patient(string name, string surname, string dateOfBirth, string username, string adress, string email)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Username = username;
            Adress = adress;
            Email = email;
        }
    }
}
