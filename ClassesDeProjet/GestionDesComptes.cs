
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace projectezeze.ClassesDeProjet
{
    public class GestionDesComptes
    {
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();

        

        public int SeConnecter(string email,string password)
        {
            var requete= gs.Utilisateur.FirstOrDefault(x => x.Email==email && x.MotDePasse==password);

            if (requete != null)
            {
                if (requete.Role == true)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
               
            }
            else 
            {
                return 0;
            }
          
          
            
                        
        }//done
        public int Seconnecter2(string utilisateur, string password)
        {
            var requete = gs.Utilisateur.FirstOrDefault(x => x.NomUtilisateur == utilisateur && x.MotDePasse == password);

            if (requete != null)
            {
                if (requete.Role == true)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }

            }
            else
            {
                return 0;
            }
        }

        public bool AjouterCompte(string cin,string nomComplet,string email,string telephone,string nomUtilisateur,string motDePasse/*,string role*/)
        {
            EntityFramework.Utilisateur test = gs.Utilisateur.FirstOrDefault(x => x.Cin==cin);
            if (test == null)
            {
                EntityFramework.Utilisateur testAjout= new EntityFramework.Utilisateur();
                testAjout.Cin = cin;
                testAjout.NomComplet = nomComplet;
                testAjout.Email = email;
                testAjout.Telephone = telephone;
                testAjout.NomUtilisateur = nomUtilisateur;
                testAjout.MotDePasse = motDePasse;
                //testAjout.Role = role;
                testAjout.Role = false;
                gs.Utilisateur.Add(testAjout);
                gs.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
            
           
        }

        public void ModifierCompte(string cin, string nomComplet, string email, string telephone, string nomUtilisateur, string motDePasse ,int id)
        {
            EntityFramework.Utilisateur user = gs.Utilisateur.FirstOrDefault(x => x.IdUtilisateur == id);
            if (user != null)
            {
                user.Cin = cin;
                user.NomComplet = nomComplet;
                user.Email = email;
                user.Telephone = telephone;
                user.NomUtilisateur = nomUtilisateur;
                user.MotDePasse = motDePasse;
                gs.SaveChanges();
            } 
        }


        public void supprimerCompte(int id)
        {
            EntityFramework.Utilisateur user = gs.Utilisateur.FirstOrDefault(x => x.IdUtilisateur == id);
            if (user != null)
            {
                gs.Utilisateur.Remove(user);
                gs.SaveChanges();                      
            }
            
        }


        public EntityFramework.Utilisateur user (string email, string password)
        {
            return gs.Utilisateur.FirstOrDefault(x => x.Email == email && x.MotDePasse == password);

        }
        public EntityFramework.Utilisateur user2(string utilisateur, string password)
        {
            return gs.Utilisateur.FirstOrDefault(x => x.NomUtilisateur == utilisateur && x.MotDePasse == password);
        }


        public void mettreAjourComte(int id , string cin, string nomComplet, string email, string telephone, string nomUtilisateur, string motDePasse)
        {
            EntityFramework.Utilisateur user = gs.Utilisateur.FirstOrDefault(x=> x.IdUtilisateur==id);
            
            if (user != null)
            {
                user.Cin = cin;
                user.NomComplet = nomComplet;
                user.Email = email;
                user.Telephone = telephone;
                user.NomUtilisateur = nomUtilisateur;
                user.MotDePasse = motDePasse;
               
                gs.SaveChanges();
                
            }
        }
        public void ajouterAction(string action, int idutilisateur)
        {
            gs.Historique.Add(new EntityFramework.Historique { Action = action, Date = DateTime.Now, IdUtilisateur = idutilisateur });
            gs.SaveChanges();
        } 
        public bool testADmin(string cin)
        {
            EntityFramework.Utilisateur u = gs.Utilisateur.FirstOrDefault(x => x.Cin == cin);
            if (u.Role == true) return true;
            else return false;
        }

        public int returnIdHist(int idAction)
        {
            int i = gs.Historique.FirstOrDefault(x => x.IdAction==idAction).IdAction;
            return i;
        }
        

        public DataTable ReturnTableRole(int idutilisateur ,int type )   //Le rôle de chaque utilisateur
        {
            var req= gs.TypeRole.Where(x=> x.IdUtilisateur==idutilisateur && x.Type==type).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("IdRole", typeof(int));
            dt.Columns.Add("IdUtilisateur", typeof(int));
            dt.Columns.Add("Type", typeof(int));
            dt.Columns.Add("Role", typeof(int));
            foreach(var i in req)
            {
                dt.Rows.Add(i.IdRole,i.IdUtilisateur,i.Type,i.Role);
            }
            return dt;
        }

        public bool rechercherCompte(string cin)
        {
            var req = gs.Utilisateur.ToList();
            foreach (var i in req)
            {
                if (i.Cin == cin)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
