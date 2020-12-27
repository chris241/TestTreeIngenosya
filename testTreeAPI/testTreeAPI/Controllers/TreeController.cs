using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using testTreeAPI.Models;
using testTreeConsole.Dao;
using Test = testTreeConsole.Dao.Test;

namespace testTreeAPI.Controllers
{
    [RoutePrefix("api/tree")]
    public class TreeController : ApiController
    {
        //Récupérer les catégories
        [HttpGet]
        public List<Synthese> Get()
        {
            ConnexionBase.GetInstance().TestConnection();
            List<Synthese> tes = ConnexionBase.GetInstance().GetSynthese();
            return tes;

        }
        //export txt du synthèse
        [HttpGet]
        [Route("export")]
        public string GetEnregistreTxt()
        {
            try
            {
                ConnexionBase.GetInstance().TestConnection();
                List<Synthese> tes = ConnexionBase.GetInstance().GetSynthese();
                string path = HttpContext.Current.Server.MapPath("~/App_Data/synthese.txt");
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (Synthese s in tes)
                    {
                        sw.WriteLine(s.Categorie + " " + s.Nombre+" "+s.Pourcentage+"%");
                    }

                }

                return "succès!";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }
        //Ajouter une catégorie
        [HttpPost]
        public string  Post([FromBody]Models.Test value)
        {
            try
            {
                if(String.IsNullOrEmpty(value.Categorie))
                {
                    return "vide";
                }
                ConnexionBase.GetInstance().TestConnection();
                Test test = new Test()
                {
                    Categorie = value.Categorie
                };
                ConnexionBase.GetInstance().AddTest(test);
                return "réussi";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}