﻿using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit2;

namespace DigitalTripDataLoader.Service.Tests
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(new Fixture())
        {
            Fixture.Customize(new AutoMoqCustomization())
                   .Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}