using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTreeConsole.Dao;

namespace testTreeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnexionBase.GetInstance().TestConnection();
            ConnexionBase.GetInstance().GetSynthese();
            Console.ReadKey();
        }
    }
}
