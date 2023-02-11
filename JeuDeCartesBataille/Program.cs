namespace JeuDeCartesBataille
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Titre
            Console.WriteLine("JEU DE CARTES - BATAILLE" + Environment.NewLine + "------------------------" + Environment.NewLine);

            //On peut instancier des joueurs en leurs assignant directement un pseudo, ou alors laisser l'utilisateur choisir en laissant vide.
            //Premier joueur
            Console.WriteLine("Veuillez enntrer le pseudo du premier joueur:");
            Joueur joueur1 = new Joueur();

            //Deuxième joueur;
            Console.WriteLine("Veuillez enntrer le pseudo du deuxième joueur:");
            Joueur joueur2 = new Joueur();

            string question;
            do
            {
                PaquetDeCartes nouveauPaquet = new PaquetDeCartes();
                //Afin de vérifier que le paquet se soit bien créé et qu'il soit juste:
                //nouveauPaquet.paquet.ForEach(item => Console.WriteLine($"{item.id} - {item.valeur} de {item.enseigne}"));

                //Instanciation/distribution des tas
                (List<carte> tasJoueur1, List<carte> tasJoueur2) = nouveauPaquet.Distribution2Joueurs();

                //Afin de vérifier que tout se soit bien passé lors de la distribution:
                //Console.WriteLine("--------------------------------");
                //nouveauPaquet.paquet.ForEach(item => Console.WriteLine($"{item.id} - {item.valeur} de {item.enseigne}"));
                //Console.WriteLine("--------------------------------");
                //tasJoueur1.ForEach(item => Console.WriteLine($"{item.id} - {item.valeur} de {item.enseigne}"));
                //Console.WriteLine("--------------------------------");
                //tasJoueur2.ForEach(item => Console.WriteLine($"{item.id} - {item.valeur} de {item.enseigne}"));
                //Console.WriteLine("--------------------------------");
                //Console.ReadLine();

                Deroulement jeu = new Deroulement();
                jeu.Bataille(joueur1, tasJoueur1, joueur2, tasJoueur2);

                Console.WriteLine("Voulez-vous rejouer (oui / non)");
                do
                {
                    question = Console.ReadLine();
                    if ((question != "oui") && (question != "non"))
                    {
                        Console.WriteLine("Cette option est impossible: Veuillez écrire oui ou non.");
                    }
                } while ((question != "oui") && (question != "non"));

                Console.Clear();
            } while (question != "non");
        }//Fin Main
    }
}