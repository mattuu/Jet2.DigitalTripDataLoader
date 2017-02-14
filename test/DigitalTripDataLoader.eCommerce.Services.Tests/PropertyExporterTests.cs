using System;
using System.Threading.Tasks;
using DigitalTripDataLoader.eCommerce.Mappers;
using DigitalTripDataLoader.eCommerce.Models;
using DigitalTripDataLoader.Models.Response;
using DigitalTripDataLoader.TestUtils;
using DigitalTripDataLoader.Utils;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace DigitalTripDataLoader.eCommerce.Services.Tests
{
    public class PropertyExporterTests
    {
        [Theory, AutoMoqWebData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull<T>(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(PropertyExporter).GetConstructors());
        }

        [Theory, AutoMoqData]
        public async Task Export_ShouldCall_Map_On_IMapperOfMoreInfoToPropertyModel_WithCorrectArgs([Frozen] Mock<IMapper<MoreInfo, PropertyModel>> mapperMock,
                                                                                                    MoreInfo moreInfo,
                                                                                                    PropertyExporter sut)
        {
            // act..
            await sut.Export(moreInfo);

            // assert..
            mapperMock.Verify(m => m.Map(moreInfo), Times.Once);
        }

        [Theory, AutoMoqData]
        public async Task Export_ShouldCall_ECommercePropertyMappingEndpoint_On_IAppConfigProvider([Frozen] Mock<IAppConfigProvider> appConfigProviderMock,
                                                                                                   //[Frozen] Mock<IPropertyModelJsonSerializer> propertyModelJsonSerializerMock, 
                                                                                                   MoreInfo moreInfo,
                                                                                                   PropertyExporter sut)
        {
            // act..
            await sut.Export(moreInfo);

            // assert..
            appConfigProviderMock.Verify(m => m.ECommercePropertyMappingEndpoint, Times.Once);
        }

        [Theory, AutoMoqWebData]
        public async Task Export_ShouldCall_ECommercePropertyMappingEndpoint_On_IAppConfigProvider([Frozen] Mock<IMapper<MoreInfo, PropertyModel>> mapperMock,
                                                                                                   MoreInfo moreInfo,
                                                                                                   PropertyExporter sut)
        {
            // act..
            await sut.Export(moreInfo);

            // assert..
            mapperMock.Verify(m => m.Map(moreInfo), Times.Once);
        }
    }

    public class AutoMoqWebDataAttribute : AutoDataAttribute
    {
        public AutoMoqWebDataAttribute()
            : base(new Fixture())
        {
            Fixture.Customize(new AutoMoqCustomization())
                   .Customize(new UriCustomization())
                   .Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }

    public class UriCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Uri>(c => c.FromFactory<Uri>(f => new Uri("http://server.com")));
        }
    }
}