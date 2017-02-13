using DigitalTripDataLoader.Models.Response;
using DigitalTripDataLoader.TestUtils;
using DigitalTripDataLoader.Utils;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit2;
using Shouldly;
using Xunit;

namespace DigitalTripDataLoader.eCommerce.Mappers.Tests
{
    public class MoreInfoToPropertyModelMapperTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull<T>(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(MoreInfoToPropertyModelMapper).GetConstructors());
        }

        [Theory, AutoMoqData]
        public void Map_ShouldPopulate_PropertyId(MoreInfo moreInfo, InfoItem propertyIdInfoItem, int propertyIdInfoValue, MoreInfoToPropertyModelMapper sut)
        {
            // arrange..
            propertyIdInfoItem.InfoName = MoreInfoToPropertyModelMapper.PropertyIdInfoName;
            propertyIdInfoItem.InfoValue = propertyIdInfoValue.ToString();
            moreInfo.Information[0] = propertyIdInfoItem;

            // act..
            var actual = sut.Map(moreInfo);

            // assert..
            actual.PropertyId.ShouldBe(propertyIdInfoValue);
        }


        [Theory, AutoMoqData]
        public void Map_ShouldPopulate_LocationId(MoreInfo moreInfo, InfoItem locationIdInfoItem, int locationIdInfoValue, MoreInfoToPropertyModelMapper sut)
        {
            // arrange..
            locationIdInfoItem.InfoName = MoreInfoToPropertyModelMapper.LocationIdInfoName;
            locationIdInfoItem.InfoValue = locationIdInfoValue.ToString();
            moreInfo.Information[0] = locationIdInfoItem;

            // act..
            var actual = sut.Map(moreInfo);

            // assert..
            actual.LocationId.ShouldBe(locationIdInfoValue);
        }

        [Theory, AutoMoqData]
        public void Map_ShouldPopulate_Description(MoreInfo moreInfo, InfoItem descriptionInfoItem, MoreInfoToPropertyModelMapper sut)
        {
            // arrange..
            descriptionInfoItem.InfoName = MoreInfoToPropertyModelMapper.DescriptionInfoName;
            moreInfo.Information[0] = descriptionInfoItem;

            // act..
            var actual = sut.Map(moreInfo);

            // assert..
            actual.Description.ShouldBe(descriptionInfoItem.InfoValue);
        }

        [Theory, AutoMoqData]
        public void Map_ShouldCall_RoomTypeECommerceMappingPrefixes_On_IAppConfigProvider([Frozen] Mock<IAppConfigProvider> appConfigProviderMock, MoreInfo moreInfo, MoreInfoToPropertyModelMapper sut)
        {
            // act..
            sut.Map(moreInfo);

            // assert..
            appConfigProviderMock.Verify(m => m.RoomTypeECommerceMappingPrefixes);
        }

        [Theory, AutoMoqData]
        public void Map_ShouldPopulate_Rooms_Description(IFixture fixture, [Frozen] Mock<IAppConfigProvider> appConfigProviderMock, string[] prefixes, MoreInfo moreInfo, MoreInfoToPropertyModelMapper sut)
        {
            // arrange..
            moreInfo.Information[0].InfoName = $"{fixture.Create<string>()}, {prefixes[0]}, {fixture.Create<string>()}";
            moreInfo.Information[1].InfoName = $"{fixture.Create<string>()}, {prefixes[1]}, {fixture.Create<string>()}";
            moreInfo.Information[2].InfoName = $"{fixture.Create<string>()}, {prefixes[2]}, {fixture.Create<string>()}";

            appConfigProviderMock.Setup(m => m.RoomTypeECommerceMappingPrefixes).Returns(prefixes);

            // act..
            var actual = sut.Map(moreInfo);

            // assert..
            actual.Rooms[0].Description.ShouldBe(moreInfo.Information[0].InfoName);
            actual.Rooms[1].Description.ShouldBe(moreInfo.Information[1].InfoName);
            actual.Rooms[2].Description.ShouldBe(moreInfo.Information[2].InfoName);
        }

        [Theory(Skip = "This data is not available on current version of DigitalTrip API"), AutoMoqData]
        public void Map_ShouldPopulate_Rooms_RoomId(IFixture fixture, [Frozen] Mock<IAppConfigProvider> appConfigProviderMock, string[] prefixes, MoreInfo moreInfo, MoreInfoToPropertyModelMapper sut)
        {
            // arrange..
            moreInfo.Information[0].InfoName = $"{fixture.Create<string>()}, {prefixes[0]}, {fixture.Create<string>()}";
            moreInfo.Information[1].InfoName = $"{fixture.Create<string>()}, {prefixes[1]}, {fixture.Create<string>()}";
            moreInfo.Information[2].InfoName = $"{fixture.Create<string>()}, {prefixes[2]}, {fixture.Create<string>()}";

            appConfigProviderMock.Setup(m => m.RoomTypeECommerceMappingPrefixes).Returns(prefixes);

            // act..
            var actual = sut.Map(moreInfo);

            // assert..
            actual.Rooms[0].RoomId.ShouldNotBe(0);
            actual.Rooms[1].RoomId.ShouldNotBe(0);
            actual.Rooms[2].RoomId.ShouldNotBe(0);
        }
    }
}