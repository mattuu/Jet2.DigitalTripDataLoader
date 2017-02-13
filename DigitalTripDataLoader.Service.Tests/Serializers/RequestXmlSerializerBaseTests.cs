using DigitalTripDataLoader.Service.Serializers;
using DigitalTripDataLoader.TestUtils;
using Ploeh.AutoFixture.Idioms;
using Shouldly;
using Xunit;

namespace DigitalTripDataLoader.Service.Tests.Serializers
{
    public class RequestXmlSerializerBaseTests

    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull<T>(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(RequestXmlSerializerBase<T>).GetConstructors());
        }

        [Theory, AutoMoqData]
        public void Serialize_ShouldReturnCorrectResult(SampleModel model, RequestXmlSerializerBase<SampleModel> sut)
        {
            // act..
            var actual = sut.Serialize(model);

            // assert..
            const string format = @"<SampleModel>
  <ID>{0}</ID>
</SampleModel>";

            var expected = string.Format(format, model.ID);

            actual.ShouldBe(expected);
        }

        public class SampleModel
        {
            public int ID { get; set; }
        }
    }
}