using DigitalTripDataLoader.Models.Response;
using DigitalTripDataLoader.TestUtils;
using Ploeh.AutoFixture.Idioms;
using Xunit;

namespace DigitalTripDataLoader.eCommerce.Mappers.Tests
{
    public class PropertyMapperTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull<T>(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(PropertyMapper).GetConstructors());
        }

        [Theory, AutoMoqData]
        public void Map_ShouldPopulate_PropertyId(Property property, PropertyMapper sut)
        {
            // act..
            //var actual = sut.Map(property);

            // assert..
            //actual.PropertyId.ShouldBe(property.ID);
        }
    }
}