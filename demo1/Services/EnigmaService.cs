using demo1.models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace demo1.Services
{
    public class EnigmaService
    {

        string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        Rotor rotor3;
        Rotor rotor2;
        Rotor rotor1;
        Rotor reflector;
        Regex ralpha = new Regex("[A-Z]");
        int[] KeysArr = { 0, 0, 0 };
        int[] R_Advance = { 0, 0, 0 };
        int[] CuntrAdvance = { 0, 0, 0 };
        int c1;

        public StringBuilder Encryption(string keys, string Text)
        {
            int count = 0;

            foreach (var n in keys)
            {
                R_Advance[count] = 0;
                CuntrAdvance[count] = 0;
                KeysArr[count++] = abc.IndexOf(n);
            }

            var SettingsInJson = String.Empty;
            SettingsInJson = File.ReadAllText("EnigmaSettings.json");

            EnigmaSettings resultenigmaSettings = JsonConvert.DeserializeObject<EnigmaSettings>(SettingsInJson);


            rotor3 = new Rotor(resultenigmaSettings.rotor3, KeysArr[2]);
            rotor2 = new Rotor(resultenigmaSettings.rotor2, KeysArr[1]);
            rotor1 = new Rotor(resultenigmaSettings.rotor1, KeysArr[0]);
            reflector = new Rotor(resultenigmaSettings.reflector, 0);

            var output = new StringBuilder();

            foreach (var c in Text)
            {
                if (ralpha.IsMatch(Convert.ToString(c)) == false) {

                    if (Convert.ToString(c) == " ")
                    {
                        Increment_Rotors();
                        reset_Rotors(abc.IndexOf("X"));
                        output.Append(abc[c1]);
                        Increment_Rotors();
                        reset_Rotors(abc.IndexOf("X"));
                        output.Append(abc[c1]);
                    }
                    else
                    {
                        Increment_Rotors();
                        reset_Rotors(abc.IndexOf("Z"));
                        output.Append(abc[c1]);
                        Increment_Rotors();
                        reset_Rotors(abc.IndexOf("Z"));
                        output.Append(abc[c1]);
                    }

                }
                else { 
                Increment_Rotors();
                reset_Rotors(abc.IndexOf(c));
                output.Append(abc[c1]);
                }
            }

            return output;
        }

        static void Deciphering(String textEncryption)

        {

        }

        static int Frequency_analysis(String str_analysis)
        {
            return 0;
        }

        private void Increment_Rotors()
        {
            R_Advance[2]++;
            CuntrAdvance[2]++;
            if (KeysArr[2] + R_Advance[2] > 25) {
                R_Advance[2] = -KeysArr[2];
            }

            if (CuntrAdvance[2] > 25) {
                R_Advance[1]++;
            }

            if (KeysArr[1] + R_Advance[1] > 25)
            {
                R_Advance[1] = -KeysArr[2];
            }

            if (CuntrAdvance[1] > 25)
            {
                R_Advance[0]++;
            }

            if (KeysArr[0] + R_Advance[0] > 25)
            {
                R_Advance[0] = -KeysArr[0];
            }
        }

        private void reset_Rotors(int c)
        {
            c1 = rotor3.EntryEncryption(KeysArr[2] + R_Advance[2],c);
            c1 = rotor2.EntryEncryption(KeysArr[1] + R_Advance[1], c1);
            c1 = rotor1.EntryEncryption(KeysArr[0] + R_Advance[0], c1);
            c1 = reflector.EntryEncryption(0, c1);
            c1 = rotor1.ExitEncryption(KeysArr[0] + R_Advance[0], c1);
            c1 = rotor2.ExitEncryption(KeysArr[1] + R_Advance[1], c1);
            c1 = rotor3.ExitEncryption(KeysArr[2] + R_Advance[2], c1);
        }

    }



}
