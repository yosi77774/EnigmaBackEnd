
namespace EnigmaServer1.Services
{
    public class Rotor
    {
        public string Wiring { get; set; }
        public int Kesy { get; set; }
        private const string Eng_Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Rotor(string rotor, int kesy)
        {
            Wiring = rotor;
            Kesy = kesy;
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

        public int EntryEncryption(int advance, int LocationLetter)
        {
            string rotor = Advance(Wiring, advance);
            string rotorLetters = Advance(Eng_Letters, advance);
            char encryptChar = rotor[LocationLetter];
            int n = rotorLetters.IndexOf(encryptChar);
            return n;
        }

        public int ExitEncryption(int advance, int LocationLetter)
        {
            string rotor = Advance(Wiring, advance);
            string rotorLetters = Advance(Eng_Letters, advance);
            char encryptChar = rotorLetters[LocationLetter];
            int n = rotor.IndexOf(encryptChar);
            return n;
        }

    }
}
