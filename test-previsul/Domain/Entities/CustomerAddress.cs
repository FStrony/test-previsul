using System;
using test_previsul.Domain.Bases;

namespace test_previsul.Domain.Entities
{
    public class CustomerAddress : EntityBase
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string StreetName { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string Neighbourhood { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
