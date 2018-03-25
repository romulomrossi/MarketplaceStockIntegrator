using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AddressConfig
{
    public class AddressManager
    {
        AddressConfigFile config;

        public AddressManager()
        {
            string file = File.ReadAllText("../AddressConfig/addressConfig.json");
            config = JsonConvert.DeserializeObject<AddressConfigFile>(file);
        }

        public AddressPair GetManagerAddress()
        {
           return config.manager;
        }

        public AddressPair GetDatabaseAPIAddress()
        {
            return config.databaseAPI;
        }
    }
}