namespace EnigmaServer1.models
{
    public class UserSettings : IUserSettings
    {
        internal static object Client;

        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string ClientesCollectionName { get; set; }
    }


    public interface IUserSettings
    {
         string DatabaseName { get; set; }
         string ConnectionString { get; set; }
         string ClientesCollectionName { get; set; }
    }
}