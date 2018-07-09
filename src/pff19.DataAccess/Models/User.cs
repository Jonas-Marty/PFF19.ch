using System;
using System.Collections.Generic;
using System.Text;

namespace pff19.DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string ScoutName { get; set; }
        public string Mail { get; set; }
        public string Ressort { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public bool IsAdmin { get; set; }
    }
}
