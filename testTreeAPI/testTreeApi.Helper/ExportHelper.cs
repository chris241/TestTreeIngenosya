using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testTreeAPI.Models;

namespace testTreeApi.Helper
{
    public class ExportHelper: Singleton<ExportHelper>
    {
        public void ExportTxt(SyntheseApi synthese)
        {
            string path = @"C:\\Users\\Chris\\Desktop\\TestTreeIngenosya\\testTreeAPI\\testTreeAPI\\App_Data\my.txt";
            using(StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("word");
                sw.WriteLine("word");
                sw.WriteLine("word");
            }
        }
    }
}
