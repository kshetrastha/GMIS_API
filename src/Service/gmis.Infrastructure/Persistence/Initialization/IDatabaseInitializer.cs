﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Infrastructure.Persistence.Initialization
{
    internal interface IDatabaseInitializer
    {
        Task InitializeDatabasesAsync(CancellationToken cancellationToken);
    }
}
