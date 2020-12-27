#include <iostream>
#include <fstream>
#include <string>
#include <stdexcept>
using namespace std;

int main()
{
    try
    {
        ifstream fichier("../testTreeAPI/testTreeAPI/App_Data/synthese.txt");// chemin pour lire le fichier

        if(fichier)
        {
            string ligne;

            while(getline(fichier, ligne))
            {

                if(stoi(ligne.substr(ligne.find("%")-2))>30)
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
    catch(exception e)
    {
    }

}
