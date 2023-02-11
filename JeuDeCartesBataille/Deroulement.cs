using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeCartesBataille
{
    internal class Deroulement
    {
        public void Bataille(Joueur joueur1, List<carte> tasJoueur1, Joueur joueur2, List<carte> tasJoueur2)
        {
            DateTime dateDebut = DateTime.Now; //moment du début de la partie 
            List<carte> defausse1 = new List<carte>();
            List<carte> defausse2 = new List<carte>();
            int nbTours = 0;

            while (tasJoueur1.Count > 0 && tasJoueur2.Count > 0)
            {
                //Début de défausse
                nbTours++;
                Console.WriteLine($"TOUR N°{nbTours}"); //affichage du tour actuel
                defausse1.Add(tasJoueur1[0]);
                Console.WriteLine($"Joueur 1 <<{joueur1.GetPseudo()}>> joue: {tasJoueur1[0].valeur} de {tasJoueur1[0].enseigne}"); //affichage de la carte jouée par joueur1
                tasJoueur1.RemoveAt(0);
                defausse2.Add(tasJoueur2[0]);
                Console.WriteLine($"Joueur 2 <<{joueur2.GetPseudo()}>> joue: {tasJoueur2[0].valeur} de {tasJoueur2[0].enseigne}"); //affichage de la carte jouée par joueur2
                tasJoueur2.RemoveAt(0);
                Console.WriteLine(); //juste pour créer de l'espace dans la console

                //les tests...
                //Joueur 1 gagne le plis
                if (defausse1.Last().id > defausse2.Last().id)
                {
                    tasJoueur1.AddRange(defausse1);
                    tasJoueur1.AddRange(defausse2);
                    defausse1.Clear();
                    defausse2.Clear();
                }
                //Joueur 2 gagne le plis
                else if (defausse1.Last().id < defausse2.Last().id)
                {
                    tasJoueur2.AddRange(defausse2);
                    tasJoueur2.AddRange(defausse1);
                    defausse1.Clear();
                    defausse2.Clear();
                }
                //Il y'a égalité - Bataille
                else
                {
                    Console.WriteLine("BATAILLE!" + Environment.NewLine);

                    //Test de PAT
                    if (tasJoueur1.Count == 0 || tasJoueur2.Count == 0)
                    {
                        break;
                    }

                    //Une carte est ajoutée à la défausse sans l'afficher:
                    defausse1.Add(tasJoueur1[0]);
                    tasJoueur1.RemoveAt(0);
                    defausse2.Add(tasJoueur2[0]);
                    tasJoueur2.RemoveAt(0);

                    //Code pour la variante sans Bataille et sans Pat:
                    //tasJoueur1.AddRange(defausse1);
                    //tasJoueur1.AddRange(defausse2);
                    //defausse1.Clear();
                    //defausse2.Clear();
                }
                //Fin de la défausse

                //Pour passer au prochain tour ou finir (il est conseillé de laisser la résolution auto ("Console.ReadLine" désactivé)
                //Console.ReadLine();

            }//Fin While et donc de la partie.

            //Pour le log:
            //qui se présentera ainsi: <moment de fin de partie>/<nom du jeu joué>/<durée de la partie>/<nombres de tours joués>/Joueur<numéro>/<pseudo du joueur>/.../<pseudo du joueur gagnant>
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            DateTime dateFin = DateTime.Now;
            TimeSpan duree = dateFin.Subtract(dateDebut);

            //Test du gagnant + message de fin + log
            if (tasJoueur1.Count != 0 && tasJoueur2.Count == 0 && defausse1.Count == 0 && defausse2.Count == 0)
            {
                Console.WriteLine($"BRAVO <<{joueur1.GetPseudo()}>> POUR AVOIR GAGNE CETTE PARTIE!!!");
                //Log
                File.AppendAllText(@"" + appPath + "/log.txt", $"{dateFin:yyyy.MM.dd.hh-mm-ss}/BATAILLE/{duree}/{nbTours}/Joueur1/{joueur1.GetPseudo()}/Joueur2/{joueur2.GetPseudo()}/{joueur1.GetPseudo()}{Environment.NewLine}");
            }
            else if (tasJoueur2.Count != 0 && tasJoueur1.Count == 0 && defausse1.Count == 0 && defausse2.Count == 0)
            {
                Console.WriteLine($"BRAVO <<{joueur2.GetPseudo()}>> POUR AVOIR GAGNE CETTE PARTIE!!!");
                //Log
                File.AppendAllText(@"" + appPath + "/log.txt", $"{dateFin:yyyy.MM.dd.hh-mm-ss}/BATAILLE/{duree}/{nbTours}/Joueur1/{joueur1.GetPseudo()}/Joueur2/{joueur2.GetPseudo()}/{joueur2.GetPseudo()}{Environment.NewLine}");
            }
            else
            {
                Console.WriteLine($"INCROYABLE: SITUATION DE PAT! BRAVO  <<{joueur1.GetPseudo()}>> ET <<{joueur2.GetPseudo()}>> POUR AVOIR JOUE!!!");
                //Log
                File.AppendAllText(@"" + appPath + "/log.txt", $"{dateFin:yyyy.MM.dd.hh-mm-ss}/BATAILLE/{duree}/{nbTours}/Joueur1/{joueur1.GetPseudo()}/Joueur2/{joueur2.GetPseudo()}/PAT{Environment.NewLine}");
            }
        }
    }
}
