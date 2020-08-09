using AutoMapper;

namespace test_previsul.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappingsMVC()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
