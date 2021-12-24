using System;

namespace Enigma_demo
{
    class Program
    {
        static String Encryption()
        {
            String text = "OneofthekeyobjectivesfortheAlliesduringWWIIwastofindawaytobreakthecodetobeabletodecryptGermancommunicationsAteamofPolishcryptanalystswasthefirsttobreak";
            text = text.ToLower();
            Console.WriteLine(text+"                 **");
            String[] abc = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            String abc2 = "abcdefghijklmnopqrstuvwxyz";
            int[] count = new int[26];
            int[] count2 = new int[26];
            int[] Letter_rating = { 3,19,12,9,1,16,17,8,5,22,21,10,14,6,4,18,22,8,7,2,11,20,13,22,15,23};
            int[] Letter_rating2 = new int[26];

            int key1 = 2;
            int key2 = 25;
            int key3 = 8;
            
            int cont_key1 = 0;
            int cont_key2 = 0;
            int cont = 5;

            String Encrypted_text = "";
            String Encrypted_text2 = "";
            String Encrypted_text3 = "";
            int i;
            int c = 0;


            for (i = 0; i < text.Length; i++)
            {
                if (abc2.IndexOf(text[i]) != -1)
                {
                  //  text[i] = "";
                    count[abc2.IndexOf(text[i])]++;

                }
                //-------------------------------------------Rotor1-------------------------------------------------------------
                if (cont_key1 > 25)
                {
                    key2++;
                    cont_key1 = 0;
                    if (key2 > 25)
                    {
                        key2 = 0;
                    }
                }
                else
                {
                    cont_key1++;
                }

                if (abc2.IndexOf(text[i]) == -1)
                {
                    Encrypted_text = Encrypted_text + "";
                    cont++;
                }
                else if (abc2.IndexOf(text[i]) + key1 > 25)
                {
                    Encrypted_text = Encrypted_text + abc2[abc2.IndexOf(text[i]) + key1 - 26];
                }
                else
                    Encrypted_text = Encrypted_text + abc2[abc2.IndexOf(text[i]) + key1];
                key1++;
                if (key1 > 25)
                {
                    key1 = 0;
                }

                //-------------------------------------------Rotor2-------------------------------------------------------------
                if (cont_key2 > 25)
                {
                    key3++;
                    cont_key2 = 0;
                    if (key3 > 25)
                    {
                        key3 = 0;
                    }
                }
                else
                {
                    cont_key2++;
                }

                if (abc2.IndexOf(Encrypted_text[Encrypted_text.Length - 1]) + key2 > 25)
                {
                    Encrypted_text2 = Encrypted_text2 + abc2[abc2.IndexOf(Encrypted_text[Encrypted_text.Length - 1]) + key2 - 26];
                }
                else
                    Encrypted_text2 = Encrypted_text2 + abc2[abc2.IndexOf(Encrypted_text[Encrypted_text.Length - 1]) + key2];

                if (key2 > 25)
                {
                    key2 = 0;
                }

                //-------------------------------------------Rotor3-------------------------------------------------------------


                if (abc2.IndexOf(Encrypted_text2[Encrypted_text2.Length - 1]) + key3 > 25)
                {
                    Encrypted_text3 = Encrypted_text3 + abc2[abc2.IndexOf(Encrypted_text2[Encrypted_text2.Length - 1]) + key3 - 26];
                }
                else
                    Encrypted_text3 = Encrypted_text3 + abc2[abc2.IndexOf(Encrypted_text2[Encrypted_text2.Length - 1]) + key3];





            }
            /**/ Console.WriteLine(Encrypted_text);
             Console.WriteLine(Encrypted_text2);
             Console.WriteLine(Encrypted_text3);

            for(i = 0; i < 26; i++) {
                Console.WriteLine(abc2[i] + " - " + count[i]);
                count2[i] = count[i]; }
            
           /*  Array.Sort(count2);
          
            
           for (i = 0; i < 26; i++)
            {
               for(int j = 0; j < 26; j++)
                {
                    if (c > 25)
                    {
                        break;
                    }
                    if (count[i] == count2[j])
                    {
                        Letter_rating2[c++] = (26-j);
                        Console.WriteLine(c+"- "+abc2[c-1]+" - "+ Letter_rating2[c - 1]+" " +count[i]);
                        break;
                    }
                }
            }*/

            return Encrypted_text3;

        }
        static void Deciphering(String textEncryption)

        {
            String text = textEncryption;

            String[] abc = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            String abc2 = "abcdefghijklmnopqrstuvwxyz";
            int key1 = 0;
            int key2 = 0;
            int key3 = 0;
            int cont = 0;
            String Result="";
            int i;
            int i2;

            int num1 = 0;
            int num2 = 0;
            int num3 = 0;

            int max = 0;
            for (i2 = 0; i2 < Math.Pow(26, 3); i2++)
            {


                int cont_key1 = 0;
                int cont_key2 = 0;
                int cont_key3 = 0;

                String Encrypted_text = "";
                String Encrypted_text2 = "";
                String Encrypted_text3 = "";

                for (i = 0; i < text.Length; i++)
                {

                    //-------------------------------------------Rotor1-------------------------------------------------------------
                    if (cont_key1 > 25)
                    {
                        cont_key1 = 0;
                        key2--;
                        if (key2 < 0)
                        {
                            key2 = 25;
                        }
                    }
                    else
                    {
                        cont_key1++;
                    }

                    if (abc2.IndexOf(text[i]) == -1)
                    {
                        Encrypted_text = Encrypted_text + "";
                        cont++;
                    }
                    else if (abc2.IndexOf(text[i]) + key1 > 25)
                    {
                        Encrypted_text = Encrypted_text + abc2[abc2.IndexOf(text[i]) + key1 - 26];
                    }
                    else
                        Encrypted_text = Encrypted_text + abc2[abc2.IndexOf(text[i]) + key1];
                    key1--;
                    if (key1 < 0)
                    {
                        key1 = 25;
                    }

                    //-------------------------------------------Rotor2-------------------------------------------------------------
                    if (cont_key2 > 25)
                    {
                        cont_key2 = 0;
                        key3--;
                        if (key3 < 0)
                        {
                            key3 = 25;
                        }
                    }
                    else
                    {
                        cont_key2++;
                    }

                    if (abc2.IndexOf(Encrypted_text[Encrypted_text.Length - 1]) + key2 > 25)
                    {
                        Encrypted_text2 = Encrypted_text2 + abc2[abc2.IndexOf(Encrypted_text[Encrypted_text.Length - 1]) + key2 - 26];
                    }
                    else
                        Encrypted_text2 = Encrypted_text2 + abc2[abc2.IndexOf(Encrypted_text[Encrypted_text.Length - 1]) + key2];

                    if (key2 < 0)
                    {
                        key2 = 25;
                    }

                    //-------------------------------------------Rotor3-------------------------------------------------------------


                    if (abc2.IndexOf(Encrypted_text2[Encrypted_text2.Length - 1]) + key3 > 25)
                    {
                        Encrypted_text3 = Encrypted_text3 + abc2[abc2.IndexOf(Encrypted_text2[Encrypted_text2.Length - 1]) + key3 - 26];
                    }
                    else
                        Encrypted_text3 = Encrypted_text3 + abc2[abc2.IndexOf(Encrypted_text2[Encrypted_text2.Length - 1]) + key3];





                }
                if (num1 == 25)
                {
                    num1 = 0;
                    num2++;
                }
                if (num2 > 25)
                {
                    num2 = 0;
                    num3++;
                }
                if (num3 > 25)
                {
                    num3 = 0;
                    Console.WriteLine(i2);
                }
                key1 = ++num1;
                key2 = num2;
                key3 = num3;

                if (Frequency_analysis(Encrypted_text3) > max)
                {
                    max = Frequency_analysis(Encrypted_text3);
                    Result = Encrypted_text3;
                    Console.WriteLine(max + " max "+ Encrypted_text3);
                }
                if (Encrypted_text3 == "oneofthekeyobjectivesforthealliesduringwwiiwastofindawaytobreakthecodetobeabletodecryptgermancommunicationsateamofpolishcryptanalystswasthefirsttobreak")
                {
                    /* Console.WriteLine(Encrypted_text);
                     Console.WriteLine(Encrypted_text2);*/
                    cont++;
                    /*  Console.WriteLine(Encrypted_text3+" "+cont);
                                   Console.WriteLine("key1 "+ key1+" key2 "+key2+" key3 "+key3);*/
                }

            }
            Console.WriteLine("key1 " + key1 + " key2 " + key2 + " key3 " + key3 + " cont " + cont + " " + i2);
            Console.WriteLine(Result);
        }

        static int Frequency_analysis(String str_analysis)
        {
            String abc2 = "abcdefghijklmnopqrstuvwxyz";
            int[] count = new int[26];
            int[] count2 = new int[26];
            int[] Letter_rating = { 3, 19, 12, 9, 1, 16, 17, 8, 5, 22, 21, 10, 14, 6, 4, 18, 22, 8, 7, 2, 11, 20, 13, 22, 15, 23 };
            int[] Letter_rating2 = new int[26];
            int max =0;

            int i;
            int c = 0;

            for (i = 0; i < str_analysis.Length; i++)
            {

                if (abc2.IndexOf(str_analysis[i]) != -1)
                {

                    count[abc2.IndexOf(str_analysis[i])]++;

                }
                /* Console.WriteLine(abc2[i] + " - " + count[i]);
                 count2[i] = count[i];*/

            }
            for (i = 0; i < 26; i++)
            {
               // Console.WriteLine(abc2[i] + " - " + count[i]);
                count2[i] = count[i];
            }

            Array.Sort(count2);


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
                       // Console.WriteLine(c + "- " + abc2[c - 1] + " - " + Letter_rating2[c - 1] + " " + count[i]);
                        if(Letter_rating2[c - 1] == Letter_rating[c - 1]|| Letter_rating2[c - 1] == Letter_rating[c - 1]+1 || Letter_rating2[c - 1] == Letter_rating[c - 1]+2 || Letter_rating2[c - 1] == Letter_rating[c - 1]+3 || Letter_rating2[c - 1] == Letter_rating[c - 1]-1 || Letter_rating2[c - 1] == Letter_rating[c - 1]-2 || Letter_rating2[c - 1] == Letter_rating[c - 1]-3)
                        {
                            max++;
                        }
                        break;
                    }
                }
            }
            return max;
        }

        static void Main(string[] args)
        {
           
            Console.WriteLine(Encryption());
            Deciphering(Encryption());
        }
    }
}
