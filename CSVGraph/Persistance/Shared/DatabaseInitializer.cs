using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Shared
{
    public class DatabaseInitializer
    {
        public static void Initialize(IDatabaseContext context)
        {
            context.EnsureDatabaseCreated();
        }
    }
}
