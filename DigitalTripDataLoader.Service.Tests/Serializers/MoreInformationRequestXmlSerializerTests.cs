using DigitalTripDataLoader.Models.Request;
using DigitalTripDataLoader.Service.Serializers;
using Ploeh.AutoFixture.Idioms;
using Shouldly;
using Xunit;

namespace DigitalTripDataLoader.Service.Tests.Serializers
{
    public class MoreInformationRequestXmlSerializerTests

    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(MoreInformationRequestXmlSerializer).GetConstructors());
        }

        [Theory, AutoMoqData]
        public void Serialize_ShouldReturnCorrectResult(MoreInformationRequest request, MoreInformationRequestXmlSerializer sut)
        {
            // act..
            var actual = sut.Serialize(request);

            // assert..
            const string format = @"<MoreInformationRequest>
  <ID>{0}</ID>
</MoreInformationRequest>";

            var expected = string.Format(format, request.Id);

            actual.ShouldBe(expected);
        }
    }
}