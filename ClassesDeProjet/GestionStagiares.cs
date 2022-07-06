using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectezeze.ClassesDeProjet
{
    public class GestionStagiares
    {
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        public void AjouterStagiaire(string cin, string nom, string sexe, string Tel, string email, string Adresse,string etablissement)
        {

            gs.Stagiaire.Add(new EntityFramework.Stagiaire {Cin = cin, NomComplet = nom, Sexe = sexe, Adresse = Adresse, Email = email, Telephone = Tel ,Etablissement=etablissement});
            gs.SaveChanges();
        }
        public bool rechercherstagiaire(string cin)
        {
            var req = gs.Stagiaire.ToList();
            foreach (var i in req)
            {
                if (i.Cin == cin)
                {
                    return true;
                }
            }
            return false;
        }
        public EntityFramework.Stagiaire stagiaire(string cin)
        {
            return gs.Stagiaire.FirstOrDefault(x => x.Cin == cin);
        }
        public void modifierStagiaire(int id, string cin, string nomcomplet, string email, string tel, string adresse, string sexe,string etablissement)
        {
            var req = gs.Stagiaire.FirstOrDefault(x => x.IdStagiaire == id);

            req.Cin = cin;
            req.NomComplet = nomcomplet;
            req.Email = email;
            req.Telephone = tel;
            req.Adresse = adresse;
            req.Sexe = sexe;
            req.Etablissement = etablissement;
            gs.SaveChanges();


        }
    }
}
