﻿using System;
using System.Configuration;

namespace DigitalTripDataLoader.Utils
{
    public class AppConfigProvider : IAppConfigProvider
    {
        private readonly Lazy<string[]> _roomTypesECommerceMappingPrefixesLazy;

        public AppConfigProvider()
        {
            _roomTypesECommerceMappingPrefixesLazy = new Lazy<string[]>(() => ConfigurationManager.AppSettings[nameof(RoomTypesECommerceMappingsPrefixes)].Split(','));
        }

        public string[] RoomTypesECommerceMappingsPrefixes => _roomTypesECommerceMappingPrefixesLazy.Value;
    }
}