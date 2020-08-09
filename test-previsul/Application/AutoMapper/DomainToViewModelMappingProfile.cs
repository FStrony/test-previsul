using AutoMapper;
using test_previsul.Application.ViewModel;
using test_previsul.Domain.Entities;

namespace test_previsul.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerAddressViewModel>();
            CreateMap<CustomerAddress, CustomerAddressViewModel>();
        }
    }
}
