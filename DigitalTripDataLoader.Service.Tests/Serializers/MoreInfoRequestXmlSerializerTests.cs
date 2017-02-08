using System;
using DigitalTripDataLoader.Service.Serializers;
using Ploeh.AutoFixture.Idioms;
using Shouldly;
using Xunit;

namespace DigitalTripDataLoader.Service.Tests.Serializers
{
    public class MoreInfoRequestXmlSerializerTests

    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(MoreInfoRequestXmlSerializer).GetConstructors());
        }

        [Theory, AutoMoqData]
        public void GetXml_ShouldReturnCorrectResult(int id, Guid guid, MoreInfoRequestXmlSerializer sut)
        {
            // act..
            var actual = sut.GetXml(id, guid);

            // assert..
            const string format = @"<MoreInfoRequest>
  <GUID>{0}</GUID>
  <ID>{1}</ID>
</MoreInfoRequest>";

            var expected = string.Format(format, guid, id);

            actual.ShouldBe(expected);
        }
    }
}