namespace Ocelot.Admin
{
    public static class AdminConsts
    {
        public static string DbTablePrefix { get; set; } = "Ocelot";
        public static string DbTableSuffix { get; set; } = "";

        public static string DbSchema { get; set; } = "";

        public const string ConnectionStringName = "Default";
    }
}