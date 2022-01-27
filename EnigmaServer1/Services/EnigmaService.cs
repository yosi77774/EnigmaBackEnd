using EnigmaServer1.models;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EnigmaServer1.Services
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
        EnigmaSettings enigmaSettings = new EnigmaSettings();
        EnigmaComponents resultenigmaSettings;


            public async Task<String> Encryption(EncryptionRequest encryptionRequest)
        {
            string Text;
            string keys;
            int count = 0;
            resultenigmaSettings = enigmaSettings.Settings;

            if (encryptionRequest.file == null)
            {
                Text = encryptionRequest.Text.ToUpper();
                keys = encryptionRequest.keys.ToUpper(); 
            }

            else
            {
                StreamReader reader = new StreamReader(encryptionRequest.file.OpenReadStream());
                String file = reader.ReadToEnd();
                reader.Dispose();

                Text = file.ToUpper();
                keys = encryptionRequest.keys.ToUpper();
            }

            foreach (var n in keys)
            {
                R_Advance[count] = 0;
                CuntrAdvance[count] = 0;
                KeysArr[count++] = abc.IndexOf(n);
            }

            rotor3 = new Rotor(resultenigmaSettings.rotor3, KeysArr[2]);
            rotor2 = new Rotor(resultenigmaSettings.rotor2, KeysArr[1]);
            rotor1 = new Rotor(resultenigmaSettings.rotor1, KeysArr[0]);
            reflector = new Rotor(resultenigmaSettings.reflector, 0);

            var output = new StringBuilder();

            foreach (var c in Text)
            {
                if (ralpha.IsMatch(Convert.ToString(c)) == false)
                {

                    if (c == ' ')
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
                else
                {
                    Increment_Rotors();
                    reset_Rotors(abc.IndexOf(c));
                    output.Append(abc[c1]);
                }
            }

            return Convert.ToString(output);
        }

        private void Increment_Rotors()
        {
            R_Advance[2]++;
            CuntrAdvance[2]++;
            if (KeysArr[2] + R_Advance[2] > 25)
            {
                R_Advance[2] = -KeysArr[2];
            }

            if (CuntrAdvance[2] > 25)
            {
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
            c1 = rotor3.EntryEncryption(KeysArr[2] + R_Advance[2], c);
            c1 = rotor2.EntryEncryption(KeysArr[1] + R_Advance[1], c1);
            c1 = rotor1.EntryEncryption(KeysArr[0] + R_Advance[0], c1);
            c1 = reflector.EntryEncryption(0, c1);
            c1 = rotor1.ExitEncryption(KeysArr[0] + R_Advance[0], c1);
            c1 = rotor2.ExitEncryption(KeysArr[1] + R_Advance[1], c1);
            c1 = rotor3.ExitEncryption(KeysArr[2] + R_Advance[2], c1);
        }

    }



}
