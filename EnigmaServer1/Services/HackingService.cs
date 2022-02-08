using EnigmaServer1.models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EnigmaServer1.Services
{
    public class HackingService
    {
        HackingSettings hackingSettings;

        string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
 
        public String status;

        String Result;

        public EnigmaService _enigmaService;

        public HackingService(EnigmaService enigmaService)
        {
            _enigmaService = enigmaService;
        }


        public async Task <String> Hacking(HackingRequest hackingRequest)
        {
            String[] abc2 = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
           // String textEncryption;
            int max = 0;
            String Encrypted_Text;
            int Frequency_analysis_Result;
            String Keys = "AAA";
            String Returnkey = "";
            int key1 = 0;
            int key2 = 0;
            int key3 = 0;
            EncryptionRequest encryptionRequest = new EncryptionRequest();

            if (hackingRequest.file == null)
            {
                encryptionRequest.Text = hackingRequest.Text.ToUpper();
                encryptionRequest.keys = Keys;
            }

            else
            {
                StreamReader reader = new StreamReader(hackingRequest.file.OpenReadStream());
                String file = reader.ReadToEnd();
                reader.Dispose();
                encryptionRequest.Text = file.ToUpper();
                encryptionRequest.keys = Keys;
            }

            var SettingsInJson = String.Empty;
            SettingsInJson = File.ReadAllText("Settings_data\\HackingSettings.json");
            hackingSettings = JsonConvert.DeserializeObject<HackingSettings>(SettingsInJson);

            while (true) {

                encryptionRequest.keys = Keys;
                Encrypted_Text = await _enigmaService.Encryption(encryptionRequest);

                Frequency_analysis_Result = await Frequency_analysis(Encrypted_Text);

                if (Frequency_analysis_Result > max)
                {
                    Returnkey = Keys;
                    max = Frequency_analysis_Result;
                    Result = Encrypted_Text;
                }


                Keys = abc2[key1] + "" + abc2[key2] + "" + abc2[key3];

                key1++;
                if (key1 >= 26)
                {
                    key2++;
                    key1 = 0;
                }
                if (key2 >= 26)
                {
                    key3++;
                    key2 = 0;
                }
                if (key3 >= 26)
                {
                    break;
                }

            }
            return Returnkey;
        }

        private async Task <int> Frequency_analysis(String str_analysis)
        {

            String abc2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int[] count = new int[26];
            int[] count2 = new int[26];
            int[] Letter_rating2 = new int[26];
            int max = 0;
            int i;
            int c = 0;
            int num;

            for (i = 0; i < str_analysis.Length; i++)
            {
                //ספירת תדירות האותיות בטקסט 
                if (abc2.IndexOf(str_analysis[i]) != -1 || str_analysis[i] != 'X' && str_analysis[i+1] != 'X' ||str_analysis[i] != 'X' && str_analysis[i -1] != 'X' || str_analysis[i] != 'Z' && str_analysis[i+1] != 'Z'|| str_analysis[i] != 'Z' && str_analysis[i -1] != 'Z')
                {
                    num = abc2.IndexOf(str_analysis[i]);
                    count[num]++;
                }

            }
            for (i = 0; i < 26; i++)
            {
                count2[i] = count[i];
            }

            Array.Sort(count2);

            //בדיקת תוצאות התדירות בטקסט מול נתוני התדיריות הרצוי
            for (i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (c > 25)
                    {
                        break;
                    }
                    if (count[i] == count2[j])
                    {
                        Letter_rating2[c++] = (26 - j);
                        if (Letter_rating2[c - 1] == hackingSettings.Statistics1[c - 1] || Letter_rating2[c - 1] == hackingSettings.Statistics1[c - 1] + 1 || Letter_rating2[c - 1] == hackingSettings.Statistics1[c - 1] + 2 || Letter_rating2[c - 1] == hackingSettings.Statistics1[c - 1] + 3 || Letter_rating2[c - 1] == hackingSettings.Statistics1[c - 1] - 1 || Letter_rating2[c - 1] == hackingSettings.Statistics1[c - 1] - 2 || Letter_rating2[c - 1] == hackingSettings.Statistics1[c - 1] - 3)
                        {
                            max++;
                        }
                        break;
                    }
                }
            }
            return max;
        }
    }
}
