using AutoMapper;
using test_previsul.Application.ViewModel;
using test_previsul.Domain.Entities;

namespace test_previsul.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<CustomerAddressViewModel, CustomerAddress>();
        }
    }
}
