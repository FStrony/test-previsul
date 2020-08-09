using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test_previsul.Domain.Bases;

namespace test_previsul.Application.ViewModel
{
    public class CustomerViewModel : EntityBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<CustomerAddressViewModel> Addresses { get; set; }
    }
}
