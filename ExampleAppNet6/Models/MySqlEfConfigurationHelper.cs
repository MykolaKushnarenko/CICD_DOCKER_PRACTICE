using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace ExampleAppNet6.Models;

public static class MySqlEfConfigurationHelper
{
    private static string _sDefaultDbHost = "localhost";
    private static string _sDefaultDbPort = "3306";
    private static string _sDefaultDbPassword = "mysecret";
    
    public static MySqlServerVersion MySqlServerVersion => new MySqlServerVersion(new Version(8, 0, 0));
    
    public static string ConstructConnectionString(IConfiguration configuration)
    {
        var host = configuration["DBHOST"] ?? _sDefaultDbHost;
        var port = configuration["DBPORT"] ?? _sDefaultDbPort;
        var password = configuration["DBPASSWORD"] ?? _sDefaultDbPassword;

        var connection = $"server={host};userid=root;password={password};"
                         + $"port={port};database=products";

        return connection;
    }
    
    public static string ConstructConnectionString(IDictionary configuration)
    {
        var host = configuration["DBHOST"] ?? _sDefaultDbHost;
        var port = configuration["DBPORT"] ?? _sDefaultDbPort;
        var password = configuration["DBPASSWORD"] ?? _sDefaultDbPassword;

        var connection = $"server={host};userid=root;password={password};"
                         + $"port={port};database=products";

        return connection;
    }
    
}