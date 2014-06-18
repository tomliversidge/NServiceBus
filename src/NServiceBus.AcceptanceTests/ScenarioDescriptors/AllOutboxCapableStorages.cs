﻿namespace NServiceBus.AcceptanceTests.ScenarioDescriptors
{
    using System;
    using AcceptanceTesting.Support;
    using NServiceBus.Persistence;

    public class AllOutboxCapableStorages:ScenarioDescriptor
    {
        public AllOutboxCapableStorages()
        {
            var defaultStorage = Persistence.Default;

            var definitionType = Type.GetType(defaultStorage.Settings["Persistence"]);

            var definition = (PersistenceDefinition) Activator.CreateInstance(definitionType);

            if (definition.HasSupportFor(Storage.Outbox))
            {
                Add(defaultStorage);
            }
        }
    }
}