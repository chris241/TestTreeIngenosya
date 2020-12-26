#include <iostream>
#include <fstream>
#include <string>
using namespace std;

int main()
{
    ifstream monFlux("C:/Users/Chris/Desktop/TestTreeIngenosya/testTreeAPI/testTreeAPI/App_Data/my.txt");

    if(monFlux)
    {
        string ligne;

        while(getline(monFlux, ligne))
        {
          cout << ligne <<endl;
        }

    }
    else{
        cout << "Erreur: Impossible d'ouvrir le fichier"<< endl;
    }
    return 0;
}
