using System.Configuration;
using DigitalTripDataLoader.TestUtils;
using Ploeh.AutoFixture.Idioms;
using Shouldly;
using Xunit;

namespace DigitalTripDataLoader.Utils.Tests
{
    public class AppConfigProviderTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull<T>(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(AppConfigProvider).GetConstructors());
        }

        [Theory, AutoMoqData]
        public void RoomTypesECommerceMappingsPrefixes_ShouldReturnCorrectResult(string value, bool expectedResult, AppConfigProvider sut)
        {
            // act..
            var actual = sut.RoomTypeECommerceMappingPrefixes;

            // assert..
            var expected = ConfigurationManager.AppSettings[nameof(AppConfigProvider.RoomTypeECommerceMappingPrefixes)].Split(',');

            actual.ShouldBe(expected);
        }
    }
}