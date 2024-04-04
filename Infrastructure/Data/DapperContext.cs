using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure.Data;

public class DapperContext(IConfiguration configuration)
{
   private readonly IConfiguration _configuration=configuration;

   public NpgsqlConnection Connection()
   {
       return new NpgsqlConnection(_configuration.GetConnectionString("Default"));
   }
}
