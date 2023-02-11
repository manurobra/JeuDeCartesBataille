using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeCartesBataille
{
    public class Joueur
    {
        string _pseudo;

        public Joueur()
        {
            string pseudo = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(pseudo))
            {
                Console.WriteLine("Cette entrée n'est pas valable!");
                pseudo = Console.ReadLine();
            }
            _pseudo = pseudo;
        }

        public Joueur (string pseudo)
        {
            _pseudo = pseudo;
        }

        public string GetPseudo()
        {
            return _pseudo;
        }
    }
}
