using System.Linq;
using DigitalTripDataLoader.Models.Response;
using DigitalTripDataLoader.TestUtils;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Idioms;
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
        public void Map_ShouldPopulate_Rooms(MoreInfo moreInfo, MoreInfoToPropertyModelMapper sut)
        {
            // arrange..

            //descriptionInfoItem.InfoName = MoreInfoToPropertyModelMapper.DescriptionInfoName;
            //moreInfo.Information[0] = descriptionInfoItem;

            //// act..
            //var actual = sut.Map(moreInfo);

            //// assert..
            //actual.Description.ShouldBe(descriptionInfoItem.InfoValue);
        }

    }
}