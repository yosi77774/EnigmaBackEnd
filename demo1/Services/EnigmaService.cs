using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo1.Services
{
    public class EnigmaService
    {


        public static string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string hidden = "";

        public static Rotor rotor1 = new Rotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ");
        public static Rotor rotor2 = new Rotor("AJDKSIRUXBLHWTMCQGZNPYFVOE");
        public static Rotor rotor3 = new Rotor("BDFHJLCPRTXVZNYEIWGAKMUSQO");


        public String Encryption(string keys,string Text)
        {
            string Output = "";
            string Input = Text.Substring(0, 1);
            Output = rotor3.Encrypt(abc.IndexOf(keys[2]), Input);
            hidden += Output;
            return hidden;
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
