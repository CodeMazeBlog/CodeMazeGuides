using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [CollectionDefinition("Calculation Collection")]
    public class CalculationCollection : ICollectionFixture<CalculationFixture>
    {
        // This class is required for xUnit to create a shared instance of CalculationFixture
    }
}
