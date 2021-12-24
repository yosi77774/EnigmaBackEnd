using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo1.Services
{
    public class Rotor
    {
        public string Wiring { get; set; }
        private const string Eng_Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Rotor(string rotor)
        {
            Wiring = rotor;
        }

        private string Advance(string wiring, int number)
        {
            string rotor;
            if (number == 0)
                return wiring;
            if (number < 0)
            {
                int adv = wiring.Length + (number % wiring.Length);
                rotor = wiring.Substring(adv) + wiring.Substring(0, adv);
            }
            else
                rotor = wiring.Substring(number) + wiring.Substring(0, number);
            return rotor;
        }

        public string Encrypt(int advance, string letter)
        {
            string rotor = Advance(Wiring, advance);
            int n = Eng_Letters.IndexOf(letter);
            return rotor.Substring(n, 1);
        }

       
         public string Decrypt(int advance, string letter)
        {
            string rotor = Advance(Wiring, advance);
            string bet = Advance(Eng_Letters, advance);
            letter = bet.Substring(Eng_Letters.IndexOf(letter), 1);
            int n = rotor.IndexOf(letter);
            return Eng_Letters.Substring(n, 1);
        }/* */
    }
}
