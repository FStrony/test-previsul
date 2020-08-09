using System;
using System.Collections.Generic;
using test_previsul.Domain.Bases;

namespace test_previsul.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<CustomerAddress> Addresses { get; set; }
    }
}
