using System.Collections.Generic;

namespace backend_lab.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public List<Address> Addresses { get; set; }
    }
}