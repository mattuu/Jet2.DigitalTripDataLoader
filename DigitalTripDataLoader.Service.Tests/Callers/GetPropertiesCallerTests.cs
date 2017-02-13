using DigitalTripDataLoader.Service.Callers;
using Ploeh.AutoFixture.Idioms;
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