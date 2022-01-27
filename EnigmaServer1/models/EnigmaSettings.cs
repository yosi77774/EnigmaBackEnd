using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EnigmaServer1.models
{
    public class EnigmaSettings
    {
        public EnigmaComponents Settings { get; set; }

        public EnigmaSettings () { 

            var SettingsInJson = String.Empty;

            SettingsInJson = File.ReadAllText("Settings_data\\EnigmaSettings.json");

            EnigmaComponents resultenigmaSettings2 = JsonConvert.DeserializeObject<EnigmaComponents>(SettingsInJson);

             Settings= resultenigmaSettings2;
        }
    }
}
