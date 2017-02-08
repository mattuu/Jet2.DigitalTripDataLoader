using DigitalTripDataLoader.Service.Callers;
using DigitalTripDataLoader.Service.Serializers;
using Moq;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace DigitalTripDataLoader.Service.Tests.Callers
{
    public class GetPropertiesCallerTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(GetPropertiesCaller).GetConstructors());
        }

       
    }
}