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
            String Key = "";
            bool loop = true;
            while (loop)
            {
                loop = false;
                Console.WriteLine("Write Your Key");
                Key = Console.ReadLine().ToUpper();
                for (int i = 0; i < Key.Length; i++)
                {
                    char c = Key[i];
                    int check = (int)c;
                    if(check < 65 || check > 90)
                    {
                        Console.WriteLine("only letters are allowed for the key");
                        loop = true;
                        break;
                    }
                }
            }
            return Key;
        }
        static List<char> EncryptedALPH(char[] ALPH, String Key)
        {
            List<char> ALPHABETTEMP = new List<char>();
            for (int i = 0; i < Key.Length; i++)
            {
                char c = Key[i];
                if (!ALPHABETTEMP.Contains(c))
                {
                    ALPHABETTEMP.Add(c);
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
            Console.WriteLine("Type E to Encrypt and D to Decrypt");
            string choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "E":
                    string Key = GetKey();
                    ALPHABET = EncryptedALPH(ALPH, Key);
                    Console.WriteLine("write the word you want to encrypt");
                    string Word = Console.ReadLine().ToUpper() ;
                    string final = encrypter(Word, ALPH, ALPHABET);
                    Console.WriteLine(final);
                    Write(final);
                    Console.ReadKey();
                    break;
                case "D":
                    Key = GetKey();
                    ALPHABET = EncryptedALPH(ALPH, Key);
                    Word = Read();
                    final = Decrypter(Word, ALPH, ALPHABET);
                    
                    foreach (char c in ALPH)
                        Console.Write(c + " ");
                    Console.WriteLine();
                    foreach (char c in ALPHABET)
                        Console.Write(c + " ");

                        Console.WriteLine(final);
                    Console.ReadKey();
                    break;
                default:

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
            }
        }
        static void Write(String final)
        {
            using (StreamWriter sw = new StreamWriter("eMessage.txt"))
            {
                sw.Write(final);
            }
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
