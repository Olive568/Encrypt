using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Encrypt
{
    internal class Program
    {
        static char[] ALPH = new char[] {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        static List<char> ALPHABET = new List<char>();
        static void Main(string[] args)
        {     
            Choice();
        }
        static string GetKey()
        {        
            Console.WriteLine("Machine Mode has been set");
            Console.ReadKey();
            Console.Clear();
            String Key = "";
            Console.Write("What is the key you want to set? : ");
            Key = Console.ReadLine().ToUpper();
            Console.WriteLine("Cypher has been set");
            Console.ReadKey();
            Console.Clear();
            return Key;
        }
        static List<char> EncryptedALPH(char[] ALPH, String Key)
        {
            List<char> ALPHABETTEMP = new List<char>();
            for (int i = 0; i < Key.Length; i++)
            {
                char c = Key[i];
                int cint = (int)c;
                if(cint > 64 && cint < 91)
                {
                    if (!ALPHABETTEMP.Contains(c))
                    {
                        ALPHABETTEMP.Add(c);
                    }
                }     
            }
            for (int i = 0; i < ALPH.Length; i++)
            {
                if (!ALPHABETTEMP.Contains(ALPH[i]))
                {
                    ALPHABETTEMP.Add(ALPH[i]);
                }

            }
            return ALPHABETTEMP;
        }
        static string encrypter(string Word, char[] ALPH, List<char> ALPHABET) 
        {
            string encword = "";
            for(int i = 0; i < Word.Length; i++)
            {
                char c = Word[i];
                int cint = (int)c;
                if(cint > 64 && cint < 91)
                {
                    for (int x = 0; x < ALPH.Length; x++)
                    {
                        if(c == ALPH[x])
                        {
                            encword += ALPHABET[x];
                            break;
                        }
                    }
                }
                else
                {
                    encword += c;
                }
            }
            
            return encword;
        }
        static string Decrypter(String Word, char[] ALPH, List<char> ALPHABET)
        {
            string encword = "";
            Word.ToUpper();
            for(int i = 0; i < Word.Length; i++)
            {
                char c = Word[i];
                int cint = (int)c;
                if(cint > 64 && cint < 91)
                {
                    for(int x = 0; x < ALPH.Length; x++)
                    {
                        if(c == ALPHABET[x])
                        {
                            encword += ALPH[x];
                            break;
                        }
                    }
                }
                else
                {
                    encword += c;
                }
            }
            return encword;
        }
        static void Choice()
        {
            Console.Clear();
            Console.Write("Would you like to encrypt or decrypt a message? [E/D] : ");
            string choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "E":   
                    string Key = GetKey();
                    ALPHABET = EncryptedALPH(ALPH, Key);
                    Console.WriteLine("Please input the message you want to encrypt:");
                    string Word = Console.ReadLine().ToUpper() ;
                    string final = encrypter(Word, ALPH, ALPHABET);
                    Write(final);
                    Console.ReadKey();
                    break;
                case "D":
                    Key = GetKey();
                    ALPHABET = EncryptedALPH(ALPH, Key);
                    Word = Read();
                    final = Decrypter(Word, ALPH, ALPHABET);
                    Console.WriteLine("Reading eMessage and decrypting using the provided key.");
                    Console.WriteLine("The decrpyted message is:");
                    Console.WriteLine(final);
                    Console.WriteLine("Message has been succesfully decrypted.");
                    Console.WriteLine("Press any key to close the program");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    break;
            }
            Console.Clear();
            Console.WriteLine("do you want to continue? Y/N");
            string a = Console.ReadLine().ToUpper();
            switch (a)
                {
                case "Y":
                    Choice();
                    break;
                case "N":

                    break;
                default:
                    Console.WriteLine("Invalid input. stopping program");
                    break; 
            }
        }
        static void Write(String final)
        {
            using (StreamWriter sw = new StreamWriter("eMessage.txt"))
            {
                sw.Write(final);
            }
            Console.WriteLine("Message has been successfuly encrypted and written to eMessage.txt");
            Console.WriteLine("Press any key to continue");
        }
        static string Read()
        {
            string total = "";
            string line = "";
            using (StreamReader sr = new StreamReader("eMessage.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    total += line;
                }
            }
            return total;
        }
    }
}
