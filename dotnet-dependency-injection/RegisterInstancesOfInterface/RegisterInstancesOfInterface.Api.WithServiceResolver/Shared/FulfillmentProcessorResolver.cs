﻿using RegisterInstancesOfInterface.Api.WithServiceResolver.Interfaces;

namespace RegisterInstancesOfInterface.Api.WithServiceResolver.Shared;

public delegate IFulfillTickets FulfillmentProcessorResolver(string key);