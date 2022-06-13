using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model
{
    public class Secretary
    {
        public uint Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Secretary()
        {

        }

        public Secretary(uint id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }

        public Secretary(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Secretary(uint id)
        {
            Id = id;
        }
    }
}
