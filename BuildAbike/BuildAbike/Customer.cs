using System.Collections.Generic;

namespace BuildAbike
{
    public class Customer
    {
        private string name;
        private string address;
        private string email;
        private List<Order> orders;

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public List<Order> Orders { get => orders; set => orders = value; }
    }
}
