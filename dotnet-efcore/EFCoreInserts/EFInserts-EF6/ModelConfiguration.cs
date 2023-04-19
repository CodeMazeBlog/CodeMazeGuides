using System.Data.Entity;
using Npgsql;

namespace EFInserts_EF6;

public class ModelConfiguration : DbConfiguration
{
    public ModelConfiguration()
    {
        const string name = "Npgsql";

        SetProviderFactory(providerInvariantName: name, providerFactory: NpgsqlFactory.Instance);

        SetProviderServices(providerInvariantName: name, provider: NpgsqlServices.Instance);

        SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
    }
}