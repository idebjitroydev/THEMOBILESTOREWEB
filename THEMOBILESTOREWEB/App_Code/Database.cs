using System.Configuration;

public class Database
{
    public static string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
}