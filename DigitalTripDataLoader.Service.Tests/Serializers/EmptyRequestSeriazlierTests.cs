﻿using DigitalTripDataLoader.Service.Serializers;
using Ploeh.AutoFixture.Idioms;
using Shouldly;
using Xunit;

namespace DigitalTripDataLoader.Service.Tests.Serializers
{
    public class EmptyRequestSeriazlierTests
    {
        [Theory, AutoMoqData]
        public void Ctor_ShouldThrowWhenAnyDependencyIsNull<T>(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(EmptyRequestXmlSerializer).GetConstructors());
        }

        [Theory, AutoMoqData]
        public void Serialize_ShouldReturnCorrectResult(EmptyRequestXmlSerializer sut)
        {
            // act..
            var actual = sut.Serialize();

            // assert..
            actual.ShouldBeNullOrEmpty();
        }
    }
}