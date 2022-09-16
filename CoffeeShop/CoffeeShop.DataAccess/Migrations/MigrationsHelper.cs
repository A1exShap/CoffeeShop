namespace CoffeeStore.DataAccess.Migrations;

public static class MigrationsHelper
{
    public static string ReadSql(string scriptName)
    {
        return File.ReadAllText($"Scripts/{scriptName}");
    }
}