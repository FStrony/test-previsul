using System;

namespace test_previsul.Domain.Bases
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
