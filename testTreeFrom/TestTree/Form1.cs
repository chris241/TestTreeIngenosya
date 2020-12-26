using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testTree.Model;

namespace TestTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            chart.Series["Series1"].Points.Clear();
            try
            {           
                string uri = "http://localhost:44327/api/tree";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";
                request.Accept = "/";
                string result;
                List<Synthese> json = null; 
                HttpWebResponse tests = request.GetResponse() as HttpWebResponse;
                using (StreamReader r = new StreamReader(tests.GetResponseStream()))
                {
                    result  = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<List<Synthese>>(result);
                }
                if ( tests != null)
                {
                    foreach (Synthese test in json)
                    {
                        chart.Series["Series1"].Points.AddXY(test.Categorie,test.Pourcentage.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("il n'y a pas de données pour le moment");
                }
               
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void initialiser_Click(object sender, EventArgs e)
        {
            chart.Series["Series1"].Points.Clear();
        }
    }
}
