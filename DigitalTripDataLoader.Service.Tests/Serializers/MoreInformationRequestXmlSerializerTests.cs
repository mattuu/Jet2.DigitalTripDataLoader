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
        public void GetXml_ShouldReturnCorrectResult(int id, MoreInformationRequestXmlSerializer sut)
        {
            // act..
            var actual = sut.GetXml(id);

            // assert..
            const string format = @"<MoreInformationRequest>
  <ID>{0}</ID>
</MoreInformationRequest>";

            var expected = string.Format(format, id);

            actual.ShouldBe(expected);
        }
    }
}