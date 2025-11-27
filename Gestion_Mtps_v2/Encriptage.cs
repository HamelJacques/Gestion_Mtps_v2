using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEncription
{
    internal class Encriptage
    {
        private int m_Ofset = 30;
        public Encriptage() { }
        public string Encripte(string mot)
        {
            // Mettre les lettres dans une liste
            List<string> list = new List<string>();
            List<char> lettres = mot.ToList();

            // Créer une deuxième liste avec les codes ASCII
            List<int> codesAscii = lettres.Select(c => (int)c - 30).ToList();

            // La liste sera transformée en string pour être sauvegardée
            string asciiString = string.Join("", codesAscii);
            string s = "";
            string t = "";
            char c;
            foreach (int code in codesAscii)
            {
                //s += code + i.ToString() + sep[rnd.Next(sep.Count)];
                s += code.ToString() + ",";
                //i++;
                c = (char)(code);
                t += c.ToString();
            }
            return t;
        }
        public string Decripte(string mot)
        {
            string s = string.Empty;
            //// Transformer chaque caractère en string et mettre dans un tableau
            //string[] lettres = new string[mot.Length];

            //for (int i = 0; i < mot.Length; i++)
            //{
            //    lettres[i] = mot[i].ToString();
            //}


            //// On découpe la chaîne en morceaux séparés par la virgule
            //string[] codes = mot.Split(',', StringSplitOptions.RemoveEmptyEntries);

            // Transformer la string en tableau de char
            char[] tableau = mot.ToCharArray();

            // Parcourir chaque caractère et afficher son code ASCII
            foreach (char c in tableau)
            {
                int ascii = (int)c;   // conversion en entier
                char ca = (char)(ascii + 30);
                s += ca;
                Console.WriteLine($"{ca} => {ascii}");
            }

            return s;
        }
    }
}
