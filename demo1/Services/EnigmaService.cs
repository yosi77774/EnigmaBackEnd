using demo1.models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace demo1.Services
{
    public class EnigmaService
    {


        public static string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static Rotor rotor3;
        public static Rotor rotor2;
        public static Rotor rotor1;
        public static Rotor reflector;
        int[] KeysArr = { 0,0,0 };
        int[] R_Advance = { 0, 0, 0 };

        int c1;

        public StringBuilder Encryption(string keys, string Text)
        {
            int count = 0;

            foreach(var n in keys)
            {
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
            R_Advance[2] = 0;
            foreach (var c in Text)
            { 
                R_Advance[2]++;
                c1 = rotor3.EntryEncryption(KeysArr[2]+ R_Advance[2],abc.IndexOf(c));
                c1 = rotor2.EntryEncryption(KeysArr[1] + R_Advance[1], c1) ; 
                c1 = rotor1.EntryEncryption(KeysArr[0]+ R_Advance[0], c1); 
                c1 = reflector.EntryEncryption(0, c1);
                c1 = rotor1.ExitEncryption(KeysArr[0] + R_Advance[0], c1);
                c1 = rotor2.ExitEncryption(KeysArr[1] + R_Advance[1], c1); 
                c1 = rotor3.ExitEncryption(KeysArr[2] + R_Advance[2], c1);

               
                output.Append(abc[c1]);
            }

            /*for (int i = 0; i < Text.Length; i++)
            {
                string Output = "";
                Char Input = Convert.ToChar(Text.Substring(i, 1));
                Output = rotor3.Encrypt(Input);
                //output += Output;
            }*/
            return output;
        }

        static void Deciphering(String textEncryption)

        {

        }

        static int Frequency_analysis(String str_analysis)
        {
            return 0;
        }
    }



}
