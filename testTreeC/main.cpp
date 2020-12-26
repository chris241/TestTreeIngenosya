#include <iostream>
#include <fstream>
#include <string>

#include <vector>
using namespace std;

int main()
{
 ifstream fichier("C:/Users/Chris/Desktop/Projet_and_doc/TestTreeIngenosya/testTreeAPI/testTreeAPI/App_Data/synthese.txt");// chemin pour lire le fichier

    if(fichier)
    {
        string ligne;

        while(getline(fichier, ligne))
        {
            if(stoi(ligne.substr(ligne.find(":")+2))>30)
            {
                 cout << ligne <<endl;
            }

        }
    }
    else{
        cout << "Erreur: Impossible d'ouvrir le fichier"<< endl;
    }
    return 0;
}
