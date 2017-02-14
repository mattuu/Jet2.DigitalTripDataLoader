using System;
using System.Configuration;
using DigitalTripDataLoader.TestUtils;
using Ploeh.AutoFixture.Xunit2;
using Shouldly;
using Xunit;

namespace DigitalTripDataLoader.Utils.Tests
{
    public class AppConfigProviderTests
    {
        [Theory, AutoMoqData]
        public void RoomTypesECommerceMappingsPrefixes_ShouldReturnCorrectResult(AppConfigProvider sut)
        {
            // act..
            var actual = sut.RoomTypeECommerceMappingPrefixes;

            // assert..
            var expected = ConfigurationManager.AppSettings[nameof(AppConfigProvider.RoomTypeECommerceMappingPrefixes)].Split(',');

            actual.ShouldBe(expected);
        }

        [Theory, AutoData]
        public void ECommercePropertyMappingEndpoint_ShouldReturnCorrectResult(string key)
        {
            // arrange..
            const string uriString = "http://server.com";
            var sut = new AppConfigProvider(_ => uriString);

            var expected = new Uri(uriString);

            // act..
            var actual = sut.ECommercePropertyMappingEndpoint;

            // assert..
            actual.ShouldBe(expected);
        }
    }
}