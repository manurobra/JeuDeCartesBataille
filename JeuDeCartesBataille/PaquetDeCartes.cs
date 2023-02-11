namespace JeuDeCartesBataille
{
    public struct carte
    {
        public int id; //correspond à la valeur "réelle" (ordre de grandeur) - permet de les comparer
        public string enseigne; //l'enseigne/couleur de la carte - sert à l'affichage
        public string valeur; //correspond à la valeur imprimée sur la carte - sert à l'affichage
    }
    public class PaquetDeCartes
    {
        public List<carte> paquet;

        //Ce constructeur crée un nouveau paquet de 52 cartes ordré
        public PaquetDeCartes()
        {
            paquet = new List<carte>();
            for (int i = 0; i < 4; i++)
            {
                string couleur = "";
                switch (i)
                {
                    case 0:
                        couleur = "Carreau";
                        break;
                    case 1:
                        couleur = "Pique";
                        break;
                    case 2:
                        couleur = "Coeur";
                        break;
                    case 3:
                        couleur = "Trèfle";
                        break;
                }
                for (int j = 2; j < 15; j++)
                {
                    string nom = "";
                    if (j < 11)
                    {
                        nom = j.ToString();
                    }
                    else
                    {
                        switch (j)
                        {
                            case 11:
                                nom = "Valet";
                                break;
                            case 12:
                                nom = "Dame";
                                break;
                            case 13:
                                nom = "Roi";
                                break;
                            case 14:
                                nom = "As";
                                break;
                        }
                    }
                    paquet.Add(new carte()
                    {
                        id = j,
                        enseigne = couleur,
                        valeur = nom
                    }) ;
                }
            }
        }

        public int GetValeurCarte(int id)
        {
            return paquet[id].id;
        }

        public string GetNomDeLaCarte(int id)
        {
            return ($"{paquet[id].valeur} de {paquet[id].enseigne}");
        }

        //La distribution enlève les cartes du paquet crée de manière aléatoire et les places dans deux nouvelles listes
        public (List<carte>, List<carte>) Distribution2Joueurs()
        {
            List<carte> tasJoueur1 = new List<carte>();
            List<carte> tasJoueur2 = new List<carte>();

            var random = new Random();
            int temp1;
            int temp2;
            while (paquet.Count > 0)
            {
                temp1 = random.Next(paquet.Count);
                tasJoueur1.Add(paquet[temp1]);
                paquet.RemoveAt(temp1);

                temp2 = random.Next(paquet.Count);
                tasJoueur2.Add(paquet[temp2]);
                paquet.RemoveAt(temp2);
            }

            return (tasJoueur1, tasJoueur2);
        }
    }
}
