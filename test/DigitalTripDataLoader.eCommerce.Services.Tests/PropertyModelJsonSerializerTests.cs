using DigitalTripDataLoader.eCommerce.Models;
using DigitalTripDataLoader.TestUtils;
using Ploeh.AutoFixture.Idioms;
using Shouldly;
using Xunit;

namespace DigitalTripDataLoader.eCommerce.Services.Tests
{
    public class PropertyModelJsonSerializerTests
    {
        [Theory, AutoMoqWebData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull<T>(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(PropertyModelJsonSerializer).GetConstructors());
        }

        [Theory, AutoMoqData]
        public void Serialize_ShouldReturnCorrectResult(PropertyModel propertyModel, PropertyModelJsonSerializer sut)
        {
            // act..
            var actual = sut.Serialize(propertyModel);

            // arrange..
            const string expectedFormat = @"{{
  ""digitalTripPropertyId"": {0},
  ""digitalTripLocationId"": {1},
  ""description"": ""{2}"",
  ""rooms"": [
    {{
      ""digitalTripRoomId"": {3},
      ""roomDescription"": ""{4}""
    }},
    {{
      ""digitalTripRoomId"": {5},
      ""roomDescription"": ""{6}""
    }},
    {{
      ""digitalTripRoomId"": {7},
      ""roomDescription"": ""{8}""
    }}
  ]
}}";
            var expected = string.Format(expectedFormat,
                                         propertyModel.PropertyId,
                                         propertyModel.LocationId,
                                         propertyModel.Description,
                                         propertyModel.Rooms[0].RoomId,
                                         propertyModel.Rooms[0].Description,
                                         propertyModel.Rooms[1].RoomId,
                                         propertyModel.Rooms[1].Description,
                                         propertyModel.Rooms[2].RoomId,
                                         propertyModel.Rooms[2].Description);

            actual.ShouldBe(expected);
        }
    }
}