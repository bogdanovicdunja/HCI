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
        public string Username { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        //public Allergen Allergens { get; set; }

        public Patient()
        {

        }

        public Patient(uint id, string name, string surname, string username, string adress, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Adress = adress;
            Email = email;
            //Allergens = allergens;
        }

        public Patient(string name, string surname, string username, string adress, string email)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Adress = adress;
            Email = email;
            //Allergens = allergens;
        }
    }
}
