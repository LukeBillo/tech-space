using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using SqlKata.Compilers;
using SqlKata.Execution;
using TechSpace.Data.DependencyInjection;

namespace TechSpace.Data
{
    public interface ITechSpaceQueryFactoryManager
    {
        public QueryFactory CreateQueryFactory();
    }
    
    public class TechSpaceQueryFactoryManager : ITechSpaceQueryFactoryManager
    {
        private readonly IOptions<TechSpaceDatabaseOptions> _databaseOptions;

        public TechSpaceQueryFactoryManager(IOptions<TechSpaceDatabaseOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions;
        }
        
        public QueryFactory CreateQueryFactory()
        {
            var connection = new SqlConnection(_databaseOptions.Value.ConnectionString);
            var compiler = new SqlServerCompiler();
            return new QueryFactory(connection, compiler);
        }
    }
}