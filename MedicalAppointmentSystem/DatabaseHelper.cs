public static class DatabaseHelper
{
    public static string ConnectionString => ConfigurationManager.ConnectionStrings["MedicalDB"].ConnectionString;
}
